<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newaccountorhardwarereqform.aspx.cs" Inherits="onboarding_newaccountorhardwarereqform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            margin-top: 0px;
            margin-left: 0px;
        }

        #page_1 {
            position: relative;
            overflow: hidden;
            margin: 8px 0px 31px 0px;
            padding: 0px;
            border: none;
            width: 816px;
        }

            #page_1 #dimg1 {
                position: absolute;
                top: 0px;
                left: 87px;
                z-index: -1;
                width: 722px;
                height: 982px;
            }

                #page_1 #dimg1 #img1 {
                    width: 722px;
                    height: 982px;
                }




        #page_2 {
            position: relative;
            overflow: hidden;
            margin: 8px 0px 32px 0px;
            padding: 0px;
            border: none;
            width: 816px;
            height: 1016px;
        }

            #page_2 #dimg1 {
                position: absolute;
                top: 0px;
                left: 0px;
                z-index: -1;
                width: 816px;
                height: 1016px;
            }

                #page_2 #dimg1 #img1 {
                    width: 816px;
                    height: 1016px;
                }




        .dclr {
            clear: both;
            float: none;
            height: 1px;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
        }

        .ft0 {
            font: bold 19px 'Century Gothic';
            line-height: 23px;
        }

        .ft1 {
            font: bold 16px 'Calibri';
            text-decoration: underline;
            color: #ff0000;
            line-height: 19px;
        }

        .ft2 {
            font: bold 16px 'Calibri';
            line-height: 21px;
        }

        .ft3 {
            font: 15px 'Calibri';
            line-height: 20px;
        }

        .ft4 {
            font: 16px 'Calibri';
            line-height: 21px;
        }

        .ft5 {
            font: bold 16px 'Calibri';
            color: #ffffff;
            line-height: 19px;
        }

        .ft6 {
            font: 13px 'Calibri';
            line-height: 17px;
        }

        .ft7 {
            font: 1px 'Calibri';
            line-height: 1px;
        }

        .ft8 {
            font: 13px 'Calibri';
            line-height: 15px;
        }

        .ft9 {
            font: 1px 'Calibri';
            line-height: 8px;
        }

        .ft10 {
            font: bold 13px 'Calibri';
            line-height: 15px;
        }

        .ft11 {
            font: 1px 'Calibri';
            line-height: 13px;
        }

        .ft12 {
            font: italic 10px 'Calibri';
            line-height: 13px;
        }

        .ft13 {
            font: 1px 'Calibri';
            line-height: 14px;
        }

        .ft14 {
            font: italic 11px 'Calibri';
            line-height: 13px;
        }

        .ft15 {
            font: 12px 'Calibri';
            line-height: 14px;
        }

        .ft16 {
            font: 1px 'Calibri';
            line-height: 7px;
        }

        .ft17 {
            font: italic bold 13px 'Calibri';
            line-height: 15px;
        }

        .ft18 {
            font: 11px 'Calibri';
            line-height: 13px;
        }

        .p0 {
            text-align: left;
            padding-left: 95px;
            margin-top: 54px;
            margin-bottom: 0px;
        }

        .p1 {
            text-align: left;
            padding-left: 247px;
            margin-top: 22px;
            margin-bottom: 0px;
        }

        .p2 {
            text-align: left;
            padding-left: 247px;
            padding-right: 242px;
            margin-top: 2px;
            margin-bottom: 0px;
            text-indent: 60px;
        }

        .p3 {
            text-align: left;
            padding-left: 95px;
            margin-top: 24px;
            margin-bottom: 0px;
        }

        .p4 {
            text-align: left;
            padding-left: 95px;
            padding-right: 98px;
            margin-top: 2px;
            margin-bottom: 0px;
        }

        .p5 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p6 {
            text-align: left;
            padding-left: 197px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p7 {
            text-align: left;
            padding-left: 2px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p8 {
            text-align: left;
            padding-left: 21px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p9 {
            text-align: left;
            padding-left: 6px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p10 {
            text-align: left;
            padding-left: 95px;
            margin-top: 31px;
            margin-bottom: 0px;
        }

        .p11 {
            text-align: left;
            padding-left: 95px;
            margin-top: 47px;
            margin-bottom: 0px;
        }

        .p12 {
            text-align: left;
            padding-left: 15px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p13 {
            text-align: justify;
            padding-left: 95px;
            padding-right: 433px;
            margin-top: 56px;
            margin-bottom: 0px;
        }

        .p14 {
            text-align: left;
            padding-left: 95px;
            padding-right: 417px;
            margin-top: 2px;
            margin-bottom: 0px;
        }

        .p15 {
            text-align: left;
            padding-left: 95px;
            margin-top: 168px;
            margin-bottom: 0px;
        }

        .p16 {
            text-align: left;
            padding-left: 95px;
            margin-top: 2px;
            margin-bottom: 0px;
        }

        .p17 {
            text-align: left;
            padding-left: 95px;
            margin-top: 16px;
            margin-bottom: 0px;
        }

        .p18 {
            text-align: left;
            padding-left: 95px;
            margin-top: 1px;
            margin-bottom: 0px;
        }

        .p19 {
            text-align: right;
            padding-right: 323px;
            margin-top: 18px;
            margin-bottom: 0px;
        }

        .p20 {
            text-align: left;
            padding-left: 415px;
            margin-top: 9px;
            margin-bottom: 0px;
        }

        .p21 {
            text-align: left;
            padding-left: 95px;
            margin-top: 43px;
            margin-bottom: 0px;
        }

        .p22 {
            text-align: left;
            padding-left: 19px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p23 {
            text-align: left;
            padding-left: 5px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p24 {
            text-align: left;
            padding-left: 16px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p25 {
            text-align: left;
            padding-left: 1px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p26 {
            text-align: left;
            padding-left: 95px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .td0 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
        }

        .td1 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 285px;
            vertical-align: bottom;
        }

        .td2 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 84px;
            vertical-align: bottom;
        }

        .td3 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 267px;
            vertical-align: bottom;
        }

        .td4 {
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td5 {
            padding: 0px;
            margin: 0px;
            width: 285px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td6 {
            padding: 0px;
            margin: 0px;
            width: 25px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td7 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td8 {
            padding: 0px;
            margin: 0px;
            width: 53px;
            vertical-align: bottom;
        }

        .td9 {
            padding: 0px;
            margin: 0px;
            width: 267px;
            vertical-align: bottom;
        }

        .td10 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td11 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 285px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td12 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 25px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td13 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td14 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 53px;
            vertical-align: bottom;
        }

        .td15 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 285px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td16 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 25px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td17 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 320px;
            vertical-align: bottom;
        }

        .td18 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td19 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 310px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td20 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td21 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 320px;
            vertical-align: bottom;
        }

        .td22 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 310px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td23 {
            padding: 0px;
            margin: 0px;
            width: 310px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td24 {
            padding: 0px;
            margin: 0px;
            width: 320px;
            vertical-align: bottom;
        }

        .td25 {
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td26 {
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 302px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td27 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td28 {
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 53px;
            vertical-align: bottom;
        }

        .td29 {
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 275px;
            vertical-align: bottom;
        }

        .td30 {
            padding: 0px;
            margin: 0px;
            width: 302px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td31 {
            padding: 0px;
            margin: 0px;
            width: 152px;
            vertical-align: bottom;
        }

        .td32 {
            padding: 0px;
            margin: 0px;
            width: 123px;
            vertical-align: bottom;
        }

        .td33 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 302px;
            vertical-align: bottom;
            background: #f2dbdb;
        }

        .td34 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 152px;
            vertical-align: bottom;
        }

        .td35 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 123px;
            vertical-align: bottom;
        }

        .td36 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 302px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td37 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 151px;
            vertical-align: bottom;
        }

        .td38 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 151px;
            vertical-align: bottom;
        }

        .td39 {
            padding: 0px;
            margin: 0px;
            width: 87px;
            vertical-align: bottom;
        }

        .td40 {
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 299px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td41 {
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 278px;
            vertical-align: bottom;
        }

        .td42 {
            padding: 0px;
            margin: 0px;
            width: 299px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td43 {
            padding: 0px;
            margin: 0px;
            width: 331px;
            vertical-align: bottom;
        }

        .td44 {
            padding: 0px;
            margin: 0px;
            width: 278px;
            vertical-align: bottom;
        }

        .td45 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 299px;
            vertical-align: bottom;
            background: #f6e6e6;
        }

        .td46 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 278px;
            vertical-align: bottom;
        }

        .td47 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 87px;
            vertical-align: bottom;
        }

        .td48 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 299px;
            vertical-align: bottom;
        }

        .td49 {
            padding: 0px;
            margin: 0px;
            width: 234px;
            vertical-align: bottom;
        }

        .td50 {
            padding: 0px;
            margin: 0px;
            width: 147px;
            vertical-align: bottom;
        }

        .td51 {
            padding: 0px;
            margin: 0px;
            width: 60px;
            vertical-align: bottom;
        }

        .td52 {
            padding: 0px;
            margin: 0px;
            width: 141px;
            vertical-align: bottom;
        }

        .td53 {
            padding: 0px;
            margin: 0px;
            width: 93px;
            vertical-align: bottom;
        }

        .tr0 {
            height: 20px;
        }

        .tr1 {
            height: 15px;
        }

        .tr2 {
            height: 8px;
        }

        .tr3 {
            height: 16px;
        }

        .tr4 {
            height: 17px;
        }

        .tr5 {
            height: 19px;
        }

        .tr6 {
            height: 13px;
        }

        .tr7 {
            height: 14px;
        }

        .tr8 {
            height: 18px;
        }

        .tr9 {
            height: 7px;
        }

        .tr10 {
            height: 30px;
        }

        .tr11 {
            height: 29px;
        }

        .tr12 {
            height: 33px;
        }

        .t0 {
            width: 642px;
            margin-left: 87px;
            margin-top: 12px;
            font: 13px 'Calibri';
        }

        .t1 {
            width: 642px;
            margin-left: 87px;
            font: 13px 'Calibri';
        }

        .t2 {
            width: 816px;
            font: 13px 'Calibri';
        }

        .t3 {
            width: 441px;
            margin-left: 95px;
            font: 13px 'Calibri';
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: white">
        <div id="page_1">
            <div>
                <img src="../upload/logo/client-logo.png">
            </div>


            <div class="dclr"></div>
            <p class="p0 ft0">New Account / Hardware Request Form</p>
            <p class="p1 ft1">This form must be filled in by users line manager</p>
            <p class="p2 ft4">Once complete email to either: <span class="ft2">starters@abfoods.com </span><span class="ft3">or </span><span class="ft2">movers@abfoods.com</span></p>
            <p class="p3 ft5">Section 1 – User details</p>
            <p class="p4 ft6">Please indicate whether request is for a new user or an amendment. Only complete the fields subject to change for amendments.</p>
            <table cellpadding="0" cellspacing="0" class="t0">
                <tr>
                    <td class="tr0 td0">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr0 td1">
                        <p class="p6 ft8">New User</p>
                    </td>
                    <td colspan="3" class="tr0 td2">
                        <p class="p5 ft8">Amendment</p>
                    </td>
                    <td class="tr0 td3">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td5">
                        <p class="p7 ft8">Full Name</p>
                    </td>
                    <td class="tr1 td6">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td9">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr2 td10">
                        <p class="p5 ft9">&nbsp;</p>
                    </td>
                    <td class="tr2 td11">
                        <p class="p5 ft9">&nbsp;</p>
                    </td>
                    <td class="tr2 td12">
                        <p class="p5 ft9">&nbsp;</p>
                    </td>
                    <td class="tr2 td13">
                        <p class="p5 ft9">&nbsp;</p>
                    </td>
                    <td class="tr2 td14">
                        <p class="p5 ft9">&nbsp;</p>
                    </td>
                    <td class="tr2 td3">
                        <p class="p5 ft9">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td15">
                        <p class="p7 ft8">Start Date</p>
                    </td>
                    <td class="tr3 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td3">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td15">
                        <p class="p7 ft8">Business Unit</p>
                    </td>
                    <td class="tr3 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td3">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td15">
                        <p class="p7 ft8">Building Address</p>
                    </td>
                    <td class="tr3 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td3">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td15">
                        <p class="p7 ft8">Job Title</p>
                    </td>
                    <td class="tr1 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td3">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td15">
                        <p class="p7 ft8">Line Manager (include contact telephone number)</p>
                    </td>
                    <td class="tr3 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td3">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td5">
                        <p class="p7 ft10">Existing Equipment</p>
                    </td>
                    <td class="tr3 td6">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td8">
                        <p class="p8 ft8">NA</p>
                    </td>
                    <td class="tr3 td9">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td5">
                        <p class="p7 ft8">Asset number/computer name of PC or laptop to be</p>
                    </td>
                    <td class="tr3 td6">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td9">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr4 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td15">
                        <p class="p7 ft8">used</p>
                    </td>
                    <td class="tr4 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td3">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td5">
                        <p class="p7 ft10">New Equipment</p>
                    </td>
                    <td class="tr3 td6">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td8">
                        <p class="p9 ft8">Yes</p>
                    </td>
                    <td class="tr3 td9">
                        <p class="p5 ft8">No</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td15">
                        <p class="p7 ft8">Please Select</p>
                    </td>
                    <td class="tr3 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td colspan="2" class="tr3 td17">
                        <p class="p9 ft8">(Please complete Section 7)</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td15">
                        <p class="p7 ft8">PC / Laptop / Thin Client user</p>
                    </td>
                    <td class="tr3 td16">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td colspan="2" class="tr3 td17">
                        <p class="p9 ft8">&lt;click and select&gt;</p>
                    </td>
                </tr>
            </table>
            <p class="p10 ft5">Section 2 – Employment details</p>
            <table cellpadding="0" cellspacing="0" class="t1">
                <tr>
                    <td class="tr5 td18">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr5 td19">
                        <p class="p7 ft8">Employment type</p>
                    </td>
                    <td class="tr5 td20">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr5 td21">
                        <p class="p9 ft8">&lt;click and select&gt;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td22">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td17">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td23">
                        <p class="p7 ft8">Contract end date(only for contract workers)</p>
                    </td>
                    <td class="tr1 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td24">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr6 td4">
                        <p class="p5 ft11">&nbsp;</p>
                    </td>
                    <td class="tr6 td23">
                        <p class="p7 ft12">Note: Contractor and temporary accounts will be set to expire on the</p>
                    </td>
                    <td class="tr6 td7">
                        <p class="p5 ft11">&nbsp;</p>
                    </td>
                    <td class="tr6 td24">
                        <p class="p5 ft11">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr7 td10">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                    <td class="tr7 td22">
                        <p class="p7 ft14">date provided above</p>
                    </td>
                    <td class="tr7 td13">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                    <td class="tr7 td17">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                </tr>
            </table>
            <p class="p10 ft5">Section3 ‐Access to Network Resources</p>
            <table cellpadding="0" cellspacing="0" class="t1">
                <tr>
                    <td class="tr8 td25">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr8 td26">
                        <p class="p7 ft8">Will Internet access be required</p>
                    </td>
                    <td class="tr8 td27">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr8 td28">
                        <p class="p9 ft8">Yes</p>
                    </td>
                    <td colspan="2" class="tr8 td29">
                        <p class="p5 ft8">No</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td30">
                        <p class="p7 ft15">List any network folders they require access to. Include</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td31">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td32">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td30">
                        <p class="p7 ft8">the full network path for example</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td31">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td32">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr4 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td30">
                        <p class="p7 ft8">\\server\folder\folder</p>
                    </td>
                    <td class="tr4 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td31">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td32">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr1 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td30">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td31">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr1 td32">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr9 td10">
                        <p class="p5 ft16">&nbsp;</p>
                    </td>
                    <td class="tr9 td33">
                        <p class="p5 ft16">&nbsp;</p>
                    </td>
                    <td class="tr9 td13">
                        <p class="p5 ft16">&nbsp;</p>
                    </td>
                    <td class="tr9 td14">
                        <p class="p5 ft16">&nbsp;</p>
                    </td>
                    <td class="tr9 td34">
                        <p class="p5 ft16">&nbsp;</p>
                    </td>
                    <td class="tr9 td35">
                        <p class="p5 ft16">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td36">
                        <p class="p7 ft8">List any SharePoint access required</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td34">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td35">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td36">
                        <p class="p7 ft8">List any network printers they require access to</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td34">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td35">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td30">
                        <p class="p7 ft8">Will remote access be required include what the user</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td37">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td32">
                        <p class="p9 ft17">Cost Centre:</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td36">
                        <p class="p7 ft8">needs to access to.</p>
                    </td>
                    <td class="tr3 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td38">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td35">
                        <p class="p9 ft17">Cost Code:</p>
                    </td>
                </tr>
            </table>
            <p class="p11 ft5">Section 4 – Email access</p>
            <table cellpadding="0" cellspacing="0" class="t2">
                <tr>
                    <td class="tr0 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr8 td25">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr8 td40">
                        <p class="p7 ft8">Does the user require an Email account</p>
                    </td>
                    <td class="tr8 td27">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr8 td28">
                        <p class="p9 ft8">Yes</p>
                    </td>
                    <td class="tr8 td41">
                        <p class="p5 ft8">No</p>
                    </td>
                    <td class="tr0 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td42">
                        <p class="p7 ft8">List any Distribution lists the user will need to be a</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td colspan="2" class="tr3 td43">
                        <p class="p12 ft8">AB Mauri India Group</p>
                    </td>
                    <td class="tr3 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr3 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td4">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td42">
                        <p class="p7 ft8">member of</p>
                    </td>
                    <td class="tr3 td7">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td8">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td44">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr3 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr7 td39">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                    <td class="tr7 td4">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                    <td class="tr7 td42">
                        <p class="p7 ft12">Note: List the name of the distribution list and the email if possible.</p>
                    </td>
                    <td class="tr7 td7">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                    <td class="tr7 td8">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                    <td class="tr7 td44">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                    <td class="tr7 td39">
                        <p class="p5 ft13">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr10 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr11 td10">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr11 td45">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr11 td13">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr11 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr11 td46">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr10 td39">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr12 td47">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr12 td0">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr12 td48">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr12 td0">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr12 td14">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr12 td46">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr12 td47">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
            </table>
        </div>
        <div id="page_2">
            <div id="Div1">
                <img src="New%20Account%20and%20or%20Hardware%20Request%20Form_images/New%20Account%20and%20or%20Hardware%20Request%20Form2x1.jpg" id="img2">
            </div>


            <div class="dclr"></div>
            <p class="p13 ft6">List any additional mailbox access required and what level of access is required ( Read only / Full with Send on Behalf / Full With Send As )</p>
            <p class="p11 ft5">Section 5 – Business Systems access</p>
            <p class="p14 ft6">Please list any business systems applications that will be required. (include as much information, level of access required / copy user details)</p>
            <p class="p15 ft5">
                Section 6
            <nobr>–Software</nobr>
                access
            </p>
            <p class="p16 ft8">List any additional software required:</p>
            <p class="p17 ft18">NOTE: As standard all Machine builds come with;</p>
            <p class="p18 ft18">Office Standard 2007 (Outlook, Excel, PowerPoint, Word)</p>
            <p class="p19 ft17">COST CENTER:</p>
            <p class="p20 ft17">COST CODE:</p>
            <p class="p21 ft5">Section 7 – Hardware Requirements</p>
            <table cellpadding="0" cellspacing="0" class="t3">
                <tr>
                    <td colspan="2" class="tr5 td49">
                        <p class="p5 ft8">Select hardware requirements</p>
                    </td>
                    <td class="tr5 td50">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr5 td51">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr4 td52">
                        <p class="p22 ft8">Desktop</p>
                    </td>
                    <td class="tr4 td53">
                        <p class="p23 ft8">Laptop</p>
                    </td>
                    <td class="tr4 td50">
                        <p class="p7 ft8">Laptop Docking Station</p>
                    </td>
                    <td class="tr4 td51">
                        <p class="p7 ft18">Thin Client</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr4 td52">
                        <p class="p24 ft8">Monitor Required?</p>
                    </td>
                    <td class="tr4 td53">
                        <p class="p5 ft8">17”</p>
                    </td>
                    <td class="tr4 td50">
                        <p class="p5 ft8">19”</p>
                    </td>
                    <td class="tr4 td51">
                        <p class="p5 ft8">21”</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr4 td52">
                        <p class="p24 ft8">Mouse</p>
                    </td>
                    <td class="tr4 td53">
                        <p class="p25 ft8">Keyboard</p>
                    </td>
                    <td class="tr4 td50">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td51">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr4 td52">
                        <p class="p24 ft8">Mobile Phone</p>
                    </td>
                    <td class="tr4 td53">
                        <p class="p5 ft8">Blackberry</p>
                    </td>
                    <td class="tr4 td50">
                        <p class="p7 ft8">Desk Phone</p>
                    </td>
                    <td class="tr4 td51">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
                <tr>
                    <td class="tr4 td52">
                        <p class="p12 ft8">Laptop Case</p>
                    </td>
                    <td class="tr4 td53">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td50">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                    <td class="tr4 td51">
                        <p class="p5 ft7">&nbsp;</p>
                    </td>
                </tr>
            </table>
            <p class="p26 ft17">COST CENTER:</p>
            <p class="p26 ft17">COST CODE:</p>
            <p class="p16 ft18">NOTE: If cost information is not filled in the hardware requests will not be dealt with.</p>
            <p class="p18 ft8">Please list any additional requirements that are not covered above:</p>
        </div>
    </form>
</body>
</html>
