function selectJobId(title, Id, location) { 
    debugger
    if (Id == '0' || Id > 0)
    {
        if (location != "") {
            $("#jobLocationid").text(title + ' - ' + location);
        } else {
            $("#jobLocationid").text(title);
        }
        if (Id == '00') {
            $("#JobId").val('');
        } else {
            $("#JobId").val(Id);
        }
    }
    if (Id =="") {
        $("#JobId").val('');
        $("#jobLocationid").text(title);
    }
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
     
    $.get("/Home/ApplicantDelete", model, function (data) {
        toastr.success("Applicant deleted successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}
function GetClient_JobOnwerDetailById(Id) {
    model = {
        Id: Id
    }
    $.get("/Admin/Candidate/GetJobOnwerDetailById", model, function (data) {
        if (data.Email == null)
        {
           
            $('#lblLabel').text('');
            $('#lblName').text('');
            $('#lblEmail').text(''); 

        }
        else { 
            
            $('#lblLabel').text('Job Owner : ');
            $('#lblName').text(data.Name);
            $('#lblEmail').text('(' + data.Email + ')');
        }


    });
}

function ActiveTab(tabId ,jId,sId) {
     debugger
    url = "/Client/applicant?JobId=" + $('#JobId').val() + "&jobStatus=" + $('#jobStatus').val() + "&Id=" + tabId;
    window.location.href = url;
}
function Reset() {
     
    url = "/Client/applicant";
    window.location.href = url;
}


function CandidateDetail(Id, JobId)
{
    var url = "/Client/detail?Ids=" + Id + "&JIds=" + JobId;
    window.open(url);
}

function getApplicantList() {
     
      var jobStatus = $('#jobStatus').val();
    var JobId = $('#JobId').val();
    var url = "/Client/applicant?JobId=" + JobId + "&jobStatus=" + jobStatus;
    window.location.href = url;
}


function Clientnotepopup(Id,JobId)
{
    model = {
        Id: Id,
        JobId: JobId
    }
    $.get("/Client/Clientnotepopup", model, function (response) {
        $("#Clientnotepopup").html(response);
        $("#Clientnotepopup").modal("show");


    });
}

function clientNotesave(Id,JobId) {
    clientNotesavevalidation();
    if ($("#clientnoteform").valid()) {
        model = {
            Id: Id,
            JobId: JobId,
            ClientNote: $("#Cnote").val()
        }
        $.get("/Client/clientNotesave", model, function (data) {

            toastr.success(" Note saved successfully.");
            setTimeout(function () { window.location.reload() }, 800);

        });
    }
}

function clientNotesavevalidation()
{
    $("#clientnoteform").validate({
        rules: {
            Cnote: {
                required: true,
            },
           
        }
    });
}

function clientNotesDelete(Id)
{
    if (clientNotesDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.post("/Client/clientNotesDelete", model, function () {
        toastr.success(" Note Deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);


    });
}

function clientNotesDeletevalidation() {
    return confirm("Do you really want to remove this Note?");
}

function InterviewSchedulepopup(Id, CandidateId, JobId) {

    model = {
        Id: Id,
        CandidateId: CandidateId,
        JobId: JobId
    }
    $.get("/Client/ClientInterviewSchedulepopup", model, function (response) {
        $("#CreateInterview_PopUp").html(response);
        $("#CreateInterview_PopUp").modal("show");



    });

}






function getjobdetailpage(Id)
{
    var url = "/Client/JobDetail?Ids=" + Id;
    window.open(url, "_blank");
}


function gotolist(url)
{
    window.location.href = url;
}
