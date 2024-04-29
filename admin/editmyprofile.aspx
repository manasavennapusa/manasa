<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editmyprofile.aspx.cs" Inherits="admin_editmyprofile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <style type="text/css">
        .star {
        color:red;
        }
        .auto-style1 {
            border-left: 1px solid #d9d9d9;
            border-top: 1px solid #d9d9d9;
            background: #fafafa;
            padding: 9px;
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #555;
            width: 46%;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>ctc
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <script type="text/javascript">

            function checkNum() {

                if ((event.keyCode > 64 && event.keyCode < 91) || (event.keyCode > 96 && event.keyCode < 123) || event.keyCode == 8)
                    return true;
                else {

                    return false;
                }

            }
            function IsNumeric(eventObj) {

                var keycode;

                if (eventObj.keyCode) //For IE
                    keycode = eventObj.keyCode;
                else if (eventObj.Which)
                    keycode = eventObj.Which;  // For FireFox
                else
                    keycode = eventObj.charCode; // Other Browser

                if (keycode != 8) //if the key is the backspace key
                {
                    if (keycode < 48 || keycode > 57) //if not a number
                        return false; // disable key press
                    else
                        return true; // enable key press
                }
            }
            function enterdate(event) {
                if (event.keyCode >= 8 && event.keyCode <= 222)
                    return false;
                else {

                    return true;
                }
            }
        </script>

        <script type="text/javascript" lang="javascript">
            function ValidateTraining() {

                var program = document.getElementById('<%=txt_TrProgram.ClientID %>');
                var conductedby = document.getElementById('<%=txt_TrConductedBy.ClientID %>');
                var fromdate = document.getElementById('<%=txtFromdate.ClientID %>');
                var todate = document.getElementById('<%=txtToDate.ClientID %>');
                var remarks = document.getElementById('<%=txtTrRemarks.ClientID %>');

                if ((IsEmpty(program))) {
                    program.focus();
                    alert("Please enter Training Name from Training Details.");
                    return false;
                }

                if ((IsEmpty(conductedby))) {
                    conductedby.focus();
                    alert("Please enter Conducted By from Training Details.");
                    return false;
                }
                if ((IsEmpty(fromdate))) {
                    fromdate.focus();
                    alert("Please enter From Date from Training Details.");
                    return false;
                }

                if ((IsEmpty(todate))) {
                    todate.focus();
                    alert("Please enter To Date from Training Details.");
                    return false;
                }
                if (fromyear.value < '1900' || fromyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (toyear.value < '1900' || toyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if ((IsEmpty(remarks))) {
                    remarks.focus();
                    alert("Please enter Remarks from Training Details.");
                    return false;
                }
                if (validateEmphistorydate(fromdate, todate, 'T') == true)
                    return true;
                else
                    return false;
                return true;
            }
        </script>
        <script type="text/javascript">

            function ValidatePersonalDetails() {
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                var paymentmode = document.getElementById('<%=rbtnbank.ClientID %>');
                var martialstatus = document.getElementById('<%=ddlpersonalstatus.ClientID %>');

                var dob = document.getElementById('<%=txt_DOB.ClientID %>');
                var EmpDateofJoin = document.getElementById('<%=doj.ClientID %>');

                var passfrmdate = document.getElementById('<%=txt_passportissueddate.ClientID %>');
                var passtodate = document.getElementById('<%=txt_passportexpdate.ClientID %>');

                var dlfrmdate = document.getElementById('<%=txt_dr_iss_date.ClientID %>');
                var dltodate = document.getElementById('<%=txt_dr_exp_date.ClientID %>');

                var spousedob, spousedoa;

                //if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {

                spousedob = document.getElementById('<%=txt_s_DOB.ClientID %>');
                spousedoa = document.getElementById('<%=txt_doa.ClientID %>');
                //}


                if (!(validateEmphistorydate(dob, EmpDateofJoin, 'DOB')))
                    return false;

                if (!(validateEmphistorydate(passfrmdate, passtodate, 'P')))
                    return false;

                if (!(validateEmphistorydate(dlfrmdate, dltodate, 'D')))
                    return false;

                if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {

                    spousedob = document.getElementById('<%=txt_s_DOB.ClientID %>');
                    spousedoa = document.getElementById('<%=txt_doa.ClientID %>');
                }

                if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {
                    if (!(validateEmphistorydate(spousedob, spousedoa, 'S')))
                        return false;
                }


                return true;
            }
        </script>
        <script type="text/javascript">
            function ValidateProp() {

                return true;
            }
        </script>
        <script type="text/javascript">
            function ValidateProfessional() {
                var education = document.getElementById('<%=txteduc1.ClientID %>');
                var specilization = document.getElementById('<%=txtpro_specilazation.ClientID %>');
                var inistitute = document.getElementById('<%=txtsch1.ClientID %>');
                var fromyear = document.getElementById('<%=txtfrm1.ClientID %>');
                var toyear = document.getElementById('<%=txtto1.ClientID %>');
                var grade = document.getElementById('<%=txtper1.ClientID %>');

                if (education.value == 0) {
                    education.focus();
                    alert("Please select education from Professional Qualification");
                    return false;
                }

                if ((IsEmpty(specilization))) {
                    specilization.focus();
                    alert("Please enter specialization from Professional Qualification.");
                    return false;
                }

                if ((IsEmpty(inistitute))) {
                    inistitute.focus();
                    alert("Please enter Institute / University Name from  Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(grade))) {
                    grade.focus();
                    alert("Please enter Grade/% from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(fromyear))) {
                    fromyear.focus();
                    alert("Please enter From Year from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(toyear))) {
                    toyear.focus();
                    alert("Please enter To Year from Professional Qualification.");
                    return false;
                }
                if (fromyear.value < '1900' || fromyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (toyear.value < '1900' || toyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (fromyear.value != '' && toyear.value != '')
                    if (fromyear.value > toyear.value) {
                        fromyear.focus();
                        alert("To-Year should be greaterthan or equal to From-Year in  Professional Qualification");
                        return false;
                    }

                return true;
            }
        </script>
        <script type="text/javascript">

            function ValidateCompany() {
                var companyname = document.getElementById('<%=txtcomp1.ClientID %>');
                var location = document.getElementById('<%=txt_com_local.ClientID %>');
                var desingation = document.getElementById('<%=txt_EXp_designation.ClientID %>');
                var fromyear = document.getElementById('<%=txt_exp_from.ClientID %>');
                var toyear = document.getElementById('<%=txt_exp_to.ClientID %>');
                var experince = document.getElementById('<%=txt_total_exp.ClientID %>');

                if ((IsEmpty(companyname))) {
                    companyname.focus();
                    alert("Please enter Company Name from Experience Details.");
                    return false;
                }

                if ((IsEmpty(location))) {
                    location.focus();
                    alert("Please enter Address/Location from Experience Details.");
                    return false;
                }

                if ((IsEmpty(desingation))) {
                    desingation.focus();
                    alert("Please enter desingation from Experience Details.");
                    return false;
                }
                if ((IsEmpty(experince))) {
                    experince.focus();
                    alert("Please enter Total Exp.(in years) from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(fromyear))) {
                    fromyear.focus();
                    alert("Please enter From Year from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(toyear))) {
                    toyear.focus();
                    alert("Please enter To Year from Professional Qualification.");
                    return false;
                }
                if (fromyear.value < '1900' || fromyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (toyear.value < '1900' || toyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (fromyear.value != '' && toyear.value != '')
                    if (fromyear.value > toyear.value) {
                        fromyear.focus();
                        alert("To-Year should be greaterthan or equal to From-Year in Experience Details.");
                        return false;
                    }
                return true;
            }
        </script>
        <script type="text/javascript" lang="javascript">
            function ValidateEmg() {

                var emgname = document.getElementById('<%=txt_emergency_name.ClientID %>');
                var emgrelation = document.getElementById('<%=drp_emg_relation.ClientID %>');
                var emgphno = document.getElementById('<%=txt_emergency_contactno.ClientID %>');
                var emgccphno = document.getElementById('<%=txt_emg_ccode.ClientID %>');
                //var emglandno = document.getElementById('<%=txt_emg_landlineno.ClientID %>');
                //var emglandstdno = document.getElementById('<%=txt_emg_landlinestdcode.ClientID %>');
                var emglandccno = document.getElementById('<%=txt_emg_landcode.ClientID %>');

                if ((IsEmpty(emgname))) {
                    emgname.focus();
                    alert("Please enter Emergency Contact name from Contact Details Tab.");
                    return false;
                }

                if (emgrelation.value == 0) {
                    emgrelation.focus();
                    alert("Please enter Emergency Contact Relation from Contact Details Tab.");
                    return false;
                }

                if ((IsEmpty(emgccphno))) {
                    emgccphno.focus();
                    alert("Please enter Emergency Contact Contry Code from Contact Details Tab.");
                    return false;
                }

                if ((IsEmpty(emgphno))) {
                    emgphno.focus();
                    alert("Please enter Emergency Contact No. from Contact Details Tab.");
                    return false;
                }
                if ((IsEmpty(emglandccno))) {
                    emglandccno.focus();
                    alert("Please enter Emergency Conatct No. from Contact Details Tab.");
                    return false;
                }
                //if ((IsEmpty(emglandstdno))) {
                //    emglandstdno.focus();
                //    alert("Please enter Emergency LandLine Std. Code from Contact Details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(emglandno))) {
                //    emglandno.focus();
                //    alert("Please enter Emergency LandLine No. from Contact Details Tab.");
                //    return false;
                //}



                return true;
            }
        </script>


        <script type="text/javascript">
            function ValidateSubmitData() {

                var FName = document.getElementById('<%=txtfirstname.ClientID %>');
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                var Machinecode = document.getElementById('<%=txt_card_no.ClientID %>');


                var EmpStatus = document.getElementById('<%=drpempstatus.ClientID %>');

                var EmpDateofJoin = document.getElementById('<%=doj.ClientID %>');
                var dol, conformationdate, lblcondate;


                //var dob = document.getElementById('<%=txt_DOB.ClientID %>');
                var passfrmdate = document.getElementById('<%=txt_passportissueddate.ClientID %>');
                var passtodate = document.getElementById('<%=txt_passportexpdate.ClientID %>');

                var dlfrmdate = document.getElementById('<%=txt_dr_iss_date.ClientID %>');
                var dltodate = document.getElementById('<%=txt_dr_exp_date.ClientID %>');
                var martialstatus = document.getElementById('<%=ddlpersonalstatus.ClientID %>');

                //var empphoto = document.getElementById('<%=flphoto.ClientID %>');
                var tenthdoc = document.getElementById('<%=fu_dft1.ClientID %>');
                var twelthdoc = document.getElementById('<%=fu_dft2.ClientID %>');
                var adhar = document.getElementById('<%=fu_dft15.ClientID %>');
                var cancheck = document.getElementById('<%=fu_dft12.ClientID %>');
                var appletter = document.getElementById('<%=fu_dft13.ClientID %>');

                var preadd = document.getElementById('<%=txt_pre_add1.ClientID %>');
                var peradd = document.getElementById('<%=txt_per_add1.ClientID %>');
                var dob = document.getElementById('<%=txt_DOB.ClientID %>');
                var bldgrp = document.getElementById('<%=ddlbloodgrp.ClientID %>');
                var bankname = document.getElementById('<%=ddl_bank_name.ClientID %>');
                var bankacc = document.getElementById('<%=txt_bank_ac.ClientID %>');
                var bankbranch = document.getElementById('<%=txt_bankbrachname.ClientID %>');
                var ifsc = document.getElementById('<%=txt_ifsc.ClientID %>');
                var email = document.getElementById('<%=txt_email.ClientID %>');
                var fathername = document.getElementById('<%=txt_f_f_name.ClientID %>');
                var mothername = document.getElementById('<%=txt_m_fname.ClientID %>');

                var spousedob, spousedoa;
                //if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {
                 //   spousedob = document.getElementById('<%=txt_s_DOB.ClientID %>');
                 //   spousedoa = document.getElementById('<%=txt_doa.ClientID %>');
                //}
                //if (Salutation.value == 0) {
                //    Salutation.focus();
                //    alert("Please select title from Job Details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(FName))) {
                //    FName.focus();
                //    alert("Please enter employee name from Job Details Tab.");
                //    return false;
                //}
                //if (Gender.value == 0) {
                //    Gender.focus();
                //    alert("Please select gender from Job Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(Machinecode))) {
                //    Machinecode.focus();
                //    alert("Please enter Employee No from Job Details Tab.");
                //    return false;
                //}


                //if (businessunit.value == 0) {
                //    businessunit.focus();
                //    alert("Please select business unit from Job Details Tab.");
                //    return false;
                //}

                //if (Branch.value == 0) {
                //    Branch.focus();
                //    alert("Please select worklocation from Job Details Tab.");
                //    return false;
                //}

                //if (Department.value == 0) {
                //    Department.focus();
                //    alert("Please select department from Job Details Tab.");
                //    Department.focus();
                //    return false;
                //}
                //if ((IsEmpty(preadd))) {
                //    preadd.focus();
                //    alert("Please fill contact details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(peradd))) {
                //    peradd.focus();
                //    alert("Please fill contact details Tab.");
                //    return false;
                //}
                //if (bldgrp.value == 0) {
                //    bldgrp.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if (bankname.value == 0) {
                //    bankname.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if ((IsEmpty(dob))) {
                //    dob.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if ((IsEmpty(bankacc))) {
                //    bankacc.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if ((IsEmpty(bankbranch))) {
                //    bankbranch.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if ((IsEmpty(ifsc))) {
                //    ifsc.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if ((IsEmpty(email))) {
                //    email.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if ((IsEmpty(fathername))) {
                //    fathername.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}
                //if ((IsEmpty(mothername))) {
                //    mothername.focus();
                //    alert("Please fill all details from personal Tab.");
                //    return false;
                //}

                //if (EmpRole.value == 0) {
                //    EmpRole.focus();
                //    alert("Please select employee role from Job Details Tab.");
                //    return false;
                //}
                //if (EmpStatus.value == 0) {
                //    EmpStatus.focus();
                //    alert("Please select employee status from Job Details Tab.");
                //    return false;
                //}
               // else if (EmpStatus.value == 4) {
                 //   dol = document.getElementById('<%=txtdol.ClientID %>');
                //}
               // else if (EmpStatus.value != 3) {
               //     lblcondate = document.getElementById('<%=lblprob.ClientID%>').innerText;
                //    conformationdate = document.getElementById('<%=txt_confirmationdate.ClientID %>');
                //}

                
                //if ((IsEmpty(tenthdoc))) {
                //    tenthdoc.focus();
                //    alert("Please upload 10th pass certificate in upload document tab.");
                //    return false;
                //}
                //if ((IsEmpty(twelthdoc))) {
                //    twelthdoc.focus();
                //    alert("Please upload 12th pass certificate in upload document tab.");
                //    return false;
                //}
                //if ((IsEmpty(adhar))) {
                //    adhar.focus();
                //    alert("Please upload adhar card copy in upload document tab.");
                //    return false;
                //}
                //if ((IsEmpty(cancheck))) {
                //    cancheck.focus();
                //    alert("Please upload Copy of Signed cancelled check in upload document tab.");
                //    return false;
                //}
                //if ((IsEmpty(appletter))) {
                //    appletter.focus();
                //    alert("Please upload Relieving Letters/Appointment Letter in upload document tab.");
                //    return false;
                //}

        if (IsEmpty(EmpDateofJoin)) {
            EmpDateofJoin.focus();
            alert("Please enter date of joining from Job Detaails Tab.");
            return false;
        }


        if (lblcondate == "Probation End date") {
            if (!(validateEmphistorydate(EmpDateofJoin, conformationdate, 'Pro')))
                return false;
        }
        if (lblcondate == "Confirmation Date") {
            if (!(validateEmphistorydate(EmpDateofJoin, conformationdate, 'C')))
                return false;
        }
        if (EmpStatus.value == 4) {
            if (!(validateEmphistorydate(EmpDateofJoin, dol, 'R')))
                return false;
        }


        if (!(validateEmphistorydate(dob, EmpDateofJoin, 'DOB')))
            return false;


        var txtreportmanager = document.getElementById('<%=txtreportmanager.ClientID %>'); //Line Manager

         var dottedlinemanager = document.getElementById('<%=txtdottedlinemanager.ClientID %>');
                //Dotted Line Manager
                var txtbusinesshead = document.getElementById('<%=txtbusinesshead.ClientID %>'); //Business Head
                var txtfncmang = document.getElementById('<%=txtfncmang.ClientID %>'); //Account Manager

                var txtadmin = document.getElementById('<%=txtadmin.ClientID %>');  //Admin
                var txthr = document.getElementById('<%=txthr.ClientID %>');        //HR TA
                var hrcb = document.getElementById('<%=txthrcb.ClientID %>');                                                                    // HR-C&B
                var txthrd = document.getElementById('<%=txthrd.ClientID %>');      //HR-BP

                var txtmng = document.getElementById('<%=txtmng.ClientID %>');               //Management/MD

                var txtdeptclr = document.getElementById('<%=txtdeptclr.ClientID %>');       //Departmental Clearance
                var txtadminclr = document.getElementById('<%=txtadminclr.ClientID %>');     //General Administration Clearance
                var txtaccdeptclr = document.getElementById('<%=txtaccdeptclr.ClientID %>'); //Accounts Department Clearance
                var txtnetworkclr = document.getElementById('<%=txtnetworkclr.ClientID %>'); //Network Administration Clearance
                var txthrdeptclr = document.getElementById('<%=txthrdeptclr.ClientID %>');   //HR Department Clearance
                var txtaccdeleclr = document.getElementById('<%=txtaccdeleclr.ClientID %>'); // User Account Deletion Request

                //if ((IsEmpty(txtreportmanager))) {
                //    txtreportmanager.focus();
                //    alert("Please enter Reporting Manager from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txtbusinesshead))) {
                //    txtbusinesshead.focus();
                //    alert("Please enter Business Head from Approver's Details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(txtadmin))) {
                //    txtadmin.focus();
                //    alert("Please enter Admin from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txthr))) {
                //    txthr.focus();
                //    alert("Please enter  HR Manager from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txthrd))) {
                //    txthrd.focus();
                //    alert("Please enter HRD Manager from Approver's Details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(txtmng))) {
                //    txtmng.focus();
                //    alert("Please enter Management/MD from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txtdeptclr))) {
                //    txtdeptclr.focus();
                //    alert("Please enter Departmental Clearance from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txtadminclr))) {
                //    txtadminclr.focus();
                //    alert("Please enter General Administartion Clearance from Approver's Details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(txtfncmang))) {
                //    txtfncmang.focus();
                //    alert("Please enter Finance Manager from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txtaccdeptclr))) {
                //    txtaccdeptclr.focus();
                //    alert("Please enter Accounts Department Clearance from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txtnetworkclr))) {
                //    txtnetworkclr.focus();
                //    alert("Please enter Network Administartion Clearance from Approver's Details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(txthrdeptclr))) {
                //    txthrdeptclr.focus();
                //    alert("Please enter HR Department Clearance from Approver's Details Tab.");
                //    return false;
                //}
                //if ((IsEmpty(txtaccdeleclr))) {
                //    txtaccdeleclr.focus();
                //    alert("Please enter User Account Deletion Request from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txtdottedlinemanager))) {
                //    txtdottedlinemanager.focus();
                //    alert("Please enter Dotted Line Manager from Approver's Details Tab.");
                //    return false;
                //}

                //if ((IsEmpty(txthrcb))) {
                //    txthrcb.focus();
                //    alert("Please enter HR C&B from Approver's Details Tab.");
                //    return false;
                //}

                return true;
            }

            function IsEmpty(aTextField) {
                if ((aTextField.value.length == 0) || (aTextField.value == null) || aTextField.value.charAt(0) == ' ') {
                    return true;
                }
                else {
                    return false;
                }
            }
        </script>
        <script type="text/javascript">


            function ValidateEducation() {
                var education = document.getElementById('<%=drp_edu_qualification.ClientID %>');
                var specilization = document.getElementById('<%=txtedu_specilazation.ClientID %>');
                var inistitute = document.getElementById('<%=txtedush.ClientID %>');
                var fromyear = document.getElementById('<%=txtedufrom.ClientID %>');
                var toyear = document.getElementById('<%=txteduto.ClientID %>');
                var grade = document.getElementById('<%=txteduper.ClientID %>');

                if (education.value == 0) {
                    education.focus();
                    alert("Please select education from Educational Qualification.");
                    return false;
                }

                if ((IsEmpty(specilization))) {
                    specilization.focus();
                    alert("Please enter specialization from Educational Qualification.");
                    return false;
                }

                if ((IsEmpty(inistitute))) {
                    inistitute.focus();
                    alert("Please enter Institute / University Name from Educational Qualification.");
                    return false;
                }
                if ((IsEmpty(grade))) {
                    grade.focus();
                    alert("Please enter Grade/% from Educational Qualification.");
                    return false;
                }
                if ((IsEmpty(fromyear))) {
                    fromyear.focus();
                    alert("Please enter From Year from Educational Qualification.");
                    return false;
                }
                if ((IsEmpty(toyear))) {
                    toyear.focus();
                    alert("Please enter To Year from Educational Qualification.");
                    return false;
                }
                if (fromyear.value < '1900' || fromyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (toyear.value < '1900' || toyear.value > '2100') {
                    alert("Enter The Valid Year");
                }

                if (fromyear.value != '' && toyear.value != '')
                    if (fromyear.value > toyear.value) {
                        fromyear.focus();
                        alert("To-Year should be greaterthan or equal to From-Year in Educational Qualification");
                        return false;
                    }

                return true;
            }
        </script>
        <script type="text/javascript">
            function validateEmphistorydate(fromdate, todate, type) {
                if ((fromdate.value.trim() != "") && (todate.value.trim() != "")) {
                    var startdate = new Date(fromdate.value.trim());
                    var enddate = new Date(todate.value.trim());
                    if (startdate < '1800' || startdate > '2200') {
                        alert("Enter The Valid Date And Year");
                    }
                    if (enddate < '1800' || enddate > '2200') {
                        alert("Enter The Valid Date And Year");
                    }
                    if (startdate > enddate) {
                        if (type == 'T') {
                            alert('From Date should be less than To Date.')
                            return false;
                        }
                        else if (type == 'P') {
                            alert('Passport Issued Date should be less than Passport Expiry  Date.')
                            return false;
                        }
                        else if (type == 'D') {
                            alert('DL Issued Date should be less than DL Expiry  Date.')
                            return false;
                        }
                        else if (type == 'S') {
                            alert('Spouse Date of Birth should be less than Spouse Date of anniversary Date.')
                            return false;
                        }
                        else if (type == 'Pro') {
                            alert('Date of Joining should be less than Probation End Date.')
                            return false;
                        }
                        else if (type == 'C') {
                            alert('Date of Joining should be less than Confirmation Date.')
                            return false;
                        }
                        else if (type == 'R') {
                            alert('Date of Joining should be less than Date of Leaving.')
                            return false;
                        }
                        else if (type == 'DOB') {
                            alert('Date of Birth should be less than Date of Joining.')
                            return false;
                        }
                    }
                    else
                        return true;
                }
                return true;
            }

        </script>

        <script type="text/javascript">
            function ValidateContact() {
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                if ((IsEmpty(Empcode))) {
                    Empcode.focus();
                    alert("Please enter employee code from Job Details Tab.");
                    return false;
                }
                return true;
                //$("#li_tabs2").find("input,button,textarea,select").prop("disabled", false);
                //$("#li_tabs3").find("input,button,textarea,select").prop("disabled", false);
                //$("#li_tabs4").find("input,button,textarea,select").attr("disabled", "disabled");
                //$("#li_tabs5").find("input,button,textarea,select").attr("disabled", "disabled");
            }
        </script>
        
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <%--<div class="navbar hidden-desktop">
                    <div class="navbar-inner">
                        <div class="container">
                            <a data-target=".navbar-responsive-collapse" data-toggle="collapse" class="btn btn-navbar">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </a>
                            <div class="nav-collapse collapse navbar-responsive-collapse">
                                <ul class="nav">
                                    <li>
                                        <a href="index.html">Dashboard</a>
                                    </li>

                                    <li>
                                        <a href="reports.html">Reports</a>
                                    </li>
                                    <li>
                                        <a href="forms.html">Basic Forms</a>
                                    </li>
                                    <li>
                                        <a href="extended-forms.html">Extended Forms</a>
                                    </li>
                                    <li>
                                        <a href="form-wizards.html">Form Wizard</a>
                                    </li>
                                    <li>
                                        <a href="graphs.html">Flot Charts</a>
                                    </li>
                                    <li>
                                        <a href="google-charts.html">Google Charts</a>
                                    </li>
                                    <li>
                                        <a href="animated-charts.html">Animated Charts</a>
                                    </li>
                                    <li>
                                        <a href="ui-elements.html">General Elements</a>
                                    </li>
                                    <li>
                                        <a href="clients-list.html">Clients List</a>
                                    </li>
                                    <li>
                                        <a href="messages.html">Messages</a>
                                    </li>
                                    <li>
                                        <a href="timeline.html">Timeline</a>
                                    </li>
                                    <li>
                                        <a href="pricing.html">Pricing Plans</a>
                                    </li>
                                    <li>
                                        <a href="grid.html">Grid Layout</a>
                                    </li>
                                    <li>
                                        <a href="icons.html">Buttons &amp; Icons</a>
                                    </li>
                                    <li>
                                        <a href="typography.html">Typography</a>
                                    </li>
                                    <li>
                                        <a href="tables.html">Static Tables</a>
                                    </li>
                                    <li>
                                        <a href="dynamic-tables.html">Dynamic Tables</a>
                                    </li>
                                    <li>
                                        <a href="gallery.html">Gallery</a>
                                    </li>
                                    <li>
                                        <a href="invoice.html">Invoice</a>
                                    </li>
                                    <li>
                                        <a href="calendar.html">Calendar</a>
                                    </li>
                                    <li>
                                        <a href="profile.html">Profile</a>
                                    </li>
                                    <li>
                                        <a href="error.html">404 Error</a>
                                    </li>
                                    <li>
                                        <a href="faq.html">Faq</a>
                                    </li>
                                    <li>
                                        <a href="login.html">Login</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>--%>

                <%--<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel5" DisplayAfter="1"
                            runat="server">
                            <ProgressTemplate>
                                <div class="modal-backdrop fade in">
                                    <div class="center">
                                        <img src="../img/loading.gif" alt="" />"
                                    Please Wait...
                                    </div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>--%>


                        <div class="page-header">
                            <div class="pull-left">
                                <h2>My Profile</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid">
                            <div class="widget">

                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>My Information	
                                    </div>
                                </div>

                                <div class="widget-body">
                                    <fieldset>

                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="50%" valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="48%">Title
                                                            </td>
                                                            <td class="frm-rght-clr123" width="52%">
                                                                <asp:Label ID="lblSalutation" runat="server" Width="142px"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td width="43%" class="frm-lft-clr123"><%--First Name--%>Employee Name
                                                            </td>
                                                            <td width="57%" class="frm-rght-clr123">
                                                                <asp:Label ID="txtfirstname" runat="server"></asp:Label>
                                                                &nbsp;
                                                              <asp:Label ID="txt_login_id" runat="server" Visible="False"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">Gender
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr1" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Middle Name
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="txtmiddlename" runat="server"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                        </tr>

                                                        <tr id="Tr2" runat="server" visible="false">
                                                            <td class="frm-lft-clr123 border-bottom">Last Name
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="txtlastname" runat="server"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                                <td valign="top">
                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="48%" class="frm-lft-clr123 ">Employee Code
                                                            </td>
                                                            <td width="51%" class="frm-rght-clr123">
                                                                <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">Employee No.
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="txt_card_no" runat="server"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="48%" class="frm-lft-clr123 border-bottom">Employee Photo
                                                            </td>
                                                            <td width="52%" class="frm-rght-clr123 border-bottom">

                                                                <asp:FileUpload ID="flphoto" runat="server" Width="260px" ToolTip="Upload File here" Enabled="false" />&nbsp;
                                                        <asp:Label ID="lblphoto" runat="server"></asp:Label><br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="fu_dft1"
                                                                    ValidationGroup="v" CssClass="txt-red" Display="Dynamic" ErrorMessage="file not supported..." ValidationExpression="^.+(.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:HiddenField ID="hdnphoto" runat="server" Value="" />


                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <td height="5" colspan="2">

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="wizard">
                                            <ol>
                                                <li>Job Detail</li>
                                                <li id="li_tabs_approver">Approver's Detail</li>
                                                <li>Contact Detail</li>
                                                <li>Professional</li>
                                                <li>Personal Detail</li>
                                              <li>Employee Upload Documents</li>
                                        <li>Upload Documents</li>
                                            </ol>
                                            <div>
                                                <p>
                                                    <!-- Job Details -->

                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>

                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="txt02">Work Information
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="50%" valign="top">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                                <tr id="Tr3" style="height: 36px;" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123"><%--Broad Group--%>Business Unit
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_broadgroup" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 36px;">
                                                                                    <td width="43%" class="frm-lft-clr123"><%--Branch Name--%>Work Location
                                                                                    </td>
                                                                                    <td width="57%" class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_branch_name" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123">Department
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_dept_name" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123">Department Type
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_dept_type" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123">Designation
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_desigination" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr4" style="height: 36px;" visible="false" runat="server">
                                                                                    <td class="frm-lft-clr123">Grade
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_grade" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr5" style="height: 36px;" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="48%"><%--Sub Department--%>Cost Center
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="lbl_division_name" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <%--<tr>
                                                                            <td class="frm-lft-clr123">Sub Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_subgroup" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>




                                                                                <%--<tr>
                                                                            <td class="frm-lft-clr123">Entity
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_entity" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>
                                                                                <tr id="Tr6" style="height: 36px;" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Grade Type
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_gradetype" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>




                                                                                <tr style="height: 36px;">
                                                                                    <td width="48%" class="frm-lft-clr123">Employee Role
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_emp_role" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>


                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Employee Status
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:Label ID="drpempstatus" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="tr7" runat="server" visible="False">
                                                                                    <td colspan="2" style="height: 5px"></td>
                                                                                </tr>
                                                                                <tr id="trprobationperiod" runat="server" visible="False" style="height: 36px;">
                                                                                    <td class="frm-lft-clr123" style="border-top: none;">Probation Period (in months)
                                                                                    </td>
                                                                                    <td id="Td1" class="frm-rght-clr123" runat="server" style="border-top: none;">
                                                                                        <asp:Label ID="txt_probationperiod" runat="server" MaxLength="2"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trduptstart" runat="server" visible="False" style="height: 36px;">
                                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Deputation Start Date
                                                                                    </td>
                                                                                    <td id="Td4" class="frm-rght-clr123 border-bottom" runat="server" style="border-top: none;">
                                                                                        <asp:Label ID="txt_deput_start_date" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="tr8" runat="server" visible="False">
                                                                                    <td colspan="2" style="height: 5px"></td>
                                                                                </tr>
                                                                                <tr id="trconforimdate" runat="server" style="height: 36px;">
                                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                                        <asp:Label ID="lblprob" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="txt_confirmationdate" runat="server" Width="120px"></asp:Label>&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>
                                                                                <tr id="trDOL" runat="server" visible="False" style="height: 36px;">
                                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Date of Leaving
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                                        <asp:Label ID="txtdol" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trReasonL" runat="server" visible="False" style="height: 36px;">
                                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Reason for Leaving
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                                        <asp:Label ID="txtreason" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123" width="48%">Date of Joining
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="51%">
                                                                                        <asp:Label ID="doj" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr9" style="height: 36px;" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Salary Calculation From
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="txtsalary" runat="server" Width="100px"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123">Official Mobile No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="txtoff_mobileno" runat="server" Width="142px" MaxLength="10"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123">Official Email Id
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="txt_officialemail" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123">Employee Type
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="txremployee_type" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123">Sub Employee Type
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="txtsubemployeetype" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 36px;">
                                                                                    <td class="frm-lft-clr123 border-bottom">Ext. Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="txtext" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>


                                                                                <tr style="height: 36px; display: none">
                                                                                    <td class="frm-lft-clr123"><%--Immediate Supervisor Name--%>Reporting Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_supervisor" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 36px; display: none">
                                                                                    <td class="frm-lft-clr123 "><%--Corporate Reporting Name--%>Functional Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:Label ID="lbl_corp_report_name" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 36px; display: none">
                                                                                    <td class="frm-lft-clr123 border-bottom"><%--Manager Name --%>Unit Head
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="lbl_hod" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>




                                                                                <%--<tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Salary Calculation From
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="txtsalary" runat="server"></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>--%>

                                                                                <tr id="trprobationdate" runat="server" visible="False" style="height: 36px;">
                                                                                    <td id="Td5" class="frm-lft-clr123" runat="server" style="border-top: none;">Notice Period During Probation (in days)
                                                                                    </td>
                                                                                    <td id="Td6" class="frm-rght-clr123" runat="server" style="border-top: none;">
                                                                                        <asp:Label ID="txt_probation_date" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trduptenddate" runat="server" visible="False" style="height: 36px;">
                                                                                    <td id="Td7" class="frm-lft-clr123 border-bottom" runat="server" style="border-top: none;">Deputation End Date
                                                                                    </td>
                                                                                    <td id="Td8" class="frm-rght-clr123 border-bottom" runat="server" style="border-top: none;">
                                                                                        <asp:Label ID="txt_deput_end_date" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trnoticepriod2" runat="server" style="height: 36px;">
                                                                                    <td class="frm-lft-clr123 border-bottom">Notice Period 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="txt_noticePeriod" runat="server" MaxLength="2"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <%-- <tr>
                                                                        <td colspan="2" height="5"></td>
                                                                    </tr>--%>


                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="15"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" visible="false">
                                                                    <tr>
                                                                        <td width="50%" valign="top">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td colspan="2" class="txt02">Cost Center
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="lbl_cc_groupid" runat="server">
                                                                                        </asp:Label>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="lbl_cc_code" runat="server">
                                                                                        </asp:Label>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trcc" runat="server" visible="false">
                                                                                    <td colspan="2">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="48%" style="border-top: none;">Country
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%" style="border-top: none;">
                                                                                                    <asp:Label ID="lbl_cc_country" runat="server" Height="20px">
                                                                                                    </asp:Label>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">State
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:Label ID="lbl_cc_state" runat="server" Height="20px">
                                                                                                    </asp:Label>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">City
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:Label ID="lbl_cc_city" runat="server" Height="20px">
                                                                                                    </asp:Label>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom">Location
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:Label ID="lbl_cc_location" runat="server"
                                                                                                        Width="147px">
                                                                                                    </asp:Label>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5"></td>
                                                                                            </tr>
                                                                                        </table>

                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                                                                <tr>
                                                                                    <td colspan="2" class="txt02">Additional Cost Center
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="51%">
                                                                                        <asp:Label ID="lbl_acc_groupid" runat="server">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="lbl_acc_code" runat="server">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="traddcc" runat="server" visible="false">
                                                                                    <td colspan="2">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="48%" style="border-top: none;">Country
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="51%" style="border-top: none;">
                                                                                                    <asp:Label ID="lbl_acc_country" runat="server" Height="20px">
                                                                                                    </asp:Label>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">State
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:Label ID="lbl_acc_state" runat="server" Height="20px">
                                                                                                    </asp:Label>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">City
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:Label ID="lbl_acc_city" runat="server" Height="20px">
                                                                                                    </asp:Label>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom">Location
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:Label ID="lbl_acc_location" runat="server" Height="20px">
                                                                                                    </asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="5" colspan="2"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="txt02">Payroll Details
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="50%" valign="top">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 " width="48%">CTC Per Annum
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123  " width="52%">
                                                                                        <asp:Label ID="ward" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td width="43%" class="frm-lft-clr123">PF Number
                                                                                    </td>
                                                                                    <td width="57%" class="frm-rght-clr123">
                                                                                        <asp:Label ID="pfno" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">PAN Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="panno" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="sss" runat="server">
                                                                                    <td class="frm-lft-clr123 border-bottom">UAN Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:Label ID="txt_ptno" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td width="48%" class="frm-lft-clr123">ESI Dispensary
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">
                                                                                        <asp:Label ID="esidesp" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 " width="48%">PF Region Office
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="pfno_dept" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">ESI Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:Label ID="esino" runat="server"></asp:Label>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </p>
                                            </div>
                                            <div>
                                                <p>
                                                    <!-- Approver Details -->
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                        <tr>
                                                            <td colspan="2" class="txt02" style="height: 25px">Approver's Information
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="2" width="100%">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="50%" valign="top">
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123" width="48%">Line Manager
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                                <asp:Label ID="txtreportmanager" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Dotted Line Manager 
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                <asp:Label ID="txtdottedlinemanager" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123" width="48%">Business Head
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                                <asp:Label ID="txtbusinesshead" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Finance Manager
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                <asp:Label ID="txtfncmang" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123  border-bottom" width="48%">Network Administration Clearance
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                                <asp:Label ID="txtnetworkclr" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>

                                                                                         <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Virtual Head
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                <asp:Label ID="txtdeptclr" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>

                                                                                    </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 " width="48%">Admin
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 " width="52%">
                                                                                        <asp:Label ID="txtadmin" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">HR-TA
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txthr" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">HR-C&B 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txthrcb" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">HR-BP  
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txthrd" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Management/MD
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:Label ID="txtmng" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="15" colspan="2"></td>
                                                        </tr>
                                                        <tr runat="server" visible="false">
                                                            <td colspan="2" class="txt02" visible="false">Clearance   Information
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr runat="server" visible="false">
                                                            <td colspan="2" width="100%">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="50%" valign="top">
                                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                                <ContentTemplate>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                       

                                                                                        <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123" width="48%">General Administration Clearance
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                                <asp:Label ID="txtadminclr" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 50px">
                                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Accounts Department Clearance
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                <asp:Label ID="txtaccdeptclr" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>


                                                                                    </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Network Administration Clearance
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txtnetworkclr1" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">HR Department Clearance
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txthrdeptclr" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">User Account Deletion Request
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:Label ID="txtaccdeleclr" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10" colspan="2"></td>
                                                        </tr>

                                                    </table>

                                                </p>
                                            </div>
                                            <div>
                                                <p>
                                                    <!-- Contact Details -->
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="li_tabs2">
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                                                                            DisplayAfter="1">
                                                                            <ProgressTemplate>
                                                                                <div class="modal-backdrop fade in">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="center" valign="top">
                                                                                                <img src="../img/loading.gif" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                        <div>
                                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                                <tr>
                                                                                    <td style="height: 34px" colspan="2" width="100%">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td colspan="2" height="5"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 50%" class="txt02">Communication Address<span class="star"></span>
                                                                                                </td>
                                                                                                <td class="txt02">&nbsp;&nbsp;Permanent Address<span class="star"></span>
                                                                                   <td>
                                                                                       <table>
                                                                                           <tr>
                                                                                               <td>
                                                                                                   <asp:CheckBox ID="CheckBox1" runat="server" Text="" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                                                                       AutoPostBack="True"></asp:CheckBox></td>
                                                                                               <td>Same as Present</td>

                                                                                           </tr>
                                                                                       </table>
                                                                                   </td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td valign="top" width="50%">
                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">Address 
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                                <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="span11" Width="" Height="60px" MaxLength="1000" placeholder="Max 1000 Chars.." Style="border: 1px solid #ddd" TextMode="MultiLine" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_pre_add1"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Communication Address" ValidationGroup="A"
                                                                                                            Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr10" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                                                <asp:TextBox ID="txt_pre_Add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr11" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Country
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_pre_country" runat="server" CssClass="span11" Width=""
                                                                                                                    AutoPostBack="true" Height="">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr12" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">State
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_pre_state" runat="server" CssClass="span11" Width=""
                                                                                                                    AutoPostBack="true" Height="">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr13" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">City
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_pre_city" runat="server" CssClass="span11" Width=""
                                                                                                                    Height="">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr14" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Zip Code
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:TextBox ID="txt_pre_zip" runat="server" CssClass="span11" Width="" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr15" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Phone No.
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:TextBox ID="txt_pre_phone" runat="server" CssClass="span11" Width="" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>


                                                                                                        <tr>
                                                                                                            <td colspan="2" height="5"></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                                <td valign="top">
                                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">Address 
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" width="54%">
                                                                                                                <asp:TextBox ID="txt_per_add1" runat="server" CssClass="span11" Width="" placeholder="Max 1000 Chars.." Height="60px" Style="border: 1px solid #ddd" TextMode="MultiLine" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt_per_add1"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Permanent Address" ValidationGroup="A"
                                                                                                            Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr16" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Address 2
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:TextBox ID="txt_per_add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr17" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Country
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_per_country" runat="server" CssClass="span11" Width=""
                                                                                                                    AutoPostBack="true">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr18" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">State
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_per_state" runat="server" CssClass="span11" Width=""
                                                                                                                    AutoPostBack="true" Height="">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr19" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">City
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_per_city" runat="server" CssClass="span11" Width=""
                                                                                                                    Height="">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr20" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Zip Code
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:TextBox ID="txt_per_zip" runat="server" CssClass="span11" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr21" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Phone No.
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:TextBox ID="txt_per_phone" runat="server" CssClass="span11" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>


                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <%-- <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="txt02">Emergency Contact Details:
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="10"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="100%" valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="50%">Name
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="50%">
                                                                                                        <asp:TextBox ID="txt_emergency_name" placeholder="Max 50 Chars.." runat="server" CssClass="span11" Width="244px" onblur="capitalizeMe(this);" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"
                                                                                                            MaxLength="50"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="45%">Relation
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">

                                                                                                        <asp:DropDownList ID="drp_emg_relation" runat="server" CssClass="span11" Width="244px">
                                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                            <asp:ListItem Value="Spouse"> Spouse</asp:ListItem>
                                                                                                            <asp:ListItem Value="Daughter">Daughter</asp:ListItem>
                                                                                                            <asp:ListItem Value="Son">Son</asp:ListItem>
                                                                                                            <asp:ListItem Value="Father">Father</asp:ListItem>
                                                                                                            <asp:ListItem Value="Mother">Mother</asp:ListItem>
                                                                                                            <asp:ListItem Value="Brother">Brother</asp:ListItem>
                                                                                                            <asp:ListItem Value="Friend">Friend</asp:ListItem>
                                                                                                            <asp:ListItem Value="Brother In law">Brother In law</asp:ListItem>
                                                                                                            <asp:ListItem Value="Sister In law">Sister In law</asp:ListItem>
                                                                                                            <asp:ListItem Value="Sister">Sister</asp:ListItem>
                                                                                                            <asp:ListItem Value="Uncle">Uncle</asp:ListItem>
                                                                                                            <asp:ListItem Value="Aunt">Aunt</asp:ListItem>
                                                                                                            <asp:ListItem Value="Neighbour">Neighbour</asp:ListItem>
                                                                                                            <asp:ListItem Value="Others">Others</asp:ListItem>

                                                                                                        </asp:DropDownList>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Contact No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                        <asp:TextBox ID="txt_emg_ccode" runat="server" Width="38px" placeholder="Max 3" MaxLength="3" Text="+91" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emergency_contactno" runat="server" CssClass="span11" Width="190px" placeholder="Max 10 Chars.."
                                                                                                            MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">LandLine No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                        <asp:TextBox ID="txt_emg_landcode" runat="server" Width="30px" placeholder="Max 3" Text="+91" MaxLength="3" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emg_landlinestdcode" runat="server" Width="50px" placeholder="Max 5 Chars.." MaxLength="5" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emg_landlineno" runat="server" CssClass="span11" Width="130px" placeholder="Max 10 Chars.."
                                                                                                            MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>

                                                                                                    <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                                        <asp:Button ID="btnemgcontact" runat="server" Text="Add" OnClick="btnemgcontact_Click" CssClass="btn btn-primary pull-right" OnClientClick="return ValidateEmg();" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr id="Tr23" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 1
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_address" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr24" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_address2" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr25" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_country" runat="server" CssClass="span11" Width=""
                                                                                                            Height="" AutoPostBack="true" >
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr26" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_state" runat="server" CssClass="span11" Width=""
                                                                                                            Height="" AutoPostBack="true" >
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr27" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr28" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123 border-bottom">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                                        <asp:TextBox ID="txt_emergency_zipcode" runat="server" MaxLength="6" CssClass="blue1"
                                                                                                            Width="" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td width="50%" valign="top"></td>
                                                                                    </tr>
                                                                                </table>--%>


                                                                                        <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td class="txt02">Emergency Contact Details:
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="10"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td width="100%" valign="top">
                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" width="50%">Name<span class="star"></span>
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="50%">
                                                                                                                <asp:TextBox ID="txt_emergency_name" placeholder="Max 50 Chars.." runat="server" CssClass="span6" Width="" onblur="capitalizeMe(this);"
                                                                                                                    MaxLength="50"></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txt_emergency_name"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Name" ValidationGroup="f"
                                                                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" width="45%">Relation<span class="star"></span>
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="55%">

                                                                                                                <asp:DropDownList ID="drp_emg_relation" runat="server" CssClass="span6">
                                                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Spouse"> Spouse</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Daughter">Daughter</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Son">Son</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Father">Father</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Mother">Mother</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Brother">Brother</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Friend">Friend</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Brother In law">Brother In law</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Sister In law">Sister In law</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Sister">Sister</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Uncle">Uncle</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Aunt">Aunt</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Neighbour">Neighbour</asp:ListItem>
                                                                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>

                                                                                                                </asp:DropDownList>
                                                                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="drp_emg_relation"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Relation" ValidationGroup="f"
                                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">Contact No.<span class="star"></span>
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                                <asp:TextBox ID="txt_emg_ccode" runat="server" Width="38px" placeholder="Max 4 Chars.." MaxLength="4" onkeypress="return IsNumeric(event);">+91</asp:TextBox>
                                                                                                                <asp:TextBox ID="txt_emergency_contactno" runat="server" CssClass="span11" Width="190px" placeholder="Max 10 Chars.."
                                                                                                                    MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txt_emergency_contactno"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Contact No." ValidationGroup="f"
                                                                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ValidationGroup="f" ControlToValidate="txt_emergency_contactno" ValidationExpression="^[0-9]{10,10}$" ToolTip="Num Length Should Be 10 " ErrorMessage='<img src="../img/error1.gif" alt="" />' Display="Dynamic"></asp:RegularExpressionValidator>--%>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">LandLine No.
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                                <asp:TextBox ID="txt_emg_landcode" runat="server" Width="30px" placeholder="Max 4 Chars.." MaxLength="4" onkeypress="return IsNumeric(event);">+91</asp:TextBox>
                                                                                                                <asp:TextBox ID="txt_emg_landlinestdcode" runat="server" Width="50px" placeholder="Max 5 Chars.." MaxLength="5" onkeypress="return IsNumeric(event);"></asp:TextBox>
                                                                                                                <asp:TextBox ID="txt_emg_landlineno" runat="server" CssClass="span11" Width="130px" placeholder="Max 10 Chars.."
                                                                                                                    MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>

                                                                                                            <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                                                <asp:Button ID="btnemgcontact" runat="server" Text="Add" OnClick="btnemgcontact_Click" CssClass="btn btn-primary pull-right"  ValidationGroup="f" />
                                                                                                                <%--OnClientClick="return ValidateEmg();"--%> 
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr id="Tr23" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123" width="45%">Address 1
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                                                <asp:TextBox ID="txt_emergency_address" runat="server" CssClass="span11" Width=""
                                                                                                                    MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr24" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                                                <asp:TextBox ID="txt_emergency_address2" runat="server" CssClass="span11" Width=""
                                                                                                                    MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr25" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Country
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_emergency_country" runat="server" CssClass="span11" Width=""
                                                                                                                    Height="" AutoPostBack="true" OnSelectedIndexChanged="ddl_emergency_country_SelectedIndexChanged">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr26" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">State
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_emergency_state" runat="server" CssClass="span11" Width=""
                                                                                                                    Height="" AutoPostBack="true">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr27" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">City
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:DropDownList ID="ddl_emergency_city" runat="server" CssClass="span11" Width=""
                                                                                                                    Height="">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr28" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123 border-bottom">Zip Code
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                                <asp:TextBox ID="txt_emergency_zipcode" runat="server" MaxLength="6" CssClass="blue1"
                                                                                                                    Width="" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td colspan="2" height="5"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="2" height="5"></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                                <td width="50%" valign="top"></td>
                                                                                            </tr>
                                                                                        </table>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="5">
                                                                                        <div class="widget-content">
                                                                                            <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                                OnRowDeleting="gvemgcontact_RowDeleting" AutoGenerateColumns="False" AllowSorting="True"
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
                                                                                                    <asp:TemplateField>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton
                                                                                                                ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="Delete"></asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                            </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" width="50%">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="50%">Mode of Transport
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="50%">
                                                                                                    <label class="radio inline">
                                                                                                        <table>
                                                                                                            <tr>
                                                                                                                <td style="width: 70px">
                                                                                                                    <asp:RadioButton ID="optown" runat="server" Text="Own" GroupName="mode" AutoPostBack="True"
                                                                                                                        OnCheckedChanged="optown_CheckedChanged" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:RadioButton ID="optcompany" runat="server" Text="Company Vehicle"
                                                                                                                        GroupName="mode" AutoPostBack="True" OnCheckedChanged="optcompany_CheckedChanged" /></td>
                                                                                                        </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">&#160;<asp:Label ID="lblpickuppoint" runat="server" Visible="true" Text="Pick Up point"></asp:Label>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="55%">&#160;<asp:TextBox ID="txtmodeoftransport" CssClass="span11" runat="server" MaxLength="50" placeholder="Max 50 Chars.."></asp:TextBox>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td valign="top" style="display: none">
                                                                                        <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div class="form-actions no-margin">
                                                                            <asp:Button ID="btncontact" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btncontact_Click" ValidationGroup="A"  />
                                                                           <%-- OnClientClick="return ValidateContact();"--%>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">&#160;&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </p>
                                            </div>
                                            <div>
                                                <p>
                                                    <!-- Professional Details -->

                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="li_tabs3">
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:UpdateProgress ID="UpdateProgress8" runat="server" AssociatedUpdatePanelID="updatepannel2d"
                                                                            DisplayAfter="1">
                                                                            <ProgressTemplate>
                                                                                <div class="modal-backdrop fade in">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="center" valign="top">
                                                                                                <img src="../img/loading.gif" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
                                                                                    </table>
                                                                                </div>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                        <table width="100%">
                                                                            <tr class="frm-lft-clr-main">
                                                                                <td align="left">&nbsp;Educational Qualification :</td>
                                                                                <td align="right">
                                                                                    <asp:Button ID="btn_quali_add" OnClick="btn_quali_add_Click" runat="server" Text="Add"
                                                                                        CssClass="btn btn-primary" ToolTip="Click here to add Educational Qualification" ValidationGroup="eq" ></asp:Button></td>
                                                                               <%-- OnClientClick="return ValidateEducation();"--%>
                                                                            </tr>
                                                                        </table>
                                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                            width="100%" border="1">

                                                                            <tr>
                                                                                <td class="td-head" width="21%">Education<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="17%">Specialization<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="30%">School / Institute / University Name<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="10%">Grade / %<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="22%">Year<span class="star"></span>
                                                                    
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-rght-clr12345" style="width: 150px">
                                                                                    <asp:DropDownList ID="drp_edu_qualification" runat="server" AutoPostBack="true" CssClass="span11" OnSelectedIndexChanged="drp_edu_qualification_SelectedIndexChanged" Width="180px">
                                                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                        <asp:ListItem Value="Matric(10th)">Matric(10th)</asp:ListItem>
                                                                                        <asp:ListItem Value="Intermediate(12th)">Intermediate(12th)</asp:ListItem>
                                                                                        <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                                                                        <asp:ListItem Value="Graduation">Graduation</asp:ListItem>
                                                                                        <asp:ListItem Value="others">Others</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="drp_edu_qualification" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="eq" InitialValue="0" ToolTip="Select Education"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtedu_specilazation" runat="server" CssClass="span11" MaxLength="100" onblur="capitalizeMe(this);" ondrop="return false;" onkeypress="return checkNum(event);" onpaste="return false;" placeholder="Max. 100 Char.." Width="110px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtedu_specilazation" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="eq" ToolTip="Enter Specialization"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtedush" runat="server" CssClass="span11" MaxLength="150" onblur="capitalizeMe(this);" ondrop="return false;" onpaste="return false;" placeholder="Max. 150 Char.." Width="240px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtedush" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="eq" ToolTip="Enter School / Institute / University Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txteduper" runat="server" CssClass="span11" MaxLength="5" placeholder="Max. 5 Char.." Width="60px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txteduper" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="eq" ToolTip="Enter Grade"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtedufrom" runat="server" CssClass="span11" MaxLength="4" ondrop="return false;" onkeypress="return IsNumeric(event);" onpaste="return false;" placeholder="Max. 4 Char.." Width="60px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtedufrom" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="eq" ToolTip="Enter From Year"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    to
                                                                            <asp:TextBox ID="txteduto" runat="server" CssClass="span11" MaxLength="4" ondrop="return false;" onkeypress="return IsNumeric(event);" onpaste="return false;" placeholder="Max. 4 Char.." Width="60px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txteduto" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="eq" ToolTip="Enter To Year"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToCompare="txteduto" ControlToValidate="txtedufrom" Operator="LessThan" ToolTip="To year must be greater than from year" ValidationGroup="eq" Type="Integer"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>





                                                                            <tr id="div_Edu_Qual_others" runat="server">
                                                                                <td class="frm-rght-clr12345">
                                                                                    <asp:TextBox ID="txt_Edu_Qual_others" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this);" ondrop="return false;" onpaste="return false;" placeholder="Max. 50 Char.." Width="180px"></asp:TextBox>
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>





                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                            OnRowDeleting="grid_edu_education_RowDeleting" AutoGenerateColumns="False" AllowSorting="True"
                                                                                            CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left" BorderWidth="0px">

                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Education">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Specialization">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="School / Institute / University Name ">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Grade / %">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Year">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>&nbsp;-&nbsp;<asp:Label
                                                                                                            ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="Delete"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                        </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&#160;&nbsp;
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:UpdateProgress ID="UpdateProgress9" runat="server" AssociatedUpdatePanelID="UpdatePanel3"
                                                                            DisplayAfter="1">
                                                                            <ProgressTemplate>
                                                                                <div class="modal-backdrop fade in">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="center" valign="top">
                                                                                                <img src="../img/loading.gif" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                        <table width="100%" class="frm-lft-clr-main">
                                                                            <tr>
                                                                                <td align="left">Professional / Technical Qualification :</td>
                                                                                <td align="right">
                                                                                    <asp:Button ID="btn_pro_qual_add" OnClick="btn_pro_qual_add_Click" runat="server"
                                                                                        Text="Add" CssClass="btn btn-primary" ToolTip="Click here to add Professional Qualification"
                                                                                        ValidationGroup="pt" ></asp:Button>
                                                                                   <%-- OnClientClick="return ValidateProfessional();"--%>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                            width="100%" border="1">
                                                                            <tr>
                                                                                <td class="td-head" width="21%">Education<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="17%">Specialization<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="30%">Institute / University Name<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="10%">Grade / %<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="22%">Year<span class="star"></span> 
                                                                    
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="txteduc1" runat="server" placeholder="Max. 150 Char.." CssClass="span11" Width="165px" MaxLength="150" onblur="capitalizeMe(this);">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txteduc1" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="pt" ToolTip="Enter Education"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtpro_specilazation" placeholder="Max. 100 Char.." runat="server" CssClass="span11" Width="120px" MaxLength="100" onblur="capitalizeMe(this);" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="txtpro_specilazation" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="pt" ToolTip="Enter Specialization"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtsch1" runat="server" placeholder="Max. 100 Char.." CssClass="span11" Width="240px" MaxLength="100" onblur="capitalizeMe(this);">
                                                                                    </asp:TextBox>
                                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtsch1" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="pt" ToolTip="Enter Institute / University Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtper1" runat="server" placeholder="Max. 5 Char.." CssClass="span11" Width="60px" MaxLength="5"></asp:TextBox>
                                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="txtper1" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="pt" ToolTip="Enter Grade"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtfrm1" runat="server" placeholder="Max. 4 Char.." CssClass="span11" Width="60px" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtfrm1" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="pt" ToolTip="Enter From Year"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                    to
                                                                    <asp:TextBox ID="txtto1" runat="server" placeholder="Max. 4 Char.." CssClass="span11" Width="60px" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtto1" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="pt" ToolTip="Enter To Year"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                          <asp:CompareValidator runat="server" ID="CompareValidator2" ControlToCompare="txtto1" ControlToValidate="txtfrm1" Operator="LessThan" ToolTip="To year must be greater than from year" ValidationGroup="pt" Type="Integer"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" OnRowDeleting="grid_Pro_education_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                                                                <asp:TemplateField HeaderStyle-Width="10%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:UpdateProgress ID="UpdateProgress10" runat="server" AssociatedUpdatePanelID="UpdatePanel4"
                                                                            DisplayAfter="1">
                                                                            <ProgressTemplate>
                                                                                <div class="modal-backdrop fade in">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="center" valign="top">
                                                                                                <img src="../img/loading.gif" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                        <table width="100%" class="frm-lft-clr-main">
                                                                            <tr>
                                                                                <td align="left">Experience Details :</td>
                                                                                <td align="right">
                                                                                    <asp:Button ID="btn_exp_add" OnClick="btn_exp_add_Click" runat="server" Text="Add" ValidationGroup="ed"
                                                                                        CssClass="btn btn-primary"></asp:Button>
                                                                                     <%--OnClientClick="return ValidateCompany()"--%>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                            width="100%" border="1">
                                                                            <tr>
                                                                                <td class="td-head" width="18%">Company Name<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="28%">Address / Location<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="20%">Designation<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="15%">Total Exp.(in years)<span class="star"></span>
                                                                                </td>
                                                                                <td class="td-head" width="18%">Year <span class="star"></span>
                                                                    
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtcomp1" runat="server" CssClass="span11" Width="140px" MaxLength="100" placeholder="Max. 100 Char.." onblur="capitalizeMe(this);"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="txtcomp1" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="ed" ToolTip="Enter Company Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txt_com_local" runat="server" CssClass="span11" Width="230px" MaxLength="250" placeholder="Max. 250 Char.." onblur="capitalizeMe(this);"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="txt_com_local" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="ed" ToolTip="Enter Address / Location"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txt_EXp_designation" runat="server" CssClass="span11" Width="150px" MaxLength="50" placeholder="Max. 50 Char.." onblur="capitalizeMe(this);"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="txt_EXp_designation" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="ed" ToolTip="Enter Designation"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txt_total_exp" runat="server" CssClass="span11" Width="100px" MaxLength="5" placeholder="Max. 5 Char.." onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_total_exp"
                                                                                        ValidationGroup="c" runat="server" ValidationExpression="\d{1,3}(\.\d{0,2})?$" ToolTip="Enter Correct Values"
                                                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="txt_total_exp" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="ed" ToolTip="Enter Last Drawn CTC"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txt_exp_from" runat="server" CssClass="span11" Width="60px" MaxLength="4" placeholder="Max. 4 Char.." onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="txt_exp_from" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="ed" ToolTip="Enter From Year"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    to
                                                                    <asp:TextBox ID="txt_exp_to" runat="server" CssClass="span11" Width="60px" MaxLength="4" placeholder="Max. 4 Char.." onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txt_exp_to" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="ed" ToolTip="Enter To Year"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                          <asp:CompareValidator runat="server" ID="CompareValidator3" ControlToCompare="txt_exp_to" ControlToValidate="txt_exp_from" Operator="LessThan" ToolTip="To year must be greater than from year" ValidationGroup="ed" Type="Integer"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="grid_exp" runat="Server" Width="100%" OnRowDeleting="grid_exp_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Company Name" HeaderStyle-Width="18%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:HiddenField ID="hdf" runat="server" Value='<%# Eval("autoID") %>' />
                                                                                                        <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Address / Location" HeaderStyle-Width="30%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="18%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Total Exp." HeaderStyle-Width="10%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Year" HeaderStyle-Width="15%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-Width="10%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&#160;&nbsp;
                                                            </td>
                                                        </tr>



                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:UpdateProgress ID="UpdateProgress11" runat="server" AssociatedUpdatePanelID="UpdatePanel7"
                                                                            DisplayAfter="1">
                                                                            <ProgressTemplate>
                                                                                <div class="modal-backdrop fade in">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="center" valign="top">
                                                                                                <img src="../img/loading.gif" />
                                                                                            </td>
                                                                                        </tr>

                                                                                    </table>
                                                                                </div>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                        <table width="100%" class="frm-lft-clr-main">
                                                                            <tr>
                                                                                <td align="left">Training Details :</td>
                                                                                <td align="right">
                                                                                    <asp:Button ID="btn_Training" OnClick="btn_Training_Click" runat="server" Text="Add"
                                                                                        CssClass="btn btn-primary" ToolTip="Click here to add Training Details" ValidationGroup="Training" OnClientClick="return ValidateTraining();"></asp:Button>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                            width="100%" border="1">
                                                                            <tr>
                                                                                <td class="td-head" width="22%">Training Name<span class=""></span>
                                                                                </td>
                                                                                <td class="td-head" width="22%">Conducted By<span class=""></span>
                                                                                </td>
                                                                                <td class="td-head" width="15%">From
                                                                                </td>
                                                                                <td class="td-head" width="17%">To
                                                                                </td>
                                                                                <td class="td-head" width="24%">Remarks
                                                                        
                                                                        
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="txt_TrProgram" runat="server" CssClass="span11" MaxLength="90" Width="180px" placeholder="Max. 100 Char.."></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txt_TrConductedBy" runat="server" CssClass="span11" Width="180px" MaxLength="90" placeholder="Max. 100 Char.."></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtFromdate" runat="server" Width="100px" CssClass="span11" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>&#160;<asp:Image
                                                                                        ID="Image8" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                            ID="CalendarExtender8" runat="server" PopupButtonID="Image8" TargetControlID="txtFromdate"
                                                                                            Enabled="True">
                                                                                        </cc1:CalendarExtender>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtToDate" runat="server" Width="100px" CssClass="span11" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" onblur="return TrainingCompareDates();"></asp:TextBox>&#160;<asp:Image
                                                                                        ID="Image9" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                            ID="CalendarExtender9" runat="server" PopupButtonID="Image9" TargetControlID="txtToDate"
                                                                                            Enabled="True">
                                                                                        </cc1:CalendarExtender>

                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtTrRemarks" runat="server" CssClass="span11" Width="180px" placeholder="Max. 500 Char.." MaxLength="500">

                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="GridTraning" runat="Server" Width="100%" OnRowDeleting="GridTraning_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="trainingname"
                                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Training Name" HeaderStyle-Width="18%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblTraning" runat="Server" Text='<%# Eval("trainingname")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Conducted By" HeaderStyle-Width="18%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblConductedBy" runat="Server" Text='<%# Eval("personname")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="From" HeaderStyle-Width="16%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblfromdate" runat="Server" Text='<%# Eval("fromdate")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="To" HeaderStyle-Width="16%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lbltodate" runat="Server" Text='<%# Eval("todate")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="18%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("remarks") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderStyle-Width="10%">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5">&#160;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="upedu" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="upedu"
                                                                            DisplayAfter="1">
                                                                            <ProgressTemplate>
                                                                                <div class="modal-backdrop fade in">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td align="center" valign="top">
                                                                                                <img src="../img/loading.gif" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
                                                                                    </table>
                                                                                </div>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                        <div class="form-actions no-margin">
                                                                            <asp:Button ID="btnprop" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnprop_Click" OnClientClick="return ValidateProp();" />
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </p>
                                            </div>
                                            <div>
                                                <p>
                                                    <!-- Personal Details -->

                                                    <asp:UpdatePanel ID="updatepanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:UpdateProgress ID="UpdateProgress13" runat="server" AssociatedUpdatePanelID="updatepanel8"
                                                                DisplayAfter="1">
                                                                <ProgressTemplate>
                                                                    <div class="modal-backdrop fade in">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td align="center" valign="top">
                                                                                    <img src="../img/loading.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="li_tabs4" runat="server">
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" colspan="2">Personal Information
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" colspan="2">
                                                                        <table valign="top" cellspacing="0" cellpadding="0" width="1036px" border="0">
                                                                            <tr>
                                                                                <td valign="top" width="50%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="45%">Date of Birth <span class="star"></span>
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                                <asp:TextBox ID="txt_DOB" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>

                                                                                                <asp:Image ID="Image1" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dob" Format="dd-MMM-yyyy"
                                                                                                    PopupButtonID="Image1">
                                                                                                </cc1:CalendarExtender>
                                                                                                <%--<img src="../img/error1.gif" alt="" visible="false" id="imgerror" runat="server" />--%>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txt_DOB" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="x" ToolTip="Enter Date of Birth"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" style="height: 30px">Payment Mode <span class=""></span>
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <label class="radio inline">
                                                                                                    <asp:RadioButton ID="rbtnbank" runat="server" AutoPostBack="true"
                                                                                                        Text="Bank" GroupName="paymentmode" OnCheckedChanged="rbtnbank_CheckedChanged" /></label>
                                                                                                <label class="radio inline">
                                                                                                    <asp:RadioButton ID="rbtncheque" runat="server" AutoPostBack="true" Text="Cheque"
                                                                                                        GroupName="paymentmode" OnCheckedChanged="rbtncheque_CheckedChanged" /></label>
                                                                                                <label class="radio inline">
                                                                                                    <asp:RadioButton ID="rbtncash" runat="server" AutoPostBack="true" Text="Cash"
                                                                                                        GroupName="paymentmode" OnCheckedChanged="rbtncash_CheckedChanged" /></label>
                                                                                            </td>
                                                                                        </tr>

                                                                                    </table>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                        <tr style="display: none">
                                                                                            <td class="frm-lft-clr123" width="45%">Religion
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="54%">
                                                                                                <asp:TextBox ID="txtrelg" runat="server" placeholder="Max. 50 Char.." CssClass="span11" onblur="capitalizeMe(this);"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="height: 50px;">
                                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">Blood Group <span class="star"></span>
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                <asp:DropDownList ID="ddlbloodgrp" runat="server" CssClass="span11">
                                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                    <asp:ListItem Value="A+">A+</asp:ListItem>
                                                                                                    <asp:ListItem Value="A-">A-</asp:ListItem>
                                                                                                    <asp:ListItem Value="B+">B+</asp:ListItem>
                                                                                                    <asp:ListItem Value="B-">B-</asp:ListItem>
                                                                                                    <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                                                                    <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                                                                    <asp:ListItem Value="O+">O+</asp:ListItem>
                                                                                                    <asp:ListItem Value="O-">O-</asp:ListItem>
                                                                                                    <asp:ListItem Value="A Rh-">A Rh-</asp:ListItem>
                                                                                                    <asp:ListItem Value="A Rh+">A Rh+</asp:ListItem>
                                                                                                    <asp:ListItem Value="B Rh-">B Rh-</asp:ListItem>
                                                                                                    <asp:ListItem Value="B Rh+">B Rh+</asp:ListItem>
                                                                                                    <asp:ListItem Value="AB Rh-">AB Rh-</asp:ListItem>
                                                                                                    <asp:ListItem Value="AB Rh+">AB Rh+</asp:ListItem>
                                                                                                    <asp:ListItem Value="O Rh-">O Rh-</asp:ListItem>
                                                                                                    <asp:ListItem Value="O Rh+">O Rh+</asp:ListItem>
                                                                                                    <asp:ListItem Value="HH(Bombay)">HH(Bombay)</asp:ListItem>
                                                                                                    <asp:ListItem Value="A1+">A1+</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddlbloodgrp" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="x" ToolTip="Select Blood Group" InitialValue="0"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr style="display: none">
                                                                                            <td class="frm-lft-clr123">D.L. No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:TextBox ID="txt_dl_no" placeholder="Max. 20 Char.." runat="server" CssClass="span11" MaxLength="20"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>

                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" colspan="2">
                                                                        <div id="paymentmode" runat="server" visible="true" align="center">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="50%">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="left" style="height: 30px" class="frm-lft-clr123" width="45%">Bank Name for Salary<span class="star"></span>
                                                                                                </td>
                                                                                                <td align="left" class="frm-rght-clr123" width="55%">
                                                                                                    <asp:DropDownList ID="ddl_bank_name" runat="server" CssClass="span11"
                                                                                                        Height="" DataSourceID="SqlDataSource1" DataTextField="bankname" DataValueField="branchcode"
                                                                                                        OnDataBound="ddl_bank_name_DataBound">
                                                                                                    </asp:DropDownList>
                                                                                                    <asp:SqlDataSource
                                                                                                        ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>

                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ControlToValidate="ddl_bank_name" SetFocusOnError="true" Display="Dynamic"
                                                                                                ValidationGroup="x" ToolTip="Select Bank Name for Salary" InitialValue="0"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td align="left" class="frm-lft-clr123">Bank Branch Name<span class="star"></span>
                                                                                                </td>
                                                                                                <td align="left" class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_bankbrachname" runat="server" placeholder="Max. 100 Char.." CssClass="span11" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txt_bankbrachname" SetFocusOnError="true" Display="Dynamic"
                                                                                                ValidationGroup="x" ToolTip="Enter Bank Branch Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                        <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                                                                            <tr>
                                                                                                <td align="left" class="frm-lft-clr123" width="45%">Account No. for Salary<span class="star"></span>
                                                                                                </td>
                                                                                                <td align="left" class="frm-rght-clr123" width="54%">
                                                                                                    <asp:TextBox ID="txt_bank_ac" runat="server" CssClass="span11" placeholder="Max. 20 Char.." MaxLength="20" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txt_bank_ac" SetFocusOnError="true" Display="Dynamic"
                                                                                                ValidationGroup="x" ToolTip="Enter Account No. for Salary"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td align="left" class="frm-lft-clr123">IFSC code<span class="star"></span>
                                                                                                </td>
                                                                                                <td align="left" class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_ifsc" runat="server" CssClass="span11" MaxLength="11" placeholder="Max. 11 Char.."></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txt_ifsc" SetFocusOnError="true" Display="Dynamic"
                                                                                                ValidationGroup="x" ToolTip="Enter IFSC code"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="a" runat="server" visible="false">
                                                                                    <td align="left" class="frm-lft-clr123">Bank Name for Reimbursement
                                                                                    </td>
                                                                                    <td align="left" class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="ddl_bank_name_reimbursement" runat="server" CssClass="blue1"
                                                                                            DataSourceID="SqlDataSource2" DataTextField="bankname" DataValueField="branchcode"
                                                                                            OnDataBound="ddl_bank_name_reimbursement_DataBound">
                                                                                        </asp:DropDownList>
                                                                                        <asp:SqlDataSource
                                                                                            ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>
                                                                                    </td>
                                                                                    <td>&#160;&nbsp;
                                                                                    </td>
                                                                                    <td align="left" class="frm-lft-clr123">Account No. for Reimbursement
                                                                                    </td>
                                                                                    <td align="left" class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_bank_ac_reimbursement" runat="server" CssClass="span11" MaxLength="50"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" colspan="2">
                                                                        <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>

                                                                                <td valign="top" width="50%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="45%">Mobile No.<span class="star"></span>
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                                <asp:TextBox ID="txtccode" runat="server" CssClass="span1" Width="50px" MaxLength="3" placeholder="Max 3" Text="+91" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                <asp:TextBox ID="txtmobileno" runat="server" placeholder="Max. 10 Char.." CssClass="span11" Width="190px" MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">LandLine No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                <asp:TextBox ID="txtperccode" runat="server" Width="30px" placeholder="Max 3" Text="+91" MaxLength="3" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                <asp:TextBox ID="txtperstdcode" runat="server" Width="50px" placeholder="Max 5 Chars.." MaxLength="5" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                <asp:TextBox ID="txtperlandno" runat="server" CssClass="span11" Width="130px" placeholder="Max 10 Chars.."
                                                                                                    MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">Passport No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:TextBox ID="txt_passportno" runat="server" CssClass="span11" placeholder="Max. 15 Char.." Width="" MaxLength="15"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">Passport Issued Date
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:TextBox ID="txt_passportissueddate" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>&nbsp;<asp:Image
                                                                                                    ID="Image10" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_passportissueddate"
                                                                                                        PopupButtonID="Image10" Format="dd-MMM-yyyy">
                                                                                                    </cc1:CalendarExtender>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 ">Passport Expiry Date
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 ">
                                                                                                <asp:TextBox ID="txt_passportexpdate" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" ondrop="return false;" onpaste="return false;" onblur="return CompareDates();"></asp:TextBox>&nbsp;<asp:Image
                                                                                                    ID="Image7" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_passportexpdate"
                                                                                                        PopupButtonID="Image7">
                                                                                                    </cc1:CalendarExtender>

                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom">T-Shirt Size
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                <asp:DropDownList ID="ddl_Tshirt" runat="server" CssClass="span11">
                                                                                                    <asp:ListItem Value="0">--Select Size--</asp:ListItem>
                                                                                                    <asp:ListItem Value="38">38</asp:ListItem>
                                                                                                    <asp:ListItem Value="39">39</asp:ListItem>
                                                                                                    <asp:ListItem Value="40">40</asp:ListItem>
                                                                                                    <asp:ListItem Value="42">42</asp:ListItem>
                                                                                                    <asp:ListItem Value="44">44</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr>
                                                                                            <td colspan="2" height="5"></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="45%">Personal Email Id<span class="star"></span>
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="54%">
                                                                                                <asp:TextBox ID="txt_email" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50"></asp:TextBox>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="txt_email" SetFocusOnError="true" Display="Dynamic"
                                                                                                ValidationGroup="x" ToolTip="Enter Personal Email"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                                                                    ValidationGroup="v" ToolTip="Not a Vaild Email ID" SetFocusOnError="True" Display="Dynamic"
                                                                                                    ControlToValidate="txt_email" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123">Driving Licence No.
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_drli_no" runat="server" CssClass="span11" placeholder="Max. 20 Char.." Width="" MaxLength="20"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123">Driving Licence Issued Date
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_dr_iss_date" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" ondrop="return false;" onpaste="return false;">

                                                                                    </asp:TextBox>&nbsp;<asp:Image
                                                                                        ID="Image15" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txt_dr_iss_date"
                                                                                            PopupButtonID="Image15" Format="dd-MMM-yyyy">
                                                                                        </cc1:CalendarExtender>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 ">Driving Licence Expiry Date
                                                                                </td>
                                                                                <td class="frm-rght-clr123 ">
                                                                                    <asp:TextBox ID="txt_dr_exp_date" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" ondrop="return false;" onpaste="return false;" onblur="return CompareDates();"></asp:TextBox>&nbsp;<asp:Image
                                                                                        ID="Image16" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender16" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_dr_exp_date"
                                                                                            PopupButtonID="Image16">
                                                                                        </cc1:CalendarExtender>

                                                                                </td>
                                                                            </tr>


                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom">Shirt Size
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:DropDownList ID="ddl_ShirtSize" runat="server" CssClass="span11">
                                                                                        <asp:ListItem Value="0">--Select Size--</asp:ListItem>
                                                                                        <asp:ListItem Value="S">S</asp:ListItem>
                                                                                        <asp:ListItem Value="M">M</asp:ListItem>
                                                                                        <asp:ListItem Value="L">L</asp:ListItem>
                                                                                        <asp:ListItem Value="XL">XL</asp:ListItem>
                                                                                        <asp:ListItem Value="XXL">XXL</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>

                                                            <tr>
                                                                <td colspan="2"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="txt02" colspan="2" height="5">Relationship Details
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">Father Name<span class="star"></span> 
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                            <asp:TextBox ID="txt_f_f_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeypress="return checkNum(event);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txt_f_f_name" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="x" ToolTip="Enter Father Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr id="Tr22" runat="server" visible="false">
                                                                                        <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_f_mname" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr id="Tr29" runat="server" visible="false">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:TextBox ID="txt_f_l_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt02" colspan="2" height="5">Employee Marital Status
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">Marital Status
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:DropDownList ID="ddlpersonalstatus" runat="server" CssClass="span11"
                                                                                                Height="" AutoPostBack="True" OnSelectedIndexChanged="ddlpersonalstatus_SelectedIndexChanged">
                                                                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="Unmarried" Value="UNMARRIED"></asp:ListItem>
                                                                                                <asp:ListItem Text="Married" Value="MARRIED"></asp:ListItem>
                                                                                                <asp:ListItem Text="Divorcee" Value="DIVORCEE"></asp:ListItem>
                                                                                                <asp:ListItem Text="Widow" Value="WIDOW"></asp:ListItem>
                                                                                                <asp:ListItem Text="Widower" Value="WIDOWER"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 13px" class="txt02" colspan="2">Mother&apos;s Detail
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">Mother Name<span class="star"></span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:TextBox ID="txt_m_fname" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txt_m_fname" SetFocusOnError="true" Display="Dynamic"
                                                                                            ValidationGroup="x" ToolTip="Enter Mother Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr id="Tr30" runat="server" visible="false">
                                                                                        <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_m_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr id="Tr31" runat="server" visible="false">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:TextBox ID="txt_m_l_name" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 12px" colspan="2"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server"
                                                                                    visible="false">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td valign="top" width="50%">
                                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                            <tr>
                                                                                                                <td style="height: 13px" class="txt02" colspan="2">Spouse Detail
                                                                                                                </td>
                                                                                                            </tr>

                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123" width="45%">Spouse Name<span class="star"></span>
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" width="55%">
                                                                                                                    <asp:TextBox ID="txt_sp_fname" placeholder="Max. 50 Char.." runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeypress="return checkNum(event);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="txt_sp_fname" SetFocusOnError="true" Display="Dynamic"
                                                                                                                    ValidationGroup="x" ToolTip="Enter Spouse Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                                </td>
                                                                                                            </tr>

                                                                                                            <tr id="Tr32" runat="server" visible="false">
                                                                                                                <td class="frm-lft-clr123">Middle Name
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123">
                                                                                                                    <asp:TextBox ID="txt_sp_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                                </td>
                                                                                                            </tr>

                                                                                                            <tr id="Tr33" runat="server" visible="false">
                                                                                                                <td class="frm-lft-clr123 border-bottom">Last Name
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                                    <asp:TextBox ID="txt_sp_lname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator33" ControlToValidate="txt_sp_lname"
                                                                                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123 border-bottom">Date of Anniversary
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                                                    <asp:TextBox ID="txt_doa" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onblur="return SpouseCompareDates();" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;<asp:Image
                                                                                                                        ID="Image2" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_doa" Format="dd-MMM-yyyy"
                                                                                                                        PopupButtonID="Image2">
                                                                                                                    </cc1:CalendarExtender>
                                                                                                                </td>
                                                                                                            </tr>



                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                            <tr>
                                                                                                                <td class="txt02" colspan="2" height="5">&#160;&nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123" width="45%">Date of Birth
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" width="55%">
                                                                                                                    <asp:TextBox ID="txt_s_DOB" runat="server" placeholder="Select Date" CssClass="span11" Width="" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;<asp:Image
                                                                                                                        ID="Image14" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                    <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_s_DOB" Format="dd-MMM-yyyy"
                                                                                                                        PopupButtonID="Image14">
                                                                                                                    </cc1:CalendarExtender>

                                                                                                                </td>
                                                                                                            </tr>

                                                                                                            <tr runat="server" visible="false">
                                                                                                                <td class="frm-lft-clr123 border-bottom">Gender
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                                    <asp:DropDownList ID="ddl_s_gender" runat="server" CssClass="blue1"
                                                                                                                        Width="240px">
                                                                                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                                                        <asp:ListItem>Male</asp:ListItem>
                                                                                                                        <asp:ListItem>Female</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="2" height="5"></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td valign="top">
                                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                            <tr>
                                                                                                                <td style="height: 18px" class="txt02" colspan="3">Children Detail
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123" width="33%">Name<span class=""></span>
                                                                                                                </td>
                                                                                                                <td class="frm-lft-clr123" width="32%">Gender<span class=""></span>
                                                                                                                </td>
                                                                                                                <td width="35%" class="frm-lft-clr123">Date of Birth<span class=""></span>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-rght-clr123 border-bottom" style="border-right: none" width="33%">
                                                                                                                    <asp:TextBox ID="txt_child_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" onkeypress="return checkNum(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom" style="border-right: none">
                                                                                                                    <asp:DropDownList ID="ddl_child_gender" runat="server" CssClass="span11" Height=""
                                                                                                                        Width="150px">
                                                                                                                        <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                                                        <asp:ListItem>Male</asp:ListItem>
                                                                                                                        <asp:ListItem>Female</asp:ListItem>
                                                                                                                    </asp:DropDownList>

                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom" width="35%">
                                                                                                                    <table width="100%">
                                                                                                                        <tr>
                                                                                                                            <td align="left">
                                                                                                                                <asp:TextBox ID="txt_child_Dob" placeholder="Select Date" runat="server" CssClass="span11" Width="210px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                                                    <asp:Image ID="Image3" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_child_Dob" Format="dd-MMM-yyyy"
                                                                                                                                    PopupButtonID="Image3">
                                                                                                                                </cc1:CalendarExtender>

                                                                                                                            </td>
                                                                                                                            <td align="right">
                                                                                                                                <asp:UpdatePanel ID="upvv" runat="server">
                                                                                                                                    <ContentTemplate>
                                                                                                                                        <asp:Button ID="btn_child_Add" OnClick="btn_child_Add_Click" runat="server" Text="Add" OnClientClick="return ValidateChildren();"
                                                                                                                                            CssClass="btn btn-primary" ToolTip="Click hare to add children detail"></asp:Button>
                                                                                                                                    </ContentTemplate>
                                                                                                                                </asp:UpdatePanel>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="10px" colspan="3"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td valign="top" colspan="3">
                                                                                                        <div class="widget-content">
                                                                                                            <asp:GridView ID="grid_child" runat="Server" Width="99%" OnRowDeleting="grid_child_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                                                AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                                                                                                HorizontalAlign="Left" CellPadding="4">
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField HeaderText="Child Name" HeaderStyle-Width="30%">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Gender" HeaderStyle-Width="30%">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Labelgender" runat="Server" Text='<%# Eval("gender") %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-Width="30%">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderStyle-Width="9%">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link04"
                                                                                                                                Text="Delete"></asp:LinkButton>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                                            </asp:GridView>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td valign="top"></td>
                                                                                                    <td valign="top"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 30px; height: 9px"></td>
                                                                <td style="height: 9px" align="right"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="form-actions no-margin">
                                                                        <asp:Button ID="btnpersonal" runat="server" Text="Save" CssClass="btn btn-primary pull-right" ValidationGroup="x" OnClick="btnpersonal_Click"/>
                                                                       
                                                                        <%-- OnClientClick="return ValidatePersonalDetails();"--%>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            </table>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                </p>
                                            </div>


                                            <div id="divhealth" runat="server" visible="false">
                                                <p>
                                                    <!-- Health Details -->
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                        <tr>
                                                            <td colspan="2" class="txt02" style="height: 25px">Select Health Insurance Package
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="2">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td valign="top" width="50%">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr style="height: 50px">

                                                                                    <td class="frm-lft-clr123" width="40%">BENEFITS 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                        <asp:Label ID="lblbenefits" runat="server"></asp:Label>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) INDIVIDUAL PLAN
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                        <asp:Label ID="lblindivibual" runat="server"></asp:Label>
                                                                                    </td>

                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) FAMILY PLAN OF FOUR 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                        <asp:Label ID="lblplanfour" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) FAMILY PLAN OF SIX 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                        <asp:Label ID="lblplansix" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30px; height: 9px"></td>
                                                                                    <td style="height: 9px" align="right"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>

                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td style="height: 12px" colspan="2"></td>
                                                        </tr>

                                                    </table>
                                                </p>
                                            </div>

                                                           <div visible="true" runat="server">
                                        <p>
                                            <!-- Employee Upload Details -->
                                       
                                                     <tr>
                                                <td colspan="2" class="txt02"><b>Photo Id Proof</b>
                                                </td>
                                            </tr>
                                            <hr size="4px" style="background-color: gray" />
                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress17" runat="server" AssociatedUpdatePanelID="UpdatePanel13"
                                                        DisplayAfter="1">
                                                        <ProgressTemplate>
                                                            <div class="modal-backdrop fade in">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <img src="../img/loading.gif" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <table id="li_tabs5" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">

                                                        <tr>

                                                            <td class="frm-rght-clr123 " width="20%">ID Type</td>
                                                            <td class="frm-rght-clr123 " width="25%">
                                                                <asp:DropDownList ID="DropDownList25" runat="server" CssClass="span7" OnSelectedIndexChanged="DropDownList25_SelectedIndexChanged" AutoPostBack="true"
                                                                    Height="">
                                                                    <%--  <asp:ListItem Text="0" Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="C" Value="3"></asp:ListItem>--%>
                                                                </asp:DropDownList></td>
                                                              <td class="frm-rght-clr123 border-bottom">

                                                                <asp:FileUpload ID="FileUpload2" runat="server" Width="287px" ToolTip="Upload File here" />&nbsp;
                                                            </td>


                                                            



                                                        </tr>
                                                        <tr>

                                                            <td class="frm-rght-clr123 border-bottom" width="20%" runat="server" visible="false" id="tdother">Others</td>
                                                            <td class="frm-rght-clr123 border-bottom" width="25%" runat="server" visible="false" id="textother">
                                                                <asp:TextBox ID="TextBox6" runat="server" CssClass="span7" TextMode="SingleLine" placeholder="Max 20 Chars..." Width="" MaxLength="20"></asp:TextBox>
                                                            </td>

                                                          <td id="Td2" class="frm-rght-clr123 " runat="server" visible="false">
                                                                <label class="radio inline">
                                                                    <asp:RadioButton ID="RadioButton10" runat="server" AutoPostBack="true" Checked="false"
                                                                        Text="Current Residential Address" GroupName="paymentmode" OnCheckedChanged="rbtnbank_CheckedChanged" /></label>
                                                                <label class="radio inline">
                                                                    <asp:RadioButton ID="RadioButton11" runat="server" AutoPostBack="true" Checked="false" Text="Permanent Residential Address"
                                                                        GroupName="paymentmode" OnCheckedChanged="rbtncheque_CheckedChanged" /></label>

                                                            </td>


                                                        </tr>
                                                        <tr class="frm-lft-clr-main border-bottom">
                                                            <td></td>
                                                            <td></td>

                                                            <td align="right">
                                                                <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Add" OnClientClick="return validation();" 
                                                                    CssClass="btn btn-primary" ToolTip="Click here to add Educational Qualification"></asp:Button></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <div class="widget-content">
                                                                    <asp:GridView ID="GridView3" runat="Server" Width="100%" OnRowDeleting="GridPhotoUpload_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                        AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                        HorizontalAlign="Left" CellPadding="4">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="ID Type" HeaderStyle-Width="18%">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdf1" runat="server" Value='<%# Eval("autoID") %>' />
                                                                                    <asp:Label ID="lblidty" runat="Server" Text='<%# Eval("ID_Type")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Others" HeaderStyle-Width="18%" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCohuhsds" runat="Server" Text='<%# Eval("Others")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Address Type" HeaderStyle-Width="16%" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblfrofile" runat="Server" Text='<%# Eval("Address_Type")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="File" HeaderStyle-Width="16%">

                                                                                <ItemTemplate>
                                                                                    <a href="../upload/employeedocuments/<%#DataBinder.Eval(Container.DataItem,"File")%>" target="_blank" class="link057">View File</a>

                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton
                                                                                        CssClass="link04" ID="LinkButton23" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>


                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="Button2" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <br />
                                            <tr>
                                                <td colspan="2" class="txt02"><b>Address Proof</b>
                                                </td>
                                            </tr>
                                            <hr size="4px" style="background-color: gray" />
                                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress19" runat="server" AssociatedUpdatePanelID="UpdatePanel14"
                                                        DisplayAfter="1">
                                                        <ProgressTemplate>
                                                            <div class="modal-backdrop fade in">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <img src="../img/loading.gif" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <table id="Table4" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">

                                                        <tr>

                                                            <td class="frm-rght-clr123 " width="20%">ID Type</td>
                                                            <td class="frm-rght-clr123 " width="25%">
                                                                <asp:DropDownList ID="DropDownList27" runat="server" CssClass="span7" OnSelectedIndexChanged="DropDownList27_SelectedIndexChanged" AutoPostBack="true"
                                                                    Height="">
                                                                    <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="C" Value="3"></asp:ListItem>--%>
                                                                </asp:DropDownList></td>
                                                              <td class="frm-rght-clr123 border-bottom">

                                                                <asp:FileUpload ID="FileUpload3" runat="server" Width="287px" ToolTip="Upload File here" />&nbsp;
                                                            </td>


                                                         



                                                        </tr>
                                                        <tr>

                                                            <td class="frm-rght-clr123 border-bottom" width="20%" runat="server" visible="false" id="other2">Others</td>
                                                            <td class="frm-rght-clr123 border-bottom" width="25%" runat="server" visible="false" id="txtother2">
                                                                <asp:TextBox ID="TextBox74" runat="server" CssClass="span7" TextMode="SingleLine" placeholder="Max 20 Chars..." Width="" MaxLength="20"></asp:TextBox>
                                                            </td>

                                                               <td id="Td3" class="frm-rght-clr123 " runat="server" visible="false">
                                                                <label class="radio inline">
                                                                    <asp:RadioButton ID="RadioButton12" runat="server" Checked="false"
                                                                        Text="Current Residential Address" GroupName="paymentmode2" /></label>
                                                                <label class="radio inline">
                                                                    <asp:RadioButton ID="RadioButton13" runat="server" Checked="false" Text="Permanent Residential Address"
                                                                        GroupName="paymentmode2" /></label>

                                                            </td>
                                                          


                                                        </tr>
                                                        <tr class="frm-lft-clr-main border-bottom">
                                                            <td></td>
                                                            <td></td>

                                                            <td align="right">
                                                                <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Text="Add" OnClientClick="return validation();"
                                                                    CssClass="btn btn-primary"></asp:Button></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="5">
                                                                <div class="widget-content">
                                                                    <asp:GridView ID="GridView8" runat="Server" Width="100%" OnRowDeleting="GridAddressUpload_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                        AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                        HorizontalAlign="Left" CellPadding="4">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="ID Type" HeaderStyle-Width="18%">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdf2" runat="server" Value='<%# Eval("autoID") %>' />
                                                                                    <asp:Label ID="lblTridtpes" runat="Server" Text='<%# Eval("ID_Type")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Others" HeaderStyle-Width="18%" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCondothers" runat="Server" Text='<%# Eval("Others")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Address Type" HeaderStyle-Width="16%" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblffilekgh" runat="Server" Text='<%# Eval("Address_Type")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="File" HeaderStyle-Width="16%">
                                                                                <ItemTemplate>
                                                                                    <a href="../upload/employeedocuments/<%#DataBinder.Eval(Container.DataItem,"File")%>" target="_blank" class="link059">View File</a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton
                                                                                        CssClass="link09" ID="LinkButton3697" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>


                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="Button3" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <br />
                                            <tr>
                                                <td colspan="2" class="txt02"><b>Other Documents</b>
                                                </td>
                                            </tr>
                                            <hr size="4px" style="background-color: gray" />
                                            <table id="Table5" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">


                                                <tr>

                                                    <td class="frm-rght-clr123 border-bottom" width="20%">Document Name</td>
                                                    <td class="frm-rght-clr123 border-bottom" width="25%">
                                                        <asp:TextBox ID="TextBox73" runat="server" CssClass="span7" TextMode="SingleLine" placeholder="Max 50 Chars.." Width="" MaxLength="50"></asp:TextBox>


                                                    </td>


                                                    <td class="frm-rght-clr123 border-bottom">

                                                        <asp:FileUpload ID="FileUpload4" runat="server" Width="287px" ToolTip="Upload File here" />&nbsp;
                                                    </td>



                                                </tr>
                                                <tr class="frm-lft-clr-main border-bottom">
                                                    <td></td>
                                                    <td></td>

                                                    <td align="right">
                                                        <asp:Button ID="Button4" OnClick="Button4_Click" runat="server" Text="Add" OnClientClick="return validation();"
                                                            CssClass="btn btn-primary"></asp:Button></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5">
                                                        <div class="widget-content">
                                                            <asp:GridView ID="GridView9" runat="Server" Width="100%" OnRowDeleting="GridOtherDoc_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                HorizontalAlign="Left" CellPadding="4">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Others" HeaderStyle-Width="18%" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdf67" runat="server" Value='<%# Eval("autoID") %>' />
                                                                            <asp:Label ID="lblCongyjbhe" runat="Server" Text='<%# Eval("Others")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField HeaderText="File" HeaderStyle-Width="16%">
                                                                        <ItemTemplate>
                                                                            <a href="../upload/employeedocuments/<%#DataBinder.Eval(Container.DataItem,"File")%>" target="_blank" class="link053">View File</a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-Width="10%">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton
                                                                                CssClass="link045" ID="LinkButton361" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>

                                                 <tr id="Tr34" runat="server" visible="false">
                                                    <td colspan="4">
                                                        <div class="widget-body">

                                                            <div class="form-actions no-margin">
                                                                <asp:Label ID="Label19" runat="server" EnableViewState="False"></asp:Label>
                                                                <asp:Button ID="Button12" runat="server" align="right" CssClass="btn btn-primary pull-right" OnClick="btngeneralsubmit_Click"
                                                                    Text="Submit" />
                                                                <%-- OnClientClick="return ValidateSubmitData();"--%>
                                                            </div>

                                                        </div>

                                                    </td>
                                                </tr>
                                            </table>
      </table>
                                              </p>
                                            </div>
                                            <br />
                                            <div>
                                                <p>
                                                    <!-- Employee Upload Details -->

                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" class="txt02" style="height: 13px">Upload Details<p style="color: red">(Supported Files are PDF,PNG,BMP,JPG,GIF)</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123" width="55%">
                                                                <asp:Label ID="lbl_Default1" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="45%">
                                                                <asp:Label ID="lbl_file1" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft1" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fu_dft1"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label6" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default2" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file2" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft2" runat="server" Width="287px" ToolTip="Upload File here"  visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="fu_dft2"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label5" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default3" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file3" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft3" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="fu_dft3"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label1" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default4" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file4" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft4" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="fu_dft4"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label7" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default5" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file5" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft5" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="fu_dft5"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label8" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default6" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file6" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft6" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="fu_dft6"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label9" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default7" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file7" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft7" runat="server" Width="287px" ToolTip="Upload File here"  visible="false" />&nbsp;<br />
                                              <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="fu_dft7"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />--%>
                                                                <asp:Label ID="Label10" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123  border-bottom">
                                                                <asp:Label ID="lbl_Default15" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123  border-bottom">
                                                                <asp:Label ID="lbl_file15" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft15" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="fu_dft5"
                                                    ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..." ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label18" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default8" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file8" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft8" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                    ControlToValidate="fu_dft8" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label11" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                <asp:Label ID="lbl_Default9" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_file9" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft9" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                    ControlToValidate="fu_dft9" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label12" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default10" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file10" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft10" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                    ControlToValidate="fu_dft10" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label13" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default11" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file11" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft11" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                    ControlToValidate="fu_dft11" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label14" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default12" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file12" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft12" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                    ControlToValidate="fu_dft12" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label15" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default13" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file13" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft13" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                    ControlToValidate="fu_dft13" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label16" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>

                                                        <tr id="others" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default14" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file14" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft14" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                    ControlToValidate="fu_dft14" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label17" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" visible="false">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default16" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file16" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft16" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server"
                                                    ControlToValidate="fu_dft16" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label21" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr visible="false" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default17" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file17" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft17" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                    ControlToValidate="fu_dft17" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label24" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr visible="false" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default18" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file18" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft18" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server"
                                                    ControlToValidate="fu_dft18" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label27" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr visible="false" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default19" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file19" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft19" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server"
                                                    ControlToValidate="fu_dft19" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label30" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr visible="false" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default20" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file20" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft20" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server"
                                                    ControlToValidate="fu_dft20" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label33" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr visible="false" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default21" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file21" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft21" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server"
                                                    ControlToValidate="fu_dft21" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label36" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr visible="false" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default22" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file22" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft22" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server"
                                                    ControlToValidate="fu_dft22" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label39" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr visible="false" runat="server">
                                                            <td class="frm-lft-clr123 border-bottom">
                                                                <asp:Label ID="lbl_Default23" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Label ID="lbl_file23" runat="server" Text=""></asp:Label><br />
                                                                <asp:FileUpload ID="fu_dft23" runat="server" Width="287px" ToolTip="Upload File here" visible="false" />&nbsp;
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server"
                                                    ControlToValidate="fu_dft23" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                    ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator><br />
                                                                <asp:Label ID="Label42" runat="server" Text="(Replace Existing File)"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                    </table>

                                                    <div class="form-actions no-margin" style="text-align: right">
                                                        <asp:Label ID="Label3" runat="server" EnableViewState="False"></asp:Label>
                                                        <asp:Button ID="btngeneralsubmit" runat="server" CssClass="btn btn-primary " OnClick="btngeneralsubmit_Click"
                                                            Text="Submit" OnClientClick="return ValidateSubmitData();" />
                                                    </div>

                                                    <p>
                                                    </p>

                                                    <p>
                                                    </p>

                                                    <p>
                                                    </p>

                                                </p>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>
                        <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>

                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>

    </form>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/moment.js" type="text/javascript"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js" type="text/javascript"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js" type="text/javascript"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js" type="text/javascript"></script>
    <script src="../js/custom.js" type="text/javascript"></script>

    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>

    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>
</body>
</html>

