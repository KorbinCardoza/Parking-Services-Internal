

function typeSelectedChange() {
    var type = document.getElementById("ComplaintTypeDD").value;


    if (type == "5") { //Meter Malfunction


        document.getElementById("MeterIDtxt").style.display = "block";
        document.getElementById("MeterSttxt").style.display = "block";
        document.getElementById("Paymenttypetxt").style.display = "block";

        document.getElementById("PaymentAmounttxt").style.display = "block";



    } else {

        document.getElementById("MeterIDtxt").style.display = "none";
        document.getElementById("MeterSttxt").style.display = "none";
        document.getElementById("Paymenttypetxt").style.display = "none";

        document.getElementById("PaymentAmounttxt").style.display = "none";
        document.getElementById("PaymentLastFourtxt").style.display = "none";
    }


    if (type == "6") { //if Forgot My Permit

        document.getElementById("Locationtxt").style.display = "block";


    } else {
        document.getElementById("Locationtxt").style.display = "none";
        document.getElementById("PaymentLastFourtxt").style.display = "none";
    }




}

function paymentSelectedChange() {
    var paymenttype = document.getElementById("PaymentTypeDD").value;
    if (paymenttype == "Credit") {
        document.getElementById("PaymentLastFourtxt").style.display = "block";
    } else {
        document.getElementById("PaymentLastFourtxt").style.display = "none";
    }
}


function Showall() {

    var b = document.getElementById("hideshow");
    var e = document.getElementById("hiddeninfo");


    if (e.style.display == 'block') {
        e.style.display = 'none';

        $(".glyphicon").removeClass("glyphicon-minus").addClass("glyphicon-plus");
    }
    else {
        e.style.display = 'block';
        $(".glyphicon").removeClass("glyphicon-plus").addClass("glyphicon-minus");


    }
}





