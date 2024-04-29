<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="participantfeedbackform.aspx.cs" Inherits="training_participantfeedbackform" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

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
                        <h2>Participant Feedback Form</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>Create
                                </div>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left" id="data-table">
                                <tbody>
                                    <tr>
                                        <td width="22%">Training Program Name:</td>
                                        <td width="25%">
                                            <asp:Label ID="txtcmpname" runat="server"></asp:Label>
                                        </td>
                                        <td width="22%">From Date:
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="txt_est_date" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Empcode:
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_empcode" runat="server"></asp:Label>&nbsp;
                                            </td>
                                         <td >To Date:
                                        </td>
                                        <td >
                                            <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        
                                    </tr>

                                    <tr>
                                        <td>Conducted by:
                                        </td>
                                        <td>
                                            <asp:Label ID="txttin" runat="server"></asp:Label>&nbsp;
                                        </td>

                                        <td>Participant Name:
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_pan" runat="server"></asp:Label>&nbsp;
                                        </td>
                                       
                                    </tr>

                                    <tr>
                                        <td>Department:
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_tanno" runat="server"></asp:Label>&nbsp;
                                        </td>
                                         <td>Venue:
                                        </td>
                                        <td>
                                            <asp:Label ID="txtregno" runat="server"></asp:Label>&nbsp;
                                             <asp:Label ID="txt_tds" visible="false" runat="server"></asp:Label>&nbsp;
                                        </td>

                                      
                                           
                                      
                                    </tr>
                                       <tr runat="server" visible="false">
                                        <td>training Scheduled by:
                                        </td>
                                        <td>
                                            <asp:Label ID="txtscheled" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>1. The Objective of the program was well achieved
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="a" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="a" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="a" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="a" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton5" runat="server" GroupName="a" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton6" runat="server" GroupName="a" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton7" runat="server" GroupName="a" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                   
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>2. The Subject matter covered was extreamly useful to my job
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton8" runat="server" GroupName="b" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton9" runat="server" GroupName="b" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton10" runat="server" GroupName="b" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton11" runat="server" GroupName="b" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton12" runat="server" GroupName="b" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton13" runat="server" GroupName="b" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton14" runat="server" GroupName="b" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                  
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>3. I will be able to apply much learnings in my job
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton15" runat="server" GroupName="c" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton16" runat="server" GroupName="c" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton17" runat="server" GroupName="c" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton18" runat="server" GroupName="c" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton19" runat="server" GroupName="c" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton20" runat="server" GroupName="c" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton21" runat="server" GroupName="c" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                   
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>4. The Faculty was Effective Communicator
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton22" runat="server" GroupName="d" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton23" runat="server" GroupName="d" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton24" runat="server" GroupName="d" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton25" runat="server" GroupName="d" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton26" runat="server" GroupName="d" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton27" runat="server" GroupName="d" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton28" runat="server" GroupName="d" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                   
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>5. The faculty was well prepared
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton29" runat="server" GroupName="e" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton30" runat="server" GroupName="e" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton31" runat="server" GroupName="e" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton32" runat="server" GroupName="e" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton33" runat="server" GroupName="e" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton34" runat="server" GroupName="e" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton35" runat="server" GroupName="e" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                   
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>6. The audio visual aids were effective--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>6. Trainer was approachable and shared examples
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton36" runat="server" GroupName="f" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton37" runat="server" GroupName="f" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton38" runat="server" GroupName="f" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton39" runat="server" GroupName="f" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton40" runat="server" GroupName="f" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton41" runat="server" GroupName="f" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton42" runat="server" GroupName="f" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                  
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>7. The reading material was extremely useful--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>7. The training content/ matter was organized and understandable
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton43" runat="server" GroupName="g" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton44" runat="server" GroupName="g" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton45" runat="server" GroupName="g" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton46" runat="server" GroupName="g" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton47" runat="server" GroupName="g" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton48" runat="server" GroupName="g" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton49" runat="server" GroupName="g" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                 
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>8. There was a good balance between presentation and group involvement
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton50" runat="server" GroupName="h" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton51" runat="server" GroupName="h" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton52" runat="server" GroupName="h" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton53" runat="server" GroupName="h" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton54" runat="server" GroupName="h" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton55" runat="server" GroupName="h" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton56" runat="server" GroupName="h" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>9. The facilities were suitable--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>9. Questions and doubts were answered
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton57" runat="server" GroupName="i" Checked="false" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton58" runat="server" GroupName="i" Checked="false" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton59" runat="server" GroupName="i" Checked="false" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton60" runat="server" GroupName="i" Checked="false" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="RadioButton61" runat="server" GroupName="i" Checked="false" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton62" runat="server" GroupName="i" Checked="false" />&nbsp;&nbsp;6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton63" runat="server" GroupName="i" Checked="false" />&nbsp;&nbsp;7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                  
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid" id="tr_10" runat="server" style="display: none">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>10. The programme was
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Rating.
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="RadioButton64" runat="server" GroupName="j" Checked="false" />&nbsp;&nbsp;Too Short&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton65" runat="server" GroupName="j" Checked="false" />&nbsp;&nbsp;About Right&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="RadioButton66" runat="server" GroupName="j" Checked="false" />&nbsp;&nbsp;Too Long&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                                                          
                                    </td>
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%-- <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>11. Suggestion for future improvements on--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>10. Suggestion for future improvements on
                                </div>
                            </div>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Programe:
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox
                                            ID="Text4"
                                            runat="server"
                                            class="span10"
                                            onkeypress="return isChar_Number_slash()"
                                            pattern="^[a-zA-Z0-9\s]+$"
                                            title="Work Location Code" />
                                    </td>
                                </tr>
                            </table>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Faculty Description
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox
                                            ID="Text1"
                                            runat="server"
                                            class="span10"
                                            onkeypress="return isChar_Number_slash()"
                                            pattern="^[a-zA-Z0-9\s]+$"
                                            title="Work Location Code" />
                                    </td>
                                </tr>
                            </table>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Any Other
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox
                                            ID="Text2"
                                            runat="server"
                                            class="span10"
                                            onkeypress="return isChar_Number_slash()"
                                            pattern="^[a-zA-Z0-9\s]+$"
                                            title="Work Location Code" />
                                    </td>
                                </tr>
                            </table>


                        </div>
                    </div>
                </div>

                <div class="form-actions no-margin" style="text-align:right">
                    <asp:Button ID="btn_select" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_select_Click1"
                        ValidationGroup="v" ToolTip="Click to submit" />&nbsp;&nbsp;
                                                 <asp:Button ID="btn_deselect" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btn_deselect_Click"
                                                     ValidationGroup="v" ToolTip="Click to clear" />&nbsp;&nbsp;
                                                 <asp:Button ID="btn_submit" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btn_submit_Click"
                                                      ToolTip="Click to go Back" Visible="false" />&nbsp;&nbsp;
                                                  
                </div>

                <span id="message" runat="server"></span>

                <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_intranet_companydetails.companyname, tbl_intranet_branch_detail.branch_name, tbl_intranet_branch_detail.Branch_Id,tbl_intranet_branch_detail.branch_code, tbl_intranet_branch_detail.esstt_date, tbl_intranet_branch_detail.region, tbl_intranet_branch_detail.add1 + ', '  + tbl_intranet_branch_detail.city + ', '+ tbl_intranet_branch_detail.state+ ', ' + tbl_intranet_branch_detail.country + ' ' + tbl_intranet_branch_detail.zipcode as address FROM tbl_intranet_branch_detail INNER JOIN tbl_intranet_companydetails ON tbl_intranet_branch_detail.Company_id = tbl_intranet_companydetails.companyid"
                            ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                            DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"></asp:SqlDataSource>--%>
            </div>
        </div>
    </form>
</body>
</html>



