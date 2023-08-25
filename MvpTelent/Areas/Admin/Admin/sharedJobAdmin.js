function PagerClick(CurrentPageIndex) {

    var ClientId = $("#ClientId").val();
    var JobStatusId = $("#JobStatusId").val();
    var url = "/Admin/Admin/sharedJob?ClientId=" + ClientId + "&JobStatusId=" + JobStatusId + "&pageno=" + CurrentPageIndex;


    window.location.href = url;
}


function getSharedjobById() {
    var ClientId = $("#ClientId").val();
    var JobStatusId = $("#JobStatusId").val();

    var url = "/Admin/Admin/sharedJob?Ids=" + ClientId + "&JobStatusId=" + JobStatusId;
    window.location.href = url;
}
function ResetSharedjob() {
    var url = "/Admin/Admin/sharedJob";
    window.location.href = url;
}
function GetadminJobDetailbyId(Id) {
    var url = "/Admin/Admin/JobDetails?Ids=" + Id;
    window.location.href = url;
}
function movesubmittedprofile(JobId, JobStatusId) {
    var url = "/Admin/Candidate/Applicant?JobId=" + JobId + "&JobStatusId=" + JobStatusId;
    window.location.href = url;
}


function moveApplicants(JobId, JobStatusId) {
    var url = "/Admin/Candidate/Applicant?JobId=" + JobId + "&Id=" + 1 + "&jobStatus=" + JobStatusId + "&tid=" + 1;
    window.location.href = url;
}