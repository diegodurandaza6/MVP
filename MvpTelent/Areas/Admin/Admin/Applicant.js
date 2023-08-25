function getApplicantList(Id) {
     
    var jobStatus = $('#jobStatus').val();
    var JobId = $('#JobId').val();
    var jobytpeid = $('#jobytpeid').val();
    var CompanyId = $('#CompanyId').val();
    /*var url = "/Admin/Candidate/Applicant?JIds=" + JobId + "&Id=" + 1 + "&jobStatus=" + jobStatus + "&tid=" + jobytpeid + "&CompanyId=" + CompanyId;*/
    debugger;
    var url = "/Admin/Candidate/Applicant?JobId=" + JobId + "&Id=" + 1 + "&jobStatus=" + jobStatus + "&tid=" + jobytpeid + "&CompanyId=" + CompanyId;
    window.location.href = url;
}


function getjobListbytype(Id) {
   
    var jobStatus = $('#jobStatus').val();
    var JobId = $('#JobId').val();
    var jobytpeid = $('#jobytpeid').val();
    var url = "/Admin/Candidate/Applicant?JobId=" + JobId + "&Id=" + Id + "&jobStatus=" + jobStatus + "&tid=" + jobytpeid;
    window.location.href = url;
} 

 

function Reset() {
    var url = "/Admin/Candidate/Applicant";
    window.location.href = url;
} 

function CandidateDetail(Id, JobId) {


    
    var url = "/Admin/Candidate/detailedprofile?Ids=" + Id + "&JIds=" + JobId;
   
    window.location.href = url;
}

function ApplicantDeleteConfirm() {
    return confirm(" Do you really want to deleted this applicant?");
}

function ApplicantDelete(Id) {

    if (ApplicantDeleteConfirm() === false) {
        return false;
    }
    model = {
        Id: Id
    };
     
    $.get("/Admin/Candidate/ApplicantDelete", model, function (data) {
        toastr.success("Applicant deleted successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}

function PagerClick(CurrentPageIndex) {
     
    url = "/Admin/Candidate/applicant?CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}



