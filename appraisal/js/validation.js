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
function IsNumericDot(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
function isAlpha(keyCode) {

    return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9)

}

function isAddress(keyCode) {

    return ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9 || keyCode == 13 || keyCode == 51 || keyCode == 50)
}

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

function capitalizeMe(obj) {
    val = obj.value;
    newVal = '';
    val = val.split(' ');
    for (var c = 0; c < val.length; c++) {
        newVal += val[c].substring(0, 1).toUpperCase() + val[c].substring(1, val[c].length).toLowerCase() + ' ';
    }
    obj.value = newVal.trim();
}
