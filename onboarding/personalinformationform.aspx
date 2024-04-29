<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personalinformationform.aspx.cs" Inherits="onboarding_personalinformationform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/popup.js"></script>
    <%--<link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function ValidateEmpcode() {
            var empcode = document.getElementById('<%=txt_employee.ClientID %>');
            if (empcode.value == "") {
                empcode.focus();
                alert("Please select empcode");
                return false;
            }

        }
        function isKey(keyCode) {
            return false;
        }
    </script>
    <style type="text/css">
        body {
            margin-top: 0px;
            margin-left: 0px;
        }

        #page_1 {
            position: relative;
            overflow: hidden;
            margin: 10px 0px 96px 71px;
            padding: 0px;
            border: none;
            width: 900px;
        }


        #page_2 {
            position: relative;
            overflow: hidden;
            margin: 10px 0px 132px 112px;
            padding: 0px;
            border: none;
            width: 874px;
        }

            #page_2 #dimg1 {
                position: absolute;
                top: 0px;
                left: 413px;
                z-index: -1;
                width: 171px;
                height: 59px;
            }

                #page_2 #dimg1 #img1 {
                    width: 171px;
                    height: 59px;
                }




        #page_3 {
            position: relative;
            overflow: hidden;
            margin: 10px 0px 104px 112px;
            padding: 0px;
            border: none;
            width: 704px;
        }

            #page_3 #dimg1 {
                position: absolute;
                top: 0px;
                left: 413px;
                z-index: -1;
                width: 171px;
                height: 59px;
            }

                #page_3 #dimg1 #img1 {
                    width: 171px;
                    height: 59px;
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
            font: bold 16px 'Century Gothic';
            text-decoration: underline;
            line-height: 19px;
        }

        .ft1 {
            font: 13px 'Century Gothic';
            line-height: 17px;
        }

        .ft2 {
            font: 1px 'Century Gothic';
            line-height: 1px;
        }

        .ft3 {
            font: 12px 'Century Gothic';
            line-height: 17px;
        }

        .ft4 {
            font: 1px 'Century Gothic';
            line-height: 7px;
        }

        .ft5 {
            font: bold 13px 'Century Gothic';
            line-height: 16px;
        }

        .ft6 {
            font: 1px 'Century Gothic';
            line-height: 6px;
        }

        .ft7 {
            font: bold 12px 'Century Gothic';
            line-height: 16px;
        }

        .ft8 {
            font: 1px 'Century Gothic';
            line-height: 15px;
        }

        .ft9 {
            font: 13px 'Century Gothic';
            line-height: 16px;
        }

        .ft10 {
            font: 1px 'Century Gothic';
            line-height: 14px;
        }

        .ft11 {
            font: bold 13px 'Century Gothic';
            text-decoration: underline;
            line-height: 16px;
        }

        .ft12 {
            font: 13px 'Century Gothic';
            text-decoration: underline;
            line-height: 17px;
        }

        .p0 {
            text-align: left;
            padding-left: 167px;
            margin-top: 66px;
            margin-bottom: 0px;
        }

        .p1 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p2 {
            text-align: left;
            padding-left: 29px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p3 {
            text-align: left;
            padding-left: 33px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p4 {
            text-align: left;
            padding-left: 77px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p5 {
            text-align: left;
            padding-left: 92px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p6 {
            text-align: left;
            padding-left: 30px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p7 {
            text-align: left;
            padding-left: 13px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p8 {
            text-align: left;
            padding-left: 18px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p9 {
            text-align: left;
            padding-left: 36px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p10 {
            text-align: left;
            padding-left: 40px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p11 {
            text-align: left;
            padding-left: 8px;
            margin-top: 92px;
            margin-bottom: 0px;
        }

        .p12 {
            text-align: left;
            padding-left: 8px;
            margin-top: 15px;
            margin-bottom: 0px;
        }

        .p13 {
            text-align: right;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p14 {
            text-align: left;
            padding-left: 8px;
            margin-top: 30px;
            margin-bottom: 0px;
        }

        .p15 {
            text-align: left;
            padding-left: 8px;
            margin-top: 23px;
            margin-bottom: 0px;
        }

        .p16 {
            text-align: left;
            padding-left: 56px;
            margin-top: 8px;
            margin-bottom: 0px;
        }

        .p17 {
            text-align: left;
            padding-left: 56px;
            margin-top: 7px;
            margin-bottom: 0px;
        }

        .p18 {
            text-align: left;
            padding-left: 8px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p19 {
            text-align: right;
            padding-right: 10px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p20 {
            text-align: left;
            padding-left: 42px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p21 {
            text-align: left;
            padding-left: 57px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p22 {
            text-align: left;
            padding-left: 28px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p23 {
            text-align: center;
            padding-right: 1px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p24 {
            text-align: left;
            padding-left: 15px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p25 {
            text-align: left;
            padding-left: 14px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p26 {
            text-align: left;
            padding-left: 7px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p27 {
            text-align: left;
            padding-left: 8px;
            margin-top: 7px;
            margin-bottom: 0px;
        }

        .p28 {
            text-align: left;
            padding-left: 8px;
            margin-top: 32px;
            margin-bottom: 0px;
        }

        .p29 {
            text-align: left;
            padding-left: 10px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p30 {
            text-align: left;
            padding-left: 11px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p31 {
            text-align: center;
            padding-right: 2px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p32 {
            text-align: left;
            padding-left: 8px;
            margin-top: 38px;
            margin-bottom: 0px;
        }

        .p33 {
            text-align: left;
            padding-left: 76px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p34 {
            text-align: left;
            padding-left: 37px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p35 {
            text-align: left;
            padding-left: 23px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p36 {
            text-align: left;
            padding-left: 20px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p37 {
            text-align: left;
            padding-left: 21px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p38 {
            text-align: right;
            padding-right: 171px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p39 {
            text-align: left;
            padding-left: 8px;
            margin-top: 16px;
            margin-bottom: 0px;
        }

        .p40 {
            text-align: justify;
            padding-left: 8px;
            padding-right: 120px;
            margin-top: 15px;
            margin-bottom: 0px;
        }

        .p41 {
            text-align: left;
            padding-left: 8px;
            margin-top: 17px;
            margin-bottom: 0px;
        }

        .td0 {
            padding: 0px;
            margin: 0px;
            width: 115px;
            vertical-align: bottom;
        }

        .td1 {
            padding: 0px;
            margin: 0px;
            width: 446px;
            vertical-align: bottom;
        }

        .td2 {
            padding: 0px;
            margin: 0px;
            width: 150px;
            vertical-align: bottom;
        }

        .td3 {
            padding: 0px;
            margin: 0px;
            width: 11px;
            vertical-align: bottom;
        }

        .td4 {
            padding: 0px;
            margin: 0px;
            width: 16px;
            vertical-align: bottom;
        }

        .td5 {
            padding: 0px;
            margin: 0px;
            width: 152px;
            vertical-align: bottom;
        }

        .td6 {
            padding: 0px;
            margin: 0px;
            width: 25px;
            vertical-align: bottom;
        }

        .td7 {
            padding: 0px;
            margin: 0px;
            width: 27px;
            vertical-align: bottom;
        }

        .td8 {
            padding: 0px;
            margin: 0px;
            width: 65px;
            vertical-align: bottom;
        }

        .td9 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 149px;
            vertical-align: bottom;
        }

        .td10 {
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 11px;
            vertical-align: bottom;
        }

        .td11 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 15px;
            vertical-align: bottom;
        }

        .td12 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 24px;
            vertical-align: bottom;
        }

        .td13 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 26px;
            vertical-align: bottom;
        }

        .td14 {
            padding: 0px;
            margin: 0px;
            width: 329px;
            vertical-align: bottom;
        }

        .td15 {
            padding: 0px;
            margin: 0px;
            width: 117px;
            vertical-align: bottom;
        }

        .td16 {
            padding: 0px;
            margin: 0px;
            width: 161px;
            vertical-align: bottom;
        }

        .td17 {
            padding: 0px;
            margin: 0px;
            width: 285px;
            vertical-align: bottom;
        }

        .td18 {
            padding: 0px;
            margin: 0px;
            width: 381px;
            vertical-align: bottom;
        }

        .td19 {
            padding: 0px;
            margin: 0px;
            width: 269px;
            vertical-align: bottom;
        }

        .td20 {
            padding: 0px;
            margin: 0px;
            width: 561px;
            vertical-align: bottom;
        }

        .td21 {
            padding: 0px;
            margin: 0px;
            width: 124px;
            vertical-align: bottom;
        }

        .td22 {
            padding: 0px;
            margin: 0px;
            width: 409px;
            vertical-align: bottom;
        }

        .td23 {
            padding: 0px;
            margin: 0px;
            width: 297px;
            vertical-align: bottom;
        }

        .td24 {
            padding: 0px;
            margin: 0px;
            width: 211px;
            vertical-align: bottom;
        }

        .td25 {
            padding: 0px;
            margin: 0px;
            width: 107px;
            vertical-align: bottom;
        }

        .td26 {
            padding: 0px;
            margin: 0px;
            width: 205px;
            vertical-align: bottom;
        }

        .td27 {
            padding: 0px;
            margin: 0px;
            width: 92px;
            vertical-align: bottom;
        }

        .td28 {
            padding: 0px;
            margin: 0px;
            width: 508px;
            vertical-align: bottom;
        }

        .td29 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 149px;
            vertical-align: bottom;
        }

        .td30 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 56px;
            vertical-align: bottom;
        }

        .td31 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 92px;
            vertical-align: bottom;
        }

        .td32 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 148px;
            vertical-align: bottom;
        }

        .td33 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 63px;
            vertical-align: bottom;
        }

        .td34 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 107px;
            vertical-align: bottom;
        }

        .td35 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 147px;
            vertical-align: bottom;
        }

        .td36 {
            padding: 0px;
            margin: 0px;
            width: 56px;
            vertical-align: bottom;
        }

        .td37 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 91px;
            vertical-align: bottom;
        }

        .td38 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 147px;
            vertical-align: bottom;
        }

        .td39 {
            padding: 0px;
            margin: 0px;
            width: 63px;
            vertical-align: bottom;
        }

        .td40 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 106px;
            vertical-align: bottom;
        }

        .td41 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 147px;
            vertical-align: bottom;
        }

        .td42 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 91px;
            vertical-align: bottom;
        }

        .td43 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 147px;
            vertical-align: bottom;
        }

        .td44 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 106px;
            vertical-align: bottom;
        }

        .td45 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 137px;
            vertical-align: bottom;
        }

        .td46 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 119px;
            vertical-align: bottom;
        }

        .td47 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 77px;
            vertical-align: bottom;
        }

        .td48 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 191px;
            vertical-align: bottom;
        }

        .td49 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 83px;
            vertical-align: bottom;
        }

        .td50 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 137px;
            vertical-align: bottom;
        }

        .td51 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 119px;
            vertical-align: bottom;
        }

        .td52 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 77px;
            vertical-align: bottom;
        }

        .td53 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 191px;
            vertical-align: bottom;
        }

        .td54 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 83px;
            vertical-align: bottom;
        }

        .td55 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 137px;
            vertical-align: bottom;
        }

        .td56 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 119px;
            vertical-align: bottom;
        }

        .td57 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 77px;
            vertical-align: bottom;
        }

        .td58 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 191px;
            vertical-align: bottom;
        }

        .td59 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 83px;
            vertical-align: bottom;
        }

        .td60 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 187px;
            vertical-align: bottom;
        }

        .td61 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 59px;
            vertical-align: bottom;
        }

        .td62 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 95px;
            vertical-align: bottom;
        }

        .td63 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 187px;
            vertical-align: bottom;
        }

        .td64 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 59px;
            vertical-align: bottom;
        }

        .td65 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 95px;
            vertical-align: bottom;
        }

        .td66 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 187px;
            vertical-align: bottom;
        }

        .td67 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 59px;
            vertical-align: bottom;
        }

        .td68 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 95px;
            vertical-align: bottom;
        }

        .td69 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 190px;
            vertical-align: bottom;
        }

        .td70 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 195px;
            vertical-align: bottom;
        }

        .td71 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 124px;
            vertical-align: bottom;
        }

        .td72 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 137px;
            vertical-align: bottom;
        }

        .td73 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 190px;
            vertical-align: bottom;
        }

        .td74 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 195px;
            vertical-align: bottom;
        }

        .td75 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 124px;
            vertical-align: bottom;
        }

        .td76 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 137px;
            vertical-align: bottom;
        }

        .td77 {
            border-left: #000000 1px solid;
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 190px;
            vertical-align: bottom;
        }

        .td78 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 195px;
            vertical-align: bottom;
        }

        .td79 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 124px;
            vertical-align: bottom;
        }

        .td80 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 137px;
            vertical-align: bottom;
        }

        .tr0 {
            height: 23px;
        }

        .tr1 {
            height: 32px;
        }

        .tr2 {
            height: 29px;
        }

        .tr3 {
            height: 20px;
        }

        .tr4 {
            height: 18px;
        }

        .tr5 {
            height: 33px;
        }

        .tr6 {
            height: 41px;
        }

        .tr7 {
            height: 65px;
        }

        .tr8 {
            height: 31px;
        }

        .tr9 {
            height: 49px;
        }

        .tr10 {
            height: 19px;
        }

        .tr11 {
            height: 24px;
        }

        .tr12 {
            height: 7px;
        }

        .tr13 {
            height: 6px;
        }

        .tr14 {
            height: 17px;
        }

        .tr15 {
            height: 15px;
        }

        .tr16 {
            height: 16px;
        }

        .tr17 {
            height: 14px;
        }

        .tr18 {
            height: 47px;
        }

        .tr19 {
            height: 48px;
        }

        .t0 {
            width: 561px;
            margin-top: 34px;
            font: 13px 'Century Gothic';
        }

        .t1 {
            width: 533px;
            margin-left: 8px;
            margin-top: 16px;
            font: 13px 'Century Gothic';
        }

        .t2 {
            width: 800px;
            margin-top: 28px;
            font: bold 13px 'Century Gothic';
        }

        .t3 {
            width: 780px;
            margin-left: 2px;
            margin-top: 4px;
            font: bold 13px 'Century Gothic';
        }

        .t4 {
            width: 800px;
            margin-top: 4px;
            font: bold 13px 'Century Gothic';
        }

        .t5 {
            width: 800px;
            font: bold 13px 'Century Gothic';
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: white">

        <div>
            <table cellpadding="5" cellspacing="3" style="padding: 20px">
                <tr>
                    <td>Employee Code/Name
                    </td>

                    <td>
                        <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                    </td>

                    <td>
                        <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Get Details" OnClick="btnSubmit_Click" OnClientClick="return ValidateEmpcode();" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnprint" runat="server" CssClass="btn btn-info pull-right " Text="Print" OnClick="btnprint_Click" OnClientClick="return ValidateEmpcode();" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="pnl1" runat="server">
            <div id="page_1" runat="server">
                <div>
                    <img src="../upload/logo/client-logo.png" style="float: right;">
                </div>


                <div class="dclr"></div>
                <p align="center" style="font: bold 16px 'Century Gothic'; text-decoration: underline; line-height: 19px;">PERSONAL INFORMATION FORM</p>
                <table cellpadding="0" cellspacing="0" style="width: 100%" class="ft1">

                    <tr>
                        <td>
                            <p>Name in Full</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td colspan="7" style="border-bottom: 1px solid  #808080">
                            <p>
                                &nbsp;&nbsp;<asp:Label Style="border: none" ID="txtfirstname" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td >
                            <p >&nbsp;</p>
                        </td>
                        <td >
                            <p >&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td >
                            <p>&nbsp;</p>
                        </td>
                        <td >
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <p>Gender </p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td>
                            <asp:CheckBox Text="Male" ID="ck" runat="server" Width="100px" />
                        </td>
                        <td></td>

                        <td>
                            <asp:CheckBox ID="CheckBox1" Text="Female" runat="server" Width="100px" />
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>

                    </tr>
                    <tr>
                        <td>
                            <p>Date of Birth</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td colspan="3" style="border-bottom: 1px solid  #808080">
                            <p>(Day) &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_day" runat="server" Text="" Font-Bold="true" Width="50px"></asp:Label>/ (Month)&nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_month" runat="server" Text="" Font-Bold="true" Width="50px"></asp:Label>/ (Year) &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_year" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Blood Group</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td colspan="1" style="border-bottom: 1px solid  #808080">
                            <p>
                                <asp:Label Style="border: none" ID="txtbloodgrp" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>
                                <%-- RH type: Positive
                            <input type="checkbox" runat="server" id="ckbldtype" groupname="blood" />
                                Negative
                                <input type="checkbox" runat="server" id="Checkbox2" groupname="blood" />--%>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Nationality</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td colspan="1" style="border-bottom: 1px solid  #808080">
                            <%--<p><asp:Label Style="border: none" ID="Label7" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>( Country) &nbsp;&nbsp;<asp:Label Style="border: none" ID="Label8" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>(State)</p>--%>
                            <asp:TextBox ID="TextBox3" runat="server" Style="border: none; height: 30px;"></asp:TextBox>
                        </td>
                        <td>
                            <p style="text-align: center">(Country)</p>
                        </td>
                        <td colspan="1" style="border-bottom: 1px solid  #808080">
                            <%--<p><asp:Label Style="border: none" ID="Label7" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>( Country) &nbsp;&nbsp;<asp:Label Style="border: none" ID="Label8" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>(State)</p>--%>
                            <asp:TextBox ID="TextBox4" runat="server" Style="border: none; height: 30px;"></asp:TextBox>
                        </td>
                        <td>
                            <p style="text-align: center">(State)</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Father’s Name</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td colspan="1" style="border-bottom: 1px solid  #808080">
                            <p>
                                <asp:Label Style="border: none" ID="txt_f_f_name" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p style="text-align: center">&nbsp;&nbsp;DOB & Age</p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <asp:TextBox ID="TextBox6" runat="server" Style="border: none; height: 30px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Mother Name</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td colspan="1" style="border-bottom: 1px solid  #808080">
                            <p>
                                <asp:Label Style="border: none" ID="txt_m_fname" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p style="text-align: center">DOB & Age</p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <asp:TextBox ID="TextBox5" runat="server" Style="border: none; height: 30px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Marital Status</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <p>
                                <asp:Label Style="border: none" ID="ddlpersonalstatus" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p style="text-align: center">Date of Marriage </p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <p>
                                <asp:Label Style="border: none" ID="txt_doa" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <%--  <tr>
                        <td>
                            <p>If Married,</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                        <td>
                            <p>&nbsp;</p>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <p>Spouse Name(If Married)</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <p>
                                <asp:Label Style="border: none" ID="txt_sp_fname" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>

                            </p>
                        </td>
                        <td>
                            <p style="text-align: center">
                                DOB & Age
                            </p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <p>
                                <asp:Label Style="border: none" ID="txt_sp_dob" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <p>Children</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>

                        <td colspan="3">
                            <asp:GridView ID="grid_child" runat="Server" Width="100%" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                HorizontalAlign="Left" CellPadding="4" EmptyDataText="No Data Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="Child Name" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label Style="border: none" ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gender" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label Style="border: none" ID="Labelgender" runat="Server" Text='<%# Eval("gender") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label Style="border: none" ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                            </asp:GridView>
                        </td>
                    </tr>

                    <tr>
                        <td>&nbsp;&nbsp;</td>
                    </tr>

                    <tr>
                        <td>
                            <p>Present Address</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>

                        <td colspan="3">
                            <asp:Label Style="border: none" ID="txt_pre_add1" TextMode="MultiLine" runat="server" Text="" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td></td>
                        <td></td>
                        <td style="border-bottom: 1px solid  #808080">City                    
                             <asp:TextBox ID="TextBox9" runat="server" Style="border: none; height: 30px; width: 130px;"></asp:TextBox>
                        </td>

                        <td style="border-bottom: 1px solid  #808080">Pin Code              
                             <asp:TextBox ID="TextBox7" runat="server" Style="border: none; height: 30px; width: 130px;"></asp:TextBox>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">Telephone No            
                             <asp:TextBox ID="TextBox8" runat="server" Style="border: none; height: 30px; width: 100px;"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <p>Permanent Address</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td colspan="3">
                            <p>
                                <asp:Label Style="border: none" ID="txt_per_add" runat="server" Text="" Font-Bold="true"></asp:Label></p>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td style="border-bottom: 1px solid  #808080">City                    
                             <asp:TextBox ID="TextBox10" runat="server" Style="border: none; height: 30px; width: 130px;"></asp:TextBox>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">Pin Code              
                             <asp:TextBox ID="TextBox11" runat="server" Style="border: none; height: 30px; width: 130px;"></asp:TextBox>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">Telephone No            
                             <asp:TextBox ID="TextBox12" runat="server" Style="border: none; height: 30px; width: 100px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Primary Contact Number (Mobile)</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <asp:Label Style="border: none" ID="txtmobileno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <p>Secondary contact Number ( Landline /Mobile )</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <asp:Label Style="border: none" ID="txtlandno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <p>E-mail</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <asp:Label Style="border: none" ID="txt_email" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <p>Permanent Account Number (PAN)*</p>
                        </td>
                        <td>
                            <p><b>:&nbsp;&nbsp;</b></p>
                        </td>
                        <td style="border-bottom: 1px solid  #808080">
                            <asp:Label Style="border: none" ID="panno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                        </td>
                    </tr>

                  
                </table>

                <div class="dclr"></div>
                
                <p class="p15 ft1"><u><b>Passport details</b></u></p>
                <p class="p15 ft1">Passport Number: &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_passportno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                <p class="p15 ft1">Place of Issue :&nbsp;&nbsp;<asp:TextBox Style="border: none" ID="placeissue" runat="server" Text="" Font-Bold="true" Width="200px"></asp:TextBox></p>
                <p class="p15 ft1">Date of Issue : &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_passportissueddate" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                <p class="p15 ft1">Date of Expiry : &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_passportexpdate" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                <p class="p15 ft1">Emergency Contact Details:</p>
                <table cellpadding="0" cellspacing="0" class="t3" border="1">
                    <tr>
                        <td colspan="4">
                            <div class="widget-content">
                                <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                    AutoGenerateColumns="False" AllowSorting="True" Style="border-top: 1px solid #e0e0e0"
                                    CaptionAlign="Left" DataKeyNames="emg_name" HorizontalAlign="Left" BorderWidth="0px">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Emg. Contact Name">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("emg_name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emg. Contact Relation">
                                            <ItemTemplate>
                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("emg_relation") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emg. Contact No. ">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("emg_contactno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emg. LandLine No.">
                                            <ItemTemplate>
                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("emg_landlineno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
                <p class="p15 ft1" style="display: none">Languages Known: (Tick whichever applicable)</p>
                <table style="display: none" class="t3">

                    <tr>
                        <td class="tr4 td35">
                            <p class="p20 ft5">Language</p>
                        </td>
                        <td class="tr4 td36">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td37">
                            <p class="p1 ft5">Read</p>
                        </td>
                        <td class="tr4 td38">
                            <p class="p21 ft5">Write</p>
                        </td>
                        <td class="tr4 td39">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td40">
                            <p class="p1 ft5">Speak</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr13 td41">
                            <p class="p1 ft6">&nbsp;</p>
                        </td>
                        <td class="tr13 td30">
                            <p class="p1 ft6">&nbsp;</p>
                        </td>
                        <td class="tr13 td42">
                            <p class="p1 ft6">&nbsp;</p>
                        </td>
                        <td class="tr13 td43">
                            <p class="p1 ft6">&nbsp;</p>
                        </td>
                        <td class="tr13 td33">
                            <p class="p1 ft6">&nbsp;</p>
                        </td>
                        <td class="tr13 td44">
                            <p class="p1 ft6">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr11 td41">
                            <p class="p1 ft2"></p>
                        </td>
                        <td class="tr11 td30">
                            <p class="p1 ft2"></p>
                        </td>
                        <td class="tr11 td42">
                            <p class="p1 ft2"></p>
                        </td>
                        <td class="tr11 td43">
                            <p class="p1 ft2"></p>
                        </td>
                        <td class="tr11 td33">
                            <p class="p1 ft2"></p>
                        </td>
                        <td class="tr11 td44">
                            <p class="p1 ft2"></p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr11 td41">
                            <p class="p1 ft2"></p>
                        </td>
                        <td class="tr11 td30">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td42">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td43">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td33">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td44">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr11 td41">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td30">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td42">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td43">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td33">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td44">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr11 td41">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td30">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td42">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td43">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td33">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td44">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr11 td41">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td30">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td42">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td43">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td33">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr11 td44">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                </table>
                <p class="p15 ft1">Educational Qualifications:</p>
                <table cellpadding="0" cellspacing="0" class="t3" style="display: none">
                    <tr>
                        <td class="tr3 td45">
                            <p class="p22 ft5">Qualification</p>
                        </td>
                        <td class="tr3 td46">
                            <p class="p23 ft5">Course/</p>
                        </td>
                        <td class="tr3 td47">
                            <p class="p24 ft5">Year of</p>
                        </td>
                        <td class="tr3 td48">
                            <p class="p2 ft5">Institution /University</p>
                        </td>
                        <td class="tr3 td49">
                            <p class="p23 ft5">Percentag</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr14 td50">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr14 td51">
                            <p class="p23 ft7">Specialisation</p>
                        </td>
                        <td class="tr14 td52">
                            <p class="p25 ft5">Passing</p>
                        </td>
                        <td class="tr14 td53">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr14 td54">
                            <p class="p23 ft5">e</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td55">
                            <p class="p26 ft1">X Std.</p>
                        </td>
                        <td class="tr4 td56">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td58">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr15 td50">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td51">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td52">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td53">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td54">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr16 td55">
                            <p class="p26 ft9">10+2 /</p>
                        </td>
                        <td class="tr16 td56">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr16 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr16 td58">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr16 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr16 td50">
                            <p class="p26 ft9">Intermediate</p>
                        </td>
                        <td class="tr16 td51">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr16 td52">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr16 td53">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr16 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td55">
                            <p class="p26 ft1">Graduation</p>
                        </td>
                        <td class="tr4 td56">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td58">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr17 td50">
                            <p class="p1 ft10">&nbsp;</p>
                        </td>
                        <td class="tr17 td51">
                            <p class="p1 ft10">&nbsp;</p>
                        </td>
                        <td class="tr17 td52">
                            <p class="p1 ft10">&nbsp;</p>
                        </td>
                        <td class="tr17 td53">
                            <p class="p1 ft10">&nbsp;</p>
                        </td>
                        <td class="tr17 td54">
                            <p class="p1 ft10">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr10 td55">
                            <p class="p26 ft1">Post Graduation</p>
                        </td>
                        <td class="tr10 td56">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr10 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr10 td58">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr10 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td50">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td51">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td52">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td53">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td55">
                            <p class="p26 ft1">Others</p>
                        </td>
                        <td class="tr4 td56">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td58">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr15 td50">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td51">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td52">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td53">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                        <td class="tr15 td54">
                            <p class="p1 ft8">&nbsp;</p>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" class="t3" border="1">
                    <tr>
                        <td colspan="4">
                            <div class="widget-content">
                                <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                    AutoGenerateColumns="False" AllowSorting="True"
                                    CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left" BorderWidth="0px">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Education">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Specialization">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="School / Institute / University Name">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade / %">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Year">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>&nbsp;-&nbsp;<asp:Label Style="border: none"
                                                    ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
                <p class="p15 ft1">Professional Qualification :</p>

                <table cellpadding="0" cellspacing="0" class="t3" border="1">
                    <tr>
                        <td colspan="4">
                            <div class="widget-content">
                                <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                    HorizontalAlign="Left" CellPadding="4" BorderWidth="0px">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Education" HeaderStyle-Width="21%">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Specialization" HeaderStyle-Width="21%">
                                            <ItemTemplate>
                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Institute / University Name" HeaderStyle-Width="30%">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade / %" HeaderStyle-Width="13%">
                                            <ItemTemplate>
                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="13%">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>

                <div class="dclr"></div>
                <p class="p11 ft1">List the technical Skills that qualify you for this job:</p>
                <p class="p27 ft1">
                    <asp:TextBox ID="txt" runat="server" TextMode="MultiLine" Rows="10" Columns="50" Style="border: none"></asp:TextBox>
                </p>
                <p class="p28 ft1">Previous Employment details: (Start with the most recent employment)</p>
                <table cellpadding="0" cellspacing="0" class="t4" style="display: none">
                    <tr>
                        <td class="tr3 td60">
                            <p class="p18 ft5">Name and Address of the</p>
                        </td>
                        <td class="tr3 td61">
                            <p class="p24 ft5">Start</p>
                        </td>
                        <td class="tr3 td47">
                            <p class="p23 ft7">Relieving</p>
                        </td>
                        <td class="tr3 td61">
                            <p class="p29 ft5">No. of</p>
                        </td>
                        <td class="tr3 td62">
                            <p class="p23 ft7">Last</p>
                        </td>
                        <td class="tr3 td49">
                            <p class="p23 ft7">Last drawn</p>
                        </td>
                        <td class="tr3 td49">
                            <p class="p23 ft5">Reason for</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr16 td63">
                            <p class="p18 ft5">Company</p>
                        </td>
                        <td class="tr16 td64">
                            <p class="p25 ft5">Date</p>
                        </td>
                        <td class="tr16 td57">
                            <p class="p23 ft5">Date</p>
                        </td>
                        <td class="tr16 td64">
                            <p class="p30 ft5">Years</p>
                        </td>
                        <td class="tr16 td65">
                            <p class="p23 ft7">Designation</p>
                        </td>
                        <td class="tr16 td59">
                            <p class="p23 ft7">Salary</p>
                        </td>
                        <td class="tr16 td59">
                            <p class="p23 ft7">leaving</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr14 td66">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr14 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr14 td52">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr14 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr14 td68">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr14 td54">
                            <p class="p31 ft5">(P.A )</p>
                        </td>
                        <td class="tr14 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td63">
                            <p class="p18 ft1">1.</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td65">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr18 td66">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td52">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td68">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td63">
                            <p class="p18 ft1">2.</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td65">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr19 td66">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td52">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td68">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td63">
                            <p class="p18 ft1">3.</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td65">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr18 td66">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td52">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td68">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr18 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr4 td63">
                            <p class="p18 ft1">4.</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td57">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td64">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td65">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr4 td59">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr19 td66">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td52">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td67">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td68">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                        <td class="tr19 td54">
                            <p class="p1 ft2">&nbsp;</p>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" class="t4">
                    <tr>
                        <td colspan="4">
                            <div class="widget-content">
                                <asp:GridView ID="grid_exp" runat="Server" Width="100%" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left"
                                    HorizontalAlign="Left" CellPadding="4">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Company Name" HeaderStyle-Width="18%">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address / Location" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <%-- <asp:Label style="border:none"  ID="lblstartdate" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reliving Date" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <%-- <asp:Label style="border:none"  ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Exp." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Labewdl48" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Designation" HeaderStyle-Width="18%">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:Label Style="border: none" ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label Style="border: none" ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Drawn Salary(P.A)" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <%-- <asp:Label style="border:none"  ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason for Leaving" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <%-- <asp:Label style="border:none"  ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>

                </table>
                <p class="p32 ft1">Professional references:</p>
                <table cellpadding="0" cellspacing="0" class="t5" border="1">
                    <thead>
                        <tr>
                            <td class="tr16 td69">
                                <p class="p33 ft5">Name</p>
                            </td>
                            <td class="tr16 td70">
                                <p class="p34 ft5">Address , mail id & Telephone No</p>
                            </td>
                            <td class="tr16 td71">
                                <p class="p35 ft5">Occupation</p>
                            </td>
                            <td class="tr16 td72">
                                <p class="p36 ft5">No. Of years of Acquaintance</p>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="tr4 td73">
                                <p class="p38 ft1">1.</p>
                            </td>
                            <td class="tr4 td74">
                                <p class="p1 ft2">&nbsp;</p>
                            </td>
                            <td class="tr4 td75">
                                <p class="p1 ft2">&nbsp;</p>
                            </td>
                            <td class="tr4 td76">
                                <p class="p1 ft2">&nbsp;</p>
                            </td>
                        </tr>

                        <tr>
                            <td class="tr4 td73">
                                <p class="p38 ft1">2.</p>
                            </td>
                            <td class="tr4 td74">
                                <p class="p1 ft2">&nbsp;</p>
                            </td>
                            <td class="tr4 td75">
                                <p class="p1 ft2">&nbsp;</p>
                            </td>
                            <td class="tr4 td76">
                                <p class="p1 ft2">&nbsp;</p>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <p class="p12 ft1">
                    Are you related to any employee at AB Mauri : Yes/No
                    <asp:TextBox ID="tt" runat="server" Style="border: none"></asp:TextBox>
                </p>
                <p class="p39 ft1">
                    If Yes, Name:
                    <asp:TextBox ID="TextBox1" runat="server" Style="border: none"></asp:TextBox>
                    Relationship:<asp:TextBox ID="TextBox2" runat="server" Style="border: none"></asp:TextBox>
                </p>
                <p class="p40 ft1">I do hereby declare that the information furnished as above by me is true and correct to the best of my knowledge and belief. If any information furnished by me is proved to be incorrect and false, the management may take appropriate action against me including termination of my employment.</p>
                <br />
                <br />
                <p class="p14 ft11">Signature of the candidate</p>
                <br />
                <br />
                <p class="p41 ft1">
                    <span class="ft12">Date of Joining: </span>
                    <asp:Label ID="lbldoj" runat="server" Font-Bold="true"></asp:Label>
                </p>

                <br />
                <br />

                <br />
                <br />

                <br />
                <br />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
