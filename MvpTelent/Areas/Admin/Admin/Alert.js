

function getSearchalertjob() {
     
    var Email = $("#email").val();
    var AlertId = $("#AlertId").val();
    var url = "/Admin/Admin/Alert?Email=" + Email + "&AlertId=" + AlertId;
    window.location.href = url;
}

function ResetSearchjobalert() {
    var url = "/Admin/Admin/Alert";
    window.location.href = url;
}




function alertunactiveJobbyId(Id, StatusId) {
     
    if (StatusId == 1) {
        if (alertunactiveJobbyIdvalidation() == false) {
            return false;
        }

    }
    else {
        if (alertactiveJobbyIdvalidation() == false) {
            return false;
        }
    }

    model = {
        Id: Id,
        StatusId: StatusId
    }
    $.post("/Admin/Admin/alertunactiveJobbyId", model, function () {

        toastr.success("Alert Status Changed Successfully.");
        setTimeout(function () { window.location.reload(); }, 800);
    });
}

function alertunactiveJobbyIdvalidation() {
    return confirm("Do you really want to inactive this alert ?");
}

function alertactiveJobbyIdvalidation() {
    return confirm("Do you really want to active this alert ?");
}