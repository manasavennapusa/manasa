<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExitInterviewQuestion.aspx.cs" Inherits="Exit_ExitInterviewQuestion" %>



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
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>
    <script type="text/javascript">
        function hide()
        {
            var printButton = document.getElementById("btn_print");
            printButton.style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server" class="form-horizontal no-margin">
        <script type="text/javascript">
            function hide() {
                var x = document.getElementById('btnprint');
                x.style.display = 'none';
                window.print();
                x.style.display = 'block';

            }

        </script>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Exit Interview Questionaries</h2>
                        </div>
                        <div class="pull-right">

                            <input type="button" id="btnprint" runat="server" value="Print" onclick="hide(); return false;" class="btn btn-info" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br /><br />
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Escalon Exit Survey:
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <table style="width: 50%; font-size: 15px; font-weight: 500" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">Collector:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 50%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label26" runat="server" Text="SmartH2R"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">Started:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 50%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="lbl_statedate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">Last Modified:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 50%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="lbl_modified" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">Time Spent: 
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 50%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Labelq4" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />
                    <br />

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Employee Details:
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <table style="width: 100%; font-size: 15px; font-weight: 500" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Date:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_date" runat="server"></asp:Label>
                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Name:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_name" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Department:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_dept" runat="server"></asp:Label>

                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Email Address :
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">

                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Hire Date:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_hire" runat="server"></asp:Label>
                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Last Date:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_lastdate" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Starting Position:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_stposition" runat="server"></asp:Label>
                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Ending Position:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_endposition" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Starting Salary:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_stsalary" runat="server"></asp:Label>
                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%; padding: 7px 7px 7px 7px">Ending Salary:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="txt_endsalary" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>PART l:  REASONS FOR LEAVING
                                    </div>
                                </div>
                                <div class="widget-body">

                                    <div class="title" style="width: 30%; padding: 7px 7px 7px 7px; font-weight: 700; font-size: 15px">
                                        <span><b>RESIGNATION :</b></span>
                                    </div>
                                    <br />
                                    <table style="width: 46%; font-size: 15px; font-weight: 500; margin-left: 50px" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" cellspacing="0" cellpadding="0">
                                        <tr id="tr" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="lbl_id" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr1" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr2" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr3" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label12" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr4" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label13" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr5" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr6" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label15" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr7" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label16" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr8" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr9" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label18" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr10" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label19" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr11" runat="server">
                                            <td style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label20" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>

                                    <br />

                                    <div class="title" style="width: 30%; padding: 7px 7px 7px 7px; font-weight: 700; font-size: 15px">
                                        <span><b>Other (specify) :</b></span>
                                    </div>
                                    <br />
                                    <table style="width: 46%; font-size: 15px; font-weight: 500; margin-left: 50px" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" cellspacing="0" cellpadding="0">
                                        <tr id="tr12" runat="server">
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label21" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr13" runat="server">
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label22" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr14" runat="server">
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label23" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr15" runat="server">
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label24" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="tr16" runat="server">
                                            <td class="frm-lft-clr123" style="width: 50%; padding: 7px 7px 7px 7px">
                                                <asp:Label ID="Label25" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                    </table>


                                    <table style="width: 100%; font-size: 15px; font-weight: 500" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%;">Plans after Leaving :
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="Pleaseelaboratetheabovepoint2" runat="server" TextMode="MultiLine" ReadOnly="true" Style="width: 98%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px"></asp:TextBox>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />
                    <br />
                    <br /> <br />

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>PART ll: COMMENTS/SUGGESTIONS FOR IMPROVEMENT
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div class="title">
                                        <span><b>We are interested in what our employees have to say about their work experience with us. Please complete this form.</b></span>
                                    </div>
                                    <br />
                                    <table style="width: 100%; font-size: 15px; font-weight: 500" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 7px">1. What did you like most about your job?
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txt_like" runat="server" TextMode="MultiLine" Style="width: 98%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 7px">2. What did you like least about your job?
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txt_least" runat="server" TextMode="MultiLine" Style="width: 98%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 7px">3. How did you feel about the pay and benefits?
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txt_pay" runat="server" TextMode="MultiLine" Style="width: 98%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 7px">4. How did you feel about the following:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none"></td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">Opportunity to use your abilities
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">Your supervisor’s management 
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">The opportunity to talk with your Supervisor
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">The information you received on  
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">Promotion policies and practices
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">Discipline policies and practices
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">Performance review policies
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 30%; padding: 7px 7px 7px 37px">Physical working conditions
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 70%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>

                                    </table>

                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <b>I have submitted all company belongings back i.e. (ID card, Keys, and Laptop etc.). In case of anything pendency at my end call me 
                                    <asp:TextBox ID="txt_phone" runat="server" CssClass="span10" Style="border-top: none; border-left: none; border-right: none" Width="120px" ReadOnly="true"></asp:TextBox>
                                                    mail me<asp:TextBox ID="txt_mail" runat="server" CssClass="span10" Style="border-top: none; border-left: none; border-right: none" Width="200px" ReadOnly="true"></asp:TextBox>
                                                    else the charges can be deducted from F&F. Details of F&F are :<br />
                                                    <br />
                                                    <asp:TextBox ID="txt_ff" runat="server" TextMode="MultiLine" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>
                                                </b>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>

                    <br />
                    <br />
                    <br />

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>LATEST FAMILY INFORMATION AND CORRESPONDENCE ADDRESS
                                    </div>
                                </div>
                                <div class="widget-body">

                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <b>This has reference to your resignation letter dated 
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="span10" Style="border-top: none; border-left: none; border-right: none" Width="120px"></asp:TextBox>&nbsp;<span id="Span1"></span>
                                                    In this regard we need to know your full and complete latest information.
                                                </b>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <div class="title" style="width: 30%; padding: 7px 7px 7px 7px; font-weight: 700; font-size: 15px">
                                        <span><b>Kindly fill in the following information.</b></span>
                                    </div>
                                    <br />
                                    <table style="width: 100%; font-size: 15px; font-weight: 500" class="table table-striped table-bordered table-hover table-checkable table-responsive datatable" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">a)	Permanent Address (Along with latest Tel/Cell Numbers):
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll2" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span20"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">b)	Present Address (Along with latest Tel/Cell Numbers):
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll3" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span21"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">c)	City, State/Province: 
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll4" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span22"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">d)	Zip/Postal Code:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll5" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span23"></span>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px; font-weight: 700; font-size: 15px"><span><b>Family details:</b></span>
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none"></td>

                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">e)	Father :
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll6" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span24"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">f)	Mother:
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll7" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span25"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">g)	Name of Husband /Wife(If applicable):
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll8" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span26"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 40%; padding: 7px 7px 7px 7px">h)	References( at least 2 references and their correspondence address):
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 60%; padding: 7px 7px 7px 7px; border-right: none">
                                                <asp:TextBox ID="txtOverAll9" runat="server" Style="width: 95%; height: 30px; border: 1px solid #cecece; padding: 5px 5px 5px 5px" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span27"></span>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div id="Div1" class="row-fluid" visible="false" runat="server">
                        <div class="span10">
                            <div class="widget">
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Date Of Clearance</label>
                                            <div class="controls">
                                                <asp:TextBox ID="DateOfClearence" runat="server" disabled="disabled" CssClass="span4"></asp:TextBox>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="Div4" class="row-fluid" runat="server" visible="false">
                        <div class="span12">
                            <div class="widget" style="width: 76px; float: right; height: 46px">
                                <div class="widget-header" style="border-bottom: none; height: 36px">
                                    <div class="pull-right">
                                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>




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


    <script type="text/javascript">
        function hide() {
            var x = document.getElementById('btnprint');
            x.style.display = 'none';
            window.print();
            x.style.display = 'block';

        }

    </script>
    </form>
</body>
</html>

