
function capitalizeMe(obj) {
    val = obj.value;
    newVal = '';
    val = val.split(' ');
    for (var c = 0; c < val.length; c++) {
        newVal += val[c].substring(0, 1).toUpperCase() + val[c].substring(1, val[c].length).toLowerCase() + ' ';
    }
    obj.value = newVal;
}

function isChar() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char')
        event.returnValue = false;
    }
}

function isCharOrSpace() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z\s]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}

function isChar_Space_dot_dash_ifin() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z\.\-\s]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}
function isChar_Space_dash() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z\-\s]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}
function isCharOrSpace_dot() {
    
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z\.\s]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}
function isChar_Number_slash() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9\/]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}

function isChar_Number_space() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9\s]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}

function isChar_Number_space_slash() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9\/\s]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}

function isChar_Number_Space_dot_dash_ifin() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9\s\.\-\']/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}

function isChar_Number_space_ifin() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9\s\-]/;
    if (!filter.test(ch)) {
        //alert('Please enter only Char with space')
        event.returnValue = false;
    }
}

function isAlphaNumeric() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9]/;
    if (!filter.test(ch)) {
       // alert('Please enter only AlphaNumeric')
        event.returnValue = false;
    }
}
//-------------Address-------------
function isAlphaNumeric_slash_infin_dot_Ash() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']/;
    if (!filter.test(ch)) {
        // alert('Please enter only AlphaNumeric')
        event.returnValue = false;
    }
}


function isNumber() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /^[0-9]+$/;
    if (!filter.test(ch)) {
       // alert('Please enter only Numbers')
        event.returnValue = false;
    }
}
//-----rating-------------
function isRating() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /^[1-5]+$/;
    if (!filter.test(ch)) {
        // alert('Please enter only Numbers')
        event.returnValue = false;
    }
}

function isNumber_dot_coma() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /^[0-9\.\,]+$/;
    if (!filter.test(ch)) {
        // alert('Please enter only Numbers')
        event.returnValue = false;
    }
}

function isNumber_dot() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /^[0-9\.]+$/;
    if (!filter.test(ch)) {
        // alert('Please enter only Numbers')
        event.returnValue = false;
    }
}
function isNumber_slash() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /^[0-9\/]+$/;
    if (!filter.test(ch)) {
        // alert('Please enter only Numbers')
        event.returnValue = false;
    }
}
function phonenumbervalidation() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /^[7-9][0-9]{9}$/;
    if (!filter.test(ch)) {
       // alert('Please enter only Numbers, starts with 7 or 8 or 9')
        event.returnValue = false;
    }
}

function enterdate(evt) {

    // alert('Please use calender icon to enter date')
    return false;
}

//----------------------for Description and Reason, comments

function isalphanumericsplchar() {
    var ch = String.fromCharCode(event.keyCode);
    var filter = /[a-zA-Z0-9 .\_\-\,\(\)\'\"\&\?\!\:\/\s]/;
    if (!filter.test(ch)) {
        // alert('Please enter only Numbers')
        event.returnValue = false;
    }
}

