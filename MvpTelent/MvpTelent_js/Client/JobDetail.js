function ClientInterviewstatuschangevalidation() {
    $("#clientform").validate({
        rules: {
            InterviewSId: {
                required: true,
            },
        }
    });
}
function ClientInterviewstatuschange(Id) {

    ClientInterviewstatuschangevalidation();
    if ($("#clientform").valid()) {
        model = {
            Id: Id,
            JobId: $("#JobId").val(),
            ContactIs: $("#InterviewSId").val(),
        }
        $.get("/Client/ClientInterviewstatuschange", model, function (data) {
            setTimeout(function () { window.location.reload(); }, 2000);
            toastr.success("Interview status updated successfully.");
        });
    }
}
function interviewStatusPopup(Id, InterviewSId, JobId) {
    model = {
        CandidateId: Id,
        InterviewSId: InterviewSId,
        JobId: JobId
    }
    $.get("/Client/ClientinterviewStatusPopup", model, function (response) {
        $("#InterviewStatusByid_Popup").html(response);
        $("#InterviewStatusByid_Popup").modal("show");
    });
}
function JobDetailDeletebyIdvalidation() {
    return confirm("Do you really want to delete this job?")
}
function GetEditJobbyId(Id) {
    var url = "/Client/Jobs?Ids=" + Id;
    window.location.href = url;
}
function jobapplicantlist(JobId, jobStatus) {

    var url = "/Client/applicant?JobId=" + JobId + "&jobStatus=" + jobStatus;
    window.location.href = url;
}
function JobDetailDeletebyId(Id) {
    if (JobDetailDeletebyIdvalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.get("/Home/JobDetailDeletebyId", model, function (data) {
            toastr.success("Job deleted  successfully.");
            var url = "/Client/JobList";
            window.location.href = url;
        });
}
function jobaplicatantbyid(Id) {
    var url = "/Client/applicant?JobId=" + Id;
    window.location.href = url;
}
function getApplicantListpage(Id, JobId) {
    var url = "/Client/detail?Ids=" + Id + "&JIds=" + JobId;
    window.location.href = url;
}