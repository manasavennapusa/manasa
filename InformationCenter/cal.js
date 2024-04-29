
           
        function mul() {

            
            var txtFirstNumberValue = document.getElementById('TextBox1').value;
            var txtSecondNumberValue = -0.5;
            var result = (txtFirstNumberValue) * (txtSecondNumberValue);
            document.getElementById("TextBox7").value = result;


        }

function mul1() {


    var txtFirstNumberValue = document.getElementById('TextBox2').value;
    var txtSecondNumberValue = -0.5;
    var result = (txtFirstNumberValue) * (txtSecondNumberValue);
    document.getElementById("TextBox8").value = result;


}

function mul2() {


    var txtFirstNumberValue = document.getElementById('TextBox3').value;
    var txtSecondNumberValue = -0.5;
    var result = (txtFirstNumberValue) * (txtSecondNumberValue);
    document.getElementById("TextBox9").value = result;


}

function mul3() {


    var txtFirstNumberValue = document.getElementById('TextBox4').value;
    var txtSecondNumberValue = 0.5;
    var result = (txtFirstNumberValue) * (txtSecondNumberValue);
    document.getElementById("TextBox10").value = result;


}

function mul4() {


    var txtFirstNumberValue = document.getElementById('TextBox5').value;
    var txtSecondNumberValue = 0.5;
    var result = (txtFirstNumberValue) * (txtSecondNumberValue);
    document.getElementById("TextBox11").value = result;


}

function mul5() {


    var txtFirstNumberValue = document.getElementById('TextBox6').value;
    var txtSecondNumberValue = 0.5;
    var result = (txtFirstNumberValue) * (txtSecondNumberValue);
    document.getElementById("TextBox12").value = result;


}

function add() {

    var a = document.getElementById('TextBox7').value;
    var b = document.getElementById('TextBox8').value;
    var c = document.getElementById('TextBox9').value;
    var d = document.getElementById('TextBox10').value;
    var e = document.getElementById('TextBox11').value;
    var f = document.getElementById('TextBox12').value;
    var result = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e) + parseFloat(f);
    document.getElementById("lblTotal").value = result;


}

