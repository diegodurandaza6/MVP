
function UploadAttachment() {

    if (window.FormData !== undefined) {
        var fileUpload = $("#Uploadfiles").get(0);
        var files = fileUpload.files;
        var fileData = new FormData();
        var fileName = '';
        for (var i = 0; i < files.length; i++) {

            fileData.append(files[i].name, files[i]);

            fileName += files[i].name;
            $('#lblUploadAttachmentName').text(fileName);
        }
    }

}

function CopyUrl(elementId) {
    var aux = document.createElement("input");
    aux.setAttribute("value", document.getElementById(elementId).innerHTML);
    document.body.appendChild(aux);
    aux.select();
    document.execCommand("copy");
    document.body.removeChild(aux);
    toastr.success(" Public Url Copied successfully.");
}

function getEnquiresByEmail() {

    var email = $('#email').val();
    /*var typeId = $('#enquiryPshipId').val();*/
    url = "/Admin/Admin/enquires?Email=" + email;
    window.location.href = url;

}
function Reset() {
    url = "/Admin/Admin/enquires";
    window.location.href = url;
}
function getmessagebyId(Id) {
    var Url = "/Admin/Admin/EnquiresDetail?Ids=" + Id;
    window.location.href = Url;

}


function jobdetailbyid(Id) {
    var Url = "/Admin/Admin/JobDetails?Ids=" + Id;
    window.location.href = Url;

}










function enquerydeleteConfirm() {
    return confirm("Do you really want to delete this inquiry?");
}

function enquerydelete(Id) {

    if (enquerydeleteConfirm() === false) {
        return false;
    }
    model = {
        Id: Id
    };

    $.get("/Admin/Admin/enquerydelete", model, function (data) {
        toastr.success("Enquiry deleted successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}

function Detail(Id) {

    var url = "/Admin/Candidate/detailedprofile?Ids=" + Id;
    window.open(url);
}


function replyenquire(Id) {

    //if ($("#reply").val().trim() == '') {

    //    return false;
    //}

    ReplyValidation();
    if ($("#replyform").valid()) {
        model = {
            Id: Id,
            Email: $('#Email').val(),
            Subject: $('#Subject').val(),
            replymessage: $('#reply').val(),
        };

        $.post("/Admin/Admin/replyenquire", model, function (data) {
            toastr.success("Reply sent successfully.");
            setTimeout(function () { location.reload() }, 600);
        });
    }

}

function ReplyValidation() {
    $("#replyform").validate({
        rules: {
            reply: {
                required: true
            }
        }
    });
}

function ClientsendqueryDelete(Id) {

    if (ClientsendqueryDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Home/ClientsendqueryDelete", model, function (data) {
        toastr.success("Record deleted successfully.");
        setTimeout(function () { location.reload() }, 600);
    })
}
function ClientsendqueryDeletevalidation() {
    return confirm(" Do you really want to deleted this send enquires?");
}

function getClientsendenquiresStatus() {
    var Email = $("#Email").val();
    var url = "/Admin/Admin/ClientSendenquery?Email=" + Email;
    window.location.href = url
}
function ResetSearch() {
    var url = "/Admin/Admin/ClientSendenquery";
    window.location.href = url
}

function GetClientenquireybyId(Id) {

    var url = "/Client/Details?Ids=" + Id;
    window.location.href = url;
}



function View(Id) {
    model = {
        Id: Id,
    }
    $.get("/Home/viewCandidate", model, function (data) {
        if (data.result == 1) {
            toastr.info("Sorry, the link has expired !");
        } else {
            window.open(data.Url, '_blank');
        }

    });
}

function GetClientsendenquireydetail(Id) {
    var url = "/Admin/Admin/Clientchatdetail?Ids=" + Id;
    window.location.href = url;
}
function ShowProgress() {
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("modal");
        $('body').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 200);
}


function sendconversationsaved(SendId, ClientId) {
    var kk = $("#massege").val();

    sendconversationsavedvalidation();
    // ShowProgress();
    if ($("#Uploadfiles").val() == "") {
        if ($('#msgchatform').valid()) {
            model = {
                Id: SendId,
                clientId: ClientId,
                Description: $("#massege").val()
            }

            $.post("/Client/sendconversationsaved", model, function (data) {
                var url = "/Client/Details?Ids=" + $("#messageid").val();
                window.location.href = url;
            });
        }
    }
    else {
        if (window.FormData !== undefined) {
            var fileUpload = $("#Uploadfiles").get(0);
            var files = fileUpload.files;
            var fileData = new FormData();
            var fileName = '';
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
                fileName += files[i].name;
                var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
            }
            fileData.append('Id', SendId);
            fileData.append('clientId', ClientId);
            fileData.append('Description', $("#massege").val());
            fileData.append('FileName', fileName);

            $.ajax({
                url: "/Client/sendconversationsaved",
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (data) {
                    var url = "/Client/Details?Ids=" + $("#messageid").val();
                    window.location.href = url;
                }
            });
        }
    }
}

function sendconversationsavedvalidation() {
    $("#msgchatform").validate({
        rules: {
            massege: {
                required: true
            },

        }
    });
}


function sendconversationsavedpopup(SendId, ClientId) {
    model = {
        Id: SendId,
        clientId: ClientId
    },
        $.get("/Client/sendconversationsavedpopup", model, function (response) {
            $("#sendenquireypopupid").html();
            $("#sendenquireypopupid").html(response);
        })
}


function sendClientconversationsaved(SendId, ClientId, Email, Name) {

    var msg = $("#massege").val().trim();
    var lblUploadAttachmentName = $("#lblUploadAttachmentName").text().trim();
    if (msg == '' && lblUploadAttachmentName == '') {
        return false;
    }
    ShowProgress();

    if (window.FormData !== undefined) {
        var fileUpload = $("#Uploadfiles").get(0);
        var files = fileUpload.files;
        var fileData = new FormData();
        var fileName = '';
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
            fileName += files[i].name;
            var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
        }
        fileData.append('Id', SendId);
        fileData.append('clientId', ClientId);
        fileData.append('Name', Name);
        //  fileData.append('Ids', $("#Ids").val().trim());
        fileData.append('Description', $("#massege").val());
        fileData.append('Email', Email);
        fileData.append('FileName', fileName);

        $.ajax({
            url: "/Admin/Admin/sendClientconversationsaved",
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (data) {
                //  sendconversationsavedpopup(SendId, ClientId, Email);
                toastr.success(" Message sent successfully.");
                var id = $("#EnquiresId").val();


                setTimeout(function () { window.location.reload() }, 800);

                //var url = "/Admin/Admin/Clientchatdetail?Ids=" + id;
                //window.location.href = url;
            }
        });
    }
}


function PagerClick(CurrentPageIndex) {

    var Email = $("#email").val();
    url = "/Admin/Admin/enquires?Email=" + Email + "&CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}


function viewpublicprofilebyId(Id) {

    var url = "/Admin/Candidate/detailedprofile?Ids=" + Id;
    window.open(url);
    // window.location.href = url;
}

function InterviewSchedulepopup(Id, ClientId, CandidateId, JobId) {

    model = {
        Id: Id,
        ClientId: ClientId,
        CandidateId: CandidateId,
        JobId: JobId

    }
    $.get("/Admin/Admin/InterviewSchedulepopup", model, function (response) {
        $("#CreateInterview_PopUp").html(response);
        $("#CreateInterview_PopUp").modal("show");

    });
}






function UpdateInterviewschedule(Id, ClientId, CandidateId, JobId) {

    UpdateInterviewschedulevalidation();
    if ($("#Interviewsecduleform").valid()) {
        model = {
            Id: Id,
            ClientId: ClientId,
            CandidateId: CandidateId,
            JobId: JobId,
            CandidateName: $("#ApplicantName").val(),
            Email: $("#ApplicantEmail").val(),
            ClientName: $("#InterviwerName").val(),
            ClientEmail: $("#InterviwerEmail").val(),
            InterviewBcc: $("#InterviewBcc").val(),
            InterviewCc: $("#InterviewCc").val(),
            InterviewDate: $("#InterviewDate").val(),
            candidateTitle: $("#titleName").val(),
            Location: $("#Location").val(),
            Description: $("#description").val(),




        }
        $("#InterviewBtn").text('Processing...');
        $("#InterviewBtn").attr("disabled", true);
        $.get("/Admin/Admin/UpdateInterviewschedule", model, function (data) {
            //if (data.Status == 1) {
            //    if (data.Id == 0) {
            //        toastr.success(" Interview scheduled  successfully.");
            //        setTimeout(function () { window.location.reload() }, 800);
            //    }
            //    else {
            //        toastr.success(" Interview rescheduled  successfully.");
            //        setTimeout(function () { window.location.reload() }, 800);
            //    }
            //}


            //else {
            //    toastr.info(" Plan not activated for the interview .");
            //    setTimeout(function () { window.location.reload() }, 800);
            //}
            if (data.Status == 1) {
                toastr.success(" Interview scheduled  successfully.");
                setTimeout(function () { window.location.reload() }, 1200);
            }
            else if (data.Status == 2) {
                toastr.success(" Interview rescheduled  successfully.");
                setTimeout(function () { window.location.reload() }, 1200);
            }
            else if (data.Status == 3) {
                toastr.info("Your plan is active but the interview points have expired.");
                setTimeout(function () { window.location.reload() }, 1200);
            }
            else {
                toastr.info("Plan not activated for the interview.");

            }


        });
    }
}

function UpdateInterviewschedulevalidation() {
    $("#Interviewsecduleform").validate({
        rules: {
            titleName: {
                required: true,
            },
            InterviewDate: {
                required: true,
            },
            InterviwerName: {
                required: true,
            },
            InterviwerEmail: {
                required: true,
                email: true
            },
            Location: {
                required: true,
            },

            description: {
                required: true,
            },

            InterviewBcc: {
                email: true,
            },

            InterviewCc: {
                email: true,
            }
        }
    });
}

function getInterviewByTitle() {
    debugger;
    if ($("input[name='MyjobId']:checked").val() == 0) {
        var myJobId = $("#myJobId").val();
        var Id = $("input[name='MyjobId']:checked").val();
        var url = "/Admin/Admin/InterviewSceduleList?JobId=" + myJobId + "&Id=" + Id + "&CompanyId=" + $("#CompanyId").val();
        window.location.href = url;
    }
    else {
        var myJobId = $("#SharedJobId").val();
        var Id = $("input[name='MyjobId']:checked").val();
        var url = "/Admin/Admin/InterviewSceduleList?JobId=" + myJobId + "&Id=" + Id + "&CompanyId=" + $("#CompanyId").val();
        window.location.href = url;
    }

}
function ResetInterviewByTitle() {
    var url = "/Admin/Admin/InterviewSceduleList";
    window.location.href = url;
}

function InterViewdelete(Id) {
    if (InterViewdeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Admin/Admin/InterViewdelete", model, function (data) {
        toastr.success(" Interview scheduled deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);


    });
}
function InterViewdeletevalidation() {
    return confirm("Do you really want to delete this interview?");
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

function EditcandidatemovebyId(Id) {
    var url = "/Admin/Candidate/CandidateDetail?Ids=" + Id;
    window.open(url);
}

function interviewStatusPopup(Id, InterviewSId, JobId) {

    model = {
        CandidateId: Id,
        JobId: JobId,
        InterviewSId: InterviewSId
    }
    $.get("/Admin/Candidate/interviewStatusPopup", model, function (response) {
        $("#InterviewStatusByid_Popup").html(response);
        $("#InterviewStatusByid_Popup").modal("show");


    });


}


function Interviewstatus(Id, JobId) {

    model = {
        Id: Id,
        JobId: JobId,
        ContactIs: $("#InterviewSId").val(),
    }

    $.get("/Admin/Candidate/Interviewstatus", model, function (response) {

        setTimeout(function () { window.location.reload(); }, 2000);
        toastr.success("Pipeline status updated successfully.");
    });
}


function resumealertmassege() {
    toastr.warning("Resume Not found.");
}


function CandidatesharedJobpopup(Id) {
    model = { Id: Id }
    $.get("/Admin/Candidate/CandidatesharedJobpopup", model, function (responce) {
        $("#Sharedjobcandidatepopup").html(responce);
        $("#Sharedjobcandidatepopup").modal("show");
    });
}


//function sendSubmitProfilemessage(Id) {
//    var favorite = [];
//    $.each($("input[name='CsharedJob']:checked"), function () {
//        favorite.push($(this).val());
//    });
//    model = {
//        Id: Id,
//        sharedJobCheckId: favorite.join(", "),
//        ClientId: $("#ClientId").val(),
//        description: $("#Description").val()
//    }
//    $.get("/Admin/Candidate/sendSubmitProfilemessage", model, function (data) {
//    }); 
//}

function AddSharedJobcandidatebyId(Id) {
    var favorite = [];
    var typeid = 0;
    $.each($("input[name='CsharedJob']:checked"), function () {
        favorite.push($(this).val());
    });
    if (favorite.length == 0) {
        toastr.info("Please select a job.");
        return false;
    } 
    if ($("#jobytpeid").val() == 1)
    {
        if ($("#Description").val().trim() == "") {
            toastr.info("Please enter message .");
            return false;
        }
        else
        {
            typeid = 1;
        }
    }
    debugger;
    model = {
        Id: Id,
        Typeid: typeid,
        sharedJobCheckId: favorite.join(", "),
        ClientId: $("#ClientId").val(),
        description: $("#Description").val()
    }

    $.get("/Admin/Candidate/AddSharedJobcandidatebyId", model, function (data) {
        if (data.StatusId == 1) { 
            toastr.success("Profile submitted successfully.");
            setTimeout(function () { window.location.reload(); }, 2000);
        }
        else {
            toastr.info("This candidate already submitted for this job.");
        }
         
    });
}

function submitdetailedprofilevalidation() {
    return confirm("Are you sure you want to submit this profile?.");
}

function submitdetailedprofile(Id, JobId) {
    debugger;
    if (submitdetailedprofilevalidation() == false) {
        return false;
    }
    model = {
        Id: Id,
        sharedJobCheckId: JobId
    }

    $.get("/Admin/Candidate/AddSharedJobcandidatebyId", model, function (data) {
        if (data.StatusId == 1) {
            toastr.success("Profile submitted successfully.");
            setTimeout(function () { window.location.reload() }, 1000);
        }
        else {
            toastr.info("This candidate already submitted for this job.");
            setTimeout(function () { window.location.reload() }, 1000);
        }

    });
} 

function getCandidatesubmissionById(Id) {

    var JobId = $("#JobId").val();
    var JobStatus = $("#JobStatusId").val();
    var url = "/Admin/Admin/SubmissionProfile?JobId=" + JobId + "&JobStatusId=" + JobStatus + "&PipeLineId=" + Id;
    window.location.href = url;
}
function candidatesubmissiondetailbyIs(Id, JobId) {
    var url = "/Admin/Candidate/detailedprofile?Ids=" + Id + "&JIds=" + JobId;
    window.open(url, "_blank");
}

function ResetcandidateSearch() {
    var url = "/Admin/Admin/SubmissionProfile";
    window.location.href = url;
}

//function searchKeyPresss(e, CId) {

//    if (e.keyCode === 13) {
//        Candidatetagvalue(CId);
//    }
//    return true;
//}

//function Candidatetagvalue(CId) {

//    if ($("#CandidateTag").val().trim() === "") {
//        return false;
//    }
//    model = {
//        CId: CId, 
//        CandidateTag: $("#CandidateTag").val(),
//        TagtypeId: 1
//    }
//    $.get("/Admin/Candidate/Candidatetagvalue", model, function (data) {

//        setTimeout(function () { location.reload() }, 600);
//    });

//}

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

function deletecandidatetagvalidation() {
    return confirm("Are you sure delete this tags.");
}