

function sendemail() {
    model = {
        Email: $("#email").val(),
        subject: $("#Subject").val(),
        description: $("#Desctiption").val()
    }
    $("#emailsend").text("Sending");
    $.get("/Home/sendemail", model, function (data) {
        toastr.success("Email sent  successfully.");
        setTimeout(function () { location.reload(); }, 600);
    });
}


function candidatesendemail() {
    debugger;
    if ($("#Actionfilter").val() == "1")
    {
        if ($("#accounttype").val() > 0) {
            if ($("#accounttype").val() != 2) {
                toastr.info("you are not authorized.");
                return false;
            }
        }
        else {
            toastr.info("Please login to continue.");
            $("#Actionfilter").val(0);
            return false;
        }
        var Ids = '';
        $.each($("input[name='candidateId']:checked"), function () {
            Ids += $(this).val() + ",";
        });
        if (Ids != '') {
            Ids = Ids.slice(0, -1);
        }
        if (Ids == '') {
            toastr.info("Please select candidate .");
            $("#Actionfilter").val(0);
            return false;
        }
        model = {
            Ids: Ids
        }
        $.get("/Home/candidatesendemail", model, function (response) {

            $("#candidatesendemail_PopUp").html(response);
            $("#candidatesendemail_PopUp").modal("show");
        });
    }
    else if ($("#Actionfilter").val() == "2")
    {
        debugger;
        if ($("#accounttype").val() > 0) {
            if ($("#accounttype").val() != 2) {
                toastr.info("you are not authorized.");
                return false;
            }
        }
        else {
            toastr.info("Please login to continue.");
            $("#Actionfilter").val(0);
            return false;
        }
         
        var Ids = '';
        $.each($("input[name='candidateId']:checked"), function () {
            Ids += $(this).val() + ",";
        });
        if (Ids == '') {
            toastr.info("Please select candidate .");
            $("#Actionfilter").val(0);
            return false;
        }
        if (Confirmation() === false) {
            return false;
        }
        $.each($("input[name='candidateId']:checked"), function () {
            model = {
                Id: $(this).val(),
                ClientId: $("#clientId").val(),
                Status: 0
            }
            debugger;
            $.get("/Client/favoritecandidate", model, function (data) {
            });
        });
        toastr.success("Candidate add to favorite successfully.");
    }
}

function Confirmation() {
    return confirm("Are you sure you want to favorite this candidates?");
}

function candidateshortlistbyid(Id) {
    if ($("#accounttype").val() > 0) {
        if ($("#accounttype").val() != 2) {
            toastr.info("you are not authorized.");
            return false;
        }
    }
    else {
        toastr.info("Please login to continue.");
        $("#Actionfilter").val(0);
        return false;
    }

    if (Confirmation() === false) {
        return false;
    }
    model = {
        Id: Id,
        ClientId: $("#clientId").val(),
        Status: 0
    }
    debugger;
    $.get("/Client/favoritecandidate", model, function (data) {
    });
    toastr.success("Candidate add to favorite successfully.");
}

function Addcandidateshortlistbyid(Id) {
    if ($("#accounttype").val() > 0) {
        if ($("#accounttype").val() != 2) {
            toastr.info("you are not authorized.");
            return false;
        }
    }
    else {
        toastr.info("Please login to continue.");
        $("#Actionfilter").val(0);
        return false;
    }

    if (Confirmation() === false) {
        return false;
    }
    model = {
        Id: Id,
        ClientId: $("#clientId").val(),
        Status: 0
    }
    debugger;
    $.get("/Client/AddTofavoritecandidate", model, function (data) {
        if (data.Status == 0) {
            toastr.success("Candidate add to favorite successfully.");
        }
        else {
            toastr.warning("Candidate has already been favorited.");
            
        }
    });
    
}

function jobalertpopup() {
    if ($("input[name='customSwitch6']:checked").val()) {
        jobalert(1);
    }
}

function jobalert(Id) {
     
    if (Id == 2) {
        model = {
            alertid: Id,
            JobTitle: $("#Title").val(),
            location: $("#autocomplete_search").val()
        }
    }
    else {
        model = {
            alertid: Id,
            JobTitle: $("#JobTitle").val(),
            location: $("#autocomplete_search").val()
        }
    }

  
    $.get("/Home/jobalertPopUp", model, function (response) {
        $("#jobalert_PopUp").html(response);
        $("#jobalert_PopUp").modal("show");
    });
}

function savejobalert(Id) {
    savejobalertvalidation();
    if ($("#formsavejobalertvalidation").valid()) {
        model = {
            alertid: Id,
            JobTitle: $("#keyword").val(),
            location: $("#Location").val(),
            AlertName: $("#AlertName").val(),
            Name: $("#Name").val(),
            Email: $("#Email").val()
        }
        $.post("/Home/savejobalert", model, function (data) {
            if (data == 1) {
                toastr.success("Alert saved successfully.");
            } else {
                toastr.info("Something went wrong.");
            }
        });
        setTimeout(function () { $('#jobalert_PopUp').modal('hide'); }, 900);
    }

}
function savejobalertvalidation() {
    $("#formsavejobalertvalidation").validate({
        rules: {
            keyword: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            Location: {
                required: true,

            },
            AlertName: {
                required: true,

            },
            Name: {
                required: true,
            }
        }
    });
}