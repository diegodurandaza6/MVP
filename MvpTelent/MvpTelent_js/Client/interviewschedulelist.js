function GetJobDetailbyId(Id) {
    var url = "/Client/JobDetail?Ids=" + Id;
    window.open(url);
}
function selectvalue(title, Id, location) { 
    if (Id != "00")
    {
        if (location != "") {
            $("#jobLocationid").text(title + ' - ' + location);
        } else {
            $("#jobLocationid").text(title);
        }
        $("#JobId").val(Id);
    } 
}
function ActiveTab(tabId) {
    debugger;
    var JobId = $("#JobId").val();
    var url = "/Client/interviewschedulelist?JIds=" + JobId + "&TabId=" + tabId + "&Id=" + 3
    window.location.href = url;
}
function getComplateInterviewlistbyId(Id) {

    var JobId = $("#JobId").val();
    var url = "/Client/interviewschedulelist?JIds=" + JobId + "&TabId=3&Id=" + Id
    window.location.href = url;
}
 
function getInterviewByTitle() {
    
    var JobId = $("#JobId").val(); 
    var UpComingInterviewType = $("#UpComingInterviewType").val(); 
    var url = "/Client/interviewschedulelist?JIds=" + JobId+ "&TypeId=" + UpComingInterviewType
    window.location.href = url;
}
function ResetInterviewByTitle() {
    var url = "/Client/interviewschedulelist";
    window.location.href = url;
}
function Interviewdetailpopup(Id) {
    model = {
        Id: Id
    }
    $.get("/Client/Interviewdetailpopup", model, function (response) {
        $("#Interviewdetail_PopUp").html(response);
        $("#Interviewdetail_PopUp").modal("show");
    });
}
function InterViewdelete(Id) {
    if (InterViewdeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Client/InterViewdelete", model, function (data) {
        setTimeout(function () { window.location.reload() }, 800);
        toastr.success(" Interview scheduled deleted successfully.");
    });
}
function InterViewdeletevalidation() {
    return confirm("Do you want to delete Interview?")
}
function Detail(Id, JobId) {
    var url = "/Client/detail?Ids=" + Id + "&JIds=" + JobId;
    window.location.href = url;
}
function PagerClick(CurrentPageIndex) {
    var JobId = $("#JobId").val();
    var UpComingInterviewType = $("#UpComingInterviewType").val();
    url = "/Client/interviewschedulelist?CurrentPageIndex=" + CurrentPageIndex + "&JIds=" + JobId + "&TypeId=" + UpComingInterviewType
   
    window.location.href = url;
}
function CompletedPagerClick(CurrentPageIndex , Id) {
    var JobId = $("#JobId").val();
    var TabId = 3; 
    url = "/Client/interviewschedulelist?pId=" + CurrentPageIndex + "&JIds=" + JobId + "&TabId=" + TabId + "&Id=" + Id
    window.location.href = url;
}
function InterviewSchedulepopup_Client(Id, ClientId, CandidateId, JobId) {

    model = {
        Id: Id,
        ClientId: ClientId,
        CandidateId: CandidateId,
        JobId: JobId

    }
    $.get("/Client/ClientInterviewSchedulepopup", model, function (response) {
        $("#CreateInterview_PopUp").html(response);
        $("#CreateInterview_PopUp").modal("show");

    });
}
