function PaymentHistoryhideshow(id)
{
    debugger;
    if (id == 1) {
        $("#tblPaymentHistory").show()
        $("#btnPaymentHistoryshow").hide()
        $("#btnPaymentHistoryHide").show()
    } else
    {
        $("#tblPaymentHistory").hide()
        $("#btnPaymentHistoryshow").show()
        $("#btnPaymentHistoryHide").hide()
    } 
}



function plandetailbyid(Id) {
    model = { Id: Id }
    $.get("/Home/plandetails", model, function (response) {
        $("#plandetail_popup").html(response);
        $("#plandetail_popup").modal("show");
    });
}


function Renewpayment(Id, pId) {
    if (RenewpaymentConfirmation() == false) {
        return false;
    }
    model = {
        UserId: Id,
        p_Id: pId,
    }
    $.get("/Home/Renewpayment", model, function (data) {
        if (data == 1) {
            toastr.success("Subscription renew successfully.");
            setTimeout(function () { location.reload(); }, 400);
        } else {
            toastr.warning("Something went wrong.");
        }
    });
}
function RenewpaymentConfirmation() {
    return confirm(" Do you really want renew this subscription?");
}



function stoppayment(Id, pId) {

    if (stoppaymentConfirmation() == false) {
        return false;
    }
    model = {
        UserId: Id,
        p_Id: pId,
    }
    $.get("/Home/stoppayment", model, function (data) {
        if (data == 1) {
            toastr.success("Payment temporary stoped successfully.");
            setTimeout(function () { location.reload(); }, 400);
        } else {
            toastr.warning("Something went wrong.");
        }
    });
}
function stoppaymentConfirmation() {
    return confirm(" Do you really want to temporary stop?");
}


function PagerClick(CurrentPageIndex) {
    url = "/Client/paymenthistory?CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}
function Favoritelist() {
    var url = "/client/myfavorite";
    window.location.href = url;
}