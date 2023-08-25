function paymentbystripe(Amount) {
    debugger;
    paymentformvalidation();
    if ($("#paymentform").valid()) {
        model = {
            Amount: Amount,
        }
        $.post("/Paypal/StripePayment", model, function (data) {
            
        })
    }
}



function paymentbypaypal() {
    debugger;
    paymentformvalidation(); 
    if ($("#paymentform").valid())
    {
        url = "/Paypal/Paypalvtwo";
        window.location.href = url;
    } 
} 
function paymentformvalidation() {
    $("#paymentform").validate({
        rules: {
            chkid: {
                required: true
            }
        }
    });
}


function makepaymentsubscription(pId, subscriptionID, orderID) {
    model = {
        subscriptionID:  subscriptionID,
        OrderID:  orderID,
        PlanId: pId
    };
    $.post("/Paypal/MakePaymentSuccess", model, function () {
        url = "/Home/success";
        setTimeout(function () { window.location.href = url; }, 300);
    });
} 


function MakePayment(planId, Amount) {
    
    PaymentformValidation();
    if ($("#Paymentform").valid()) {
        //var matchvalue = '/';
        //if (!$("#CardExpiry").val().match(/matchvalue/g)) {
        //    toastr.warning("Invalid Request ! Please check card expiry");
        //    return false;
        //}
        if (MakePaymentConfirmation() == false) {
            return false;
        }
        $("#btnMakePayment").text('Processing...');
        $("#btnMakePayment").attr("disabled", true);

        model = {
            PlanId: planId,
            CardTypeId: $("#CardTypeId").val(),
            CardHolderName: $("#CardHolderName").val(),
            PlanName: $("#hPlanName").val(),
            CardNumber: $("#CardNumber").val().replace(/ /g, ''),
            CardExpiry: $("#CardExpiry").val(),
            CVVNumber: $("#CVVNumber").val(),
            Amount: Amount,
        }

        $.post("/Paypal/MakePaymentByCard", model, function (data)
        {
            if (data.result == 1) {
                toastr.success("Payment successful.");
                var Url = "/Home/Payment?pid=" + 0;
                setTimeout(function () { window.location.href = Url; }, 500);
            }
            else {
                toastr.warning("Invalid Request! ");
               // setTimeout(function () { window.location.reload() }, 900);
            }
        })
        $("#btnMakePayment").text('Make Payment');
        $("#btnMakePayment").attr("disabled", false);
    }
}
function Tryagaing(Id) {

    var url = "/Home/Payment?pid=" + Id;
    window.location.href = url;

}

function gotopayment(Id) {
    if (Id == 2) {
        var url = "/Client/paymenthistory";
        window.location.href = url;
    } else {
        var url = "/Candidates/paymenthistory";
        window.location.href = url;

    }
}



function PaymentformValidation() {
    $("#Paymentform").validate({
        rules: {
            CardTypeId: {
                required: true
            },
            CardHolderName: {
                required: true
            },
            CardNumber: {
                required: true,
            },
            CardExpiry: {
                required: true,
            },
            CVVNumber: {
                required: true,
            }


        }


    });
}
function MakePaymentConfirmation() {

    return confirm("Do you really want to make payment ?.");
}



function MakePayment_Confirmation() {

    return confirm("Do you really want get this plan ?.");
}
function makefreeplan(planId) {
    paymentformvalidation();
    if ($("#paymentform").valid()) {
        if (MakePayment_Confirmation() == false) {
            return false;
        }
        $("#btnMakePayment").text('Processing...');
        $("#btnMakePayment").attr("disabled", true);

        model = {
            PlanId: planId,
        }
        $.post("/Home/MakeFreePayment", model, function (data) {
            if (data.result == 1) {
                toastr.success("Your plan active  successful.");
                var Url = "/Candidates/paymenthistory";
                setTimeout(function () { window.location.href = Url; }, 500);
            }
            else {
                toastr.warning("Invalid Request! ");
                setTimeout(function () { window.location.reload() }, 900);
            }
        })
    }
   
}
 