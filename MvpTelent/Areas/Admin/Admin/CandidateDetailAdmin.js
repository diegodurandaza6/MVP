function deletecandidatetagvalidation() {
    return confirm("Are you sure delete this tags.");
}
function deletecandidatetag(Id) {
    if (deletecandidatetagvalidation() == false) {
        return false;
    }
    model = {
        Id: Id,
    }
    $.post("/Admin/Candidate/deletecandidatetag", model, function (data) {
        toastr.success("Candidate tags deleted successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}
function GetJobDetailbyId(Id) {
    var url = "/Admin/Admin/JobDetails?Ids=" + Id;
    window.open(url);
}
function Candidatetagvalue(CId) {
    if ($("#CandidateTagId").val().trim() === "") {
        return false;
    }
    model = {
        CId: CId,
        CandidateTag: $("#CandidateTagId").val(),
        TagtypeId: 1
    }
    $.get("/Admin/Candidate/Candidatetagvalue", model, function (data) {
        toastr.success("Tags saved successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}
function Interviewdetailpopup(Id) {
    model = {
        Id: Id
    }
    $.get("/Admin/Admin/Interviewdetailpopup", model, function (response) {
        $("#Interviewdetail_PopUp").html(response);
        $("#Interviewdetail_PopUp").modal("show");
    });
}


function ActiveTab(TabId, id) {
    debugger;

    url = "/Admin/Candidate/CandidateDetail?TabId=" + TabId + "&Ids=" + id;
    window.location.href = url;
}

