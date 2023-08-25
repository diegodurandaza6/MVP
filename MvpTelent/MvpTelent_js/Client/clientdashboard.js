function DetailedProfile() {
    var url = "/Candidates/myProfile";
    window.location.href = url;
}
function confidentialprofile() {
    var url = "/Candidates/confidentialprofile";
    window.location.href = url;
}

function AppliedJobscount() {
    var url = "/Candidates/MyappliedJob";
    window.location.href = url;
}
function SavedJobs() {
    var url = "/Candidates/MySavedJobList";
    window.location.href = url;
}
function Currentplan() {
    var url = "/Candidates/paymenthistory";
    var url = "/Candidates/paymenthistory";
    window.location.href = url;
}
function Currentplanexpried() {
    var url = "/Candidates/paymenthistory";
    window.location.href = url;
}



function Candidate_GeneralMessage() {
    $.get("/Candidates/sendgeneralmessagespopup", function (response) {
        $("#dv_CandidateSendGeneralMessagesPopup").html(response);
        $("#dv_CandidateSendGeneralMessagesPopup").modal("show");
    });
}
function SaveCandidateSendGeneralMessages() {
    SaveCandidateSendGeneralMessagesvalidation();
    if ($("#GeneralMessage").valid()) {
        model = {
            Title: $('#title').val(),
            Description: $('#Description').val(),
            ToId: 1
        } 
        $.post("/Candidates/sendgeneralmessages", model, function (response) {
            toastr.success("Message sent successfully.");
            setTimeout(function () { window.location.reload(); }, 1200);
        });
    }
}
function PagerClick(CurrentPageIndex) {
    url = "/Candidates/generalmessagelist?CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}
function SaveCandidateSendGeneralMessagesvalidation() {
    $("#GeneralMessage").validate({
        rules: {
            title: {
                required: true,
            },
            Description: {
                required: true,
            },
        }
    });
}
function Getgeneralmessagesdetail(Id) {
    var url = "/Candidates/generalmessagedetail?Ids=" + Id;
    window.location.href = url;
}

