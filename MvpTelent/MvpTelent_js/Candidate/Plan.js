

function PlanCreatepopup(Id)
{
     
    model = {
        Id: Id
    }
    $.get("/Admin/Candidate/PlanCreatepopup", model, function (response) {

        $("#Plancreate_PopUp").html(response);
        $("#Plancreate_PopUp").modal("show");

    });
}
function CreatePlan(Id)
{
     
    CreatePlanvalidation();
    if ($("#addplanform").valid()) { 
    model = {
        Id: Id,
        Name: $("#username").val(),
        Price: $("#Price").val(),
        noofjob: $("#noofjob").val() ,
        noofinterview: $("#noofinterview").val() ,
        noofsubmission: 0 , 
        Description: $("#Description").val(), 
        PlanTypeId: $("#PlanTypeId").val(),
        PlanStatusId: $("#PlanStatusId").val(),
        Subscription: $("#Subscription").val()
        }
        debugger;
        $.post("/Admin/Candidate/CreatePlan", model, function (data) {
        if (Id == 0) {
            toastr.success("Plan created successfully.");
            setTimeout(function () { window.location.reload() }, 600);
        } else {
            toastr.success("Plan updated successfully.");
            setTimeout(function () { window.location.reload() }, 600);
        }
    });
    }
}

function CreatePlanvalidation() {
    $("#addplanform").validate({
        rules: {
            PlanTypeId: {
                required: true,
            },
            Subscription: {
                required: true,
            },
            username: {
                required: true,

            },
            Price: {
                required: true,
                number: true
            },
            
            PlanStatusId: {
                required: true,

            },
            noofjob: {
                required: true,
                number: true
            },
            noofinterview: {
                required: true,
                number: true
            },
            noofsubmission: {
                required: true,
                number: true
            }
        }
    });
}

function PlanDelete(Id)
{
    if (PlanDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.post("/Admin/Candidate/PlanDelete", model, function () {

        setTimeout(function () { window.location.reload() }, 2000);
        toastr.success("Plan  deleted successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}

function PlanDeletevalidation() {
    return confirm("Do you really want to delete this plan?")
}

function PlanDetail(Id)
{
     
    model = {
        Id: Id
    }
    $.get("/Admin/Candidate/PlanDetailpopup", model, function (response) {

        $("#PlanDetail_PopUp").html(response);
        $("#PlanDetail_PopUp").modal("show");
    });
}

function getPlanByStatus() {
    var planStatus = $("#PlanStatusId").val();
    var PlanTypeId = $("#PlanTypeId").val();
    var url = "/Admin/Candidate/Plan?PlanStatusId=" + planStatus + "&PlanTypeId=" + PlanTypeId;
    window.location.href = url;
}

function ResetPlan() {
    var url = "/Admin/Candidate/Plan";
    window.location.href = url;
}