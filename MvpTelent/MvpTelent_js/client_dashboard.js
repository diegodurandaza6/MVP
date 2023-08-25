function jobapplicantlist(JobId, jobStatus) {
    var url = "/Client/applicant?JobId=" + JobId + "&jobStatus=" + jobStatus;
    window.location.href = url;
}
function GetJobDetailbyId(Id) {
    var url = "/Client/JobDetail?Ids=" + Id;
    window.location.href = url;
}
function getApplicantlistview(JobId, jobStatus) {
    var url = "/Client/applicant?JobId=" + JobId + "&jobStatus=" + jobStatus;
    window.location.href = url;
}
function Jobs() {
    var url = "/Client/JobList";
    window.location.href = url;
}
function Applicantlist() {
    var url = "/Client/mycandidate";
    window.location.href = url;
}
function Favoritelist() {
    var url = "/client/myfavorite";
    window.location.href = url;
}
function sentitem() {
    var url = "/Client/ClientenquireyList";
    window.location.href = url;
}
function getindexapplicantdetailpage(Id, jobId) {
    var url = "/Client/detail?Ids=" + Id + "&JobId=" + jobId;
    window.location.href = url;
}
function jobdetail(JobId) {
    debugger
    var url = "/Client/JobDetail?ids=" + JobId;
    window.location.href = url;
}
function getinterviewlistbyjobId(JobId) {
    var url = "/Client/interviewschedulelist?JIds=" + JobId;
    window.location.href = url;
}
function Interviewslist() {
    url = '/Client/interviewschedulelist';
    window.location.href = url;
}


function mycandidatelist() {
    url = '//client/myfavorite';
    window.location.href = url;
}


function Detailby_id(Id, JobId) {
    var url = "/Client/detail?Ids=" + Id + "&JIds=" + JobId;
    window.location.href = url;
}