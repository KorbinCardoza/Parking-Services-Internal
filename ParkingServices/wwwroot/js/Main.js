window.onload = function () {

    document.getElementById('ComplaintTypeDD').addEventListener("change", function () {
        document.getElementById('firstname').removeAttribute('required');
        document.getElementById('lastname').removeAttribute('required');
        document.getElementById('emailaddress').removeAttribute('required');
        document.getElementById('phoneNumber').removeAttribute('required');
        document.getElementById('addressLine1').removeAttribute('required');
        document.getElementById('addressLine2').removeAttribute('required');
        document.getElementById('city').removeAttribute('required');
        document.getElementById('state').removeAttribute('required');
        document.getElementById('zip').removeAttribute('required');
        document.getElementById('ticketNum').removeAttribute('required');
        document.getElementById('Locationtxt').removeAttribute('required');
        document.getElementById('make').removeAttribute('required');
        document.getElementById('meterId').removeAttribute('required');
        document.getElementById('model').removeAttribute('required');
        document.getElementById('meterLocation').removeAttribute('required');
        document.getElementById('color').removeAttribute('required');
        document.getElementById('PaymentTypeDD').removeAttribute('required');
        document.getElementById('plateNumber').removeAttribute('required');
        document.getElementById('paymentAmount').removeAttribute('required');
        document.getElementById('details').removeAttribute('required');
        document.getElementById('lastFour').removeAttribute('required');
        document.getElementById('PermitNum').removeAttribute('required');
        document.getElementById('parkedLocation').removeAttribute('required');

    });

    document.getElementById('BottomButton').addEventListener("click", function () {
        var e = document.getElementById("ComplaintTypeDD");
        var value = e.options[e.selectedIndex].value;



        if (value == 8 ||
            value == 2 ||
            value == 10 ||
            value == 4 ||
            value == 11 ||
            value == 3) {

            document.getElementById('firstname').setAttribute('required', 'required');
            document.getElementById('lastname').setAttribute('required', 'required');
            document.getElementById('emailaddress').setAttribute('required', 'required');
            document.getElementById('details').setAttribute('required', 'required');
        }

        if (value == 7) {
            document.getElementById('firstname').setAttribute('required', 'required');
            document.getElementById('lastname').setAttribute('required', 'required');
            document.getElementById('emailaddress').setAttribute('required', 'required');
            document.getElementById('ticketNum').setAttribute('required', 'required');
            document.getElementById('details').setAttribute('required', 'required');
        }


        if (value == 1) {

            document.getElementById('firstname').setAttribute('required', 'required');
            document.getElementById('lastname').setAttribute('required', 'required');
            document.getElementById('emailaddress').setAttribute('required', 'required');
            document.getElementById('addressLine1').setAttribute('required', 'required');
            document.getElementById('city').setAttribute('required', 'required');
            document.getElementById('state').setAttribute('required', 'required');
            document.getElementById('zip').setAttribute('required', 'required');
            document.getElementById('make').setAttribute('required', 'required');
            document.getElementById('color').setAttribute('required', 'required');
            document.getElementById('plateNumber').setAttribute('required', 'required');
            document.getElementById('details').setAttribute('required', 'required');
        }


        if (value == 6) {

            document.getElementById('firstname').setAttribute('required', 'required');
            document.getElementById('lastname').setAttribute('required', 'required');
            document.getElementById('emailaddress').setAttribute('required', 'required');
            document.getElementById('PermitNum').setAttribute('required', 'required');
            document.getElementById('parkedLocation').setAttribute('required', 'required');
        }


        if (value == 5) {

            document.getElementById('firstname').setAttribute('required', 'required');
            document.getElementById('lastname').setAttribute('required', 'required');
            document.getElementById('emailaddress').setAttribute('required', 'required');
            document.getElementById('meterId').setAttribute('required', 'required');
            document.getElementById('meterLocation').setAttribute('required', 'required');
            document.getElementById('PaymentTypeDD').setAttribute('required', 'required');
            document.getElementById('paymentAmount').setAttribute('required', 'required');
            document.getElementById('addressLine1').setAttribute('required', 'required');
        }
        if (value == 9) {

            document.getElementById('addressLine1').setAttribute('required', 'required');
            document.getElementById('firstname').setAttribute('required', 'required');
            document.getElementById('lastname').setAttribute('required', 'required');
            document.getElementById('emailaddress').setAttribute('required', 'required');
            document.getElementById('PermitNum').setAttribute('required', 'required');
            document.getElementById('parkedLocation').setAttribute('required', 'required');
            document.getElementById('addressLine1').setAttribute('required', 'required');
        }
    });
};



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





