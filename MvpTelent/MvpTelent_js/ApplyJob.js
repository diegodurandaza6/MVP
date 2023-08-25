

function JobApply(Id, UserId)
{ 
    if (UserId === 0) {
        JobapplyLogin();
    }
    else {
    model = {
        Id: Id,
        UserId: UserId
    }
        $.get("/Home/AppliedJob", model, function (data) {
            if (data.StatusId == 0) {
                toastr.info("This job already applied .");
            }
            else {
                toastr.success("Job applied successfully.");
                setTimeout(function () { window.location.reload() }, 1000);
            }
           
    });
    }
}



function requestmoreinfo(Id, UserId) {
    debugger;
    if (UserId === 0) {
        JobapplyLogin();
    }
    else {
        model = {
            Id: Id,
            UserId: UserId
        }
        $.get("/Home/requestmoreinfo", model, function (data) {
            if (data.StatusId == 0) {
                toastr.info("Request more info  already sent");
            }
            else {
                toastr.success("Request more info sent successfully.");
                setTimeout(function () { window.location.reload() }, 1000);
            }

        });
    }
}







function JobapplyLogin()
{
     
    $.get("/Home/JobApply", function (response) {

        $("#ApplyJos_PopUp").html(response);
        $("#ApplyJos_PopUp").modal("show");


    });
}


function CandidateLogins() {
     
    CandidateLoginsvalidation();
    if ($("#ApplyJobform").valid()) {
        model = {
            Email: $("#username").val().trim(),
            Password: $("#password").val().trim(),
            UsertypeId:3
        };
        debugger;
        $.get("/Home/CandidateLogin", model, function (data) {
            debugger;

            if (data.Status == 1) {

                toastr.success("Login successful.");
                setTimeout(function () { location.reload(true); }, 800);

            }
            else if (data.Status === 4) {
                toastr.error("Password Incorrect.");
            }
            else if (data.Status === 9) {
                toastr.warning("Please check your email");
            }
            else if (data.Status === 0) {
                toastr.warning("Please confirm your account from email");
            }
            else if (data.Status === 5) {
                toastr.warning("Email doesn't exist/ try another email.");
            }
             
        });
    }
}
function CandidateLoginsvalidation() {
    $("#ApplyJobform").validate({
        rules: {
            username: {
                required: true,
                email: true
            },
            password: {
                required: true
            },
        }
    });
}

function savedJob(Id,UserId)
{
     
    if (UserId === 0) {

        JobapplyLogin();

    } else {

        model = {
            Id: Id,
            UserId: UserId
        };
        $.get("/Home/JobSave", model, function (data) {
            toastr.success("Job saved successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
    }
}


function getJobDetail(Id)
{ 
    var url = "/Home/jobdetail?Ids=" + Id;
    window.open(url); 
 
}

function JobAppliedDeletebyId(Id)
{
    if (JobAppliedDeletebyIdvalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Candidates/JobAppliedDeletebyId", model, function (data) {
        toastr.success("Applied Job deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);
    });
}

function JobAppliedDeletebyIdvalidation() {
    return confirm("Do you want to delete applied jobs?")
}

function JobSavedDeletebyIdvalidation() {
    return confirm("Do you want to delete aved jobs?")
}

function JobSavedDeletebyId(Id) {

    if (JobSavedDeletebyIdvalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Candidates/JobSavedDeletebyId", model, function (data) {
        toastr.success("Saved job deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);
    });

}





function gestcndidatelogin(Id)
{
    model = {
        Id: Id
    }
     
    $.get("/Home/gestcndidatelogin", model, function (response) {

        $("#Gestcandidate_PopUp").html(response);
        $("#Gestcandidate_PopUp").modal("show");

    });

}


function creategustcandidate(Id)
{
    var lastname = " ";
   
    creategustcandidatevalidation();


    if ($("#lastname").val().trim() == "") {
        lastname = " ";
    } else {
        lastname = $("#lastname").val().trim();
    }

    if ($("#addgustcandidate").valid()) {
        if (window.FormData !== undefined) {
            var fileUpload = $("#resumefile").get(0);
            var files = fileUpload.files;
            var fileData = new FormData();
            var fileName = '';
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
                fileName += files[i].name;
                var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
                 
                if (fileExtension.toLowerCase() !== "docx" && fileExtension.toLowerCase() != "pdf" && fileExtension.toLowerCase() != "doc") {
                    toastr.warning("Upload only (.doc, .docx and .pdf ) file only.");
                    return false;
                }
            }
            fileData.append('JobId', Id);
            fileData.append('FirstName', $("#firstname").val());
            fileData.append('LastName', lastname);
            fileData.append('Phone', $("#Phone").val());
            fileData.append('Email', $("#email").val());
            fileData.append('FileName', fileName);
             
            $.ajax({
                url: "/Home/creategustcandidate",
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (data) {
                    if (data.StatusId == 1) {
                       
                        toastr.success("Job applied successfully.");
                        setTimeout(function () { window.location.reload() }, 800);
                    } else if (data.StatusId ==2)
                    {
                        toastr.warning("Please check your email.");
                    }
                   
                }
            });
        }
    }
}

function creategustcandidatevalidation() {
  
        $("#addgustcandidate").validate({
            rules: {
                firstname: {
                    required: true,
                },
                
                Phone: {
                    required: true,
                    number: true
                },
                email: {
                    required: true,
                },
                resumefile: {
                    required: true,
                }
                
            }
        });

  
}

function movetoapplicantjobId(JobId)
{
    var url = "/Admin/Candidate/Applicant?JobId=" + JobId;
    window.location.href = url;
}

function ResumeBulkUploadPopup(Id) {
    model = {
        JobId: Id
    }
    $.get("/Admin/Admin/ResumeBulkUploadPopup", model, function (response) {

        $("#Resumebulkpopupsharejob").html(response);
        $("#Resumebulkpopupsharejob").modal("show");
    });
}

function Createuploadresumesave(JobId)
{
     
    Createuploadresumesavevalidation();

    if ($("#Candidateresumeblikform").valid()) {
        if (window.FormData !== undefined) {
            var fileUpload = $("#Uploadfiles").get(0);
            var files = fileUpload.files;
            var fileData = new FormData();
            var fileName = '';
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
                fileName += files[i].name;
                var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;

                if (fileExtension.toLowerCase() !== "docx" && fileExtension.toLowerCase() != "pdf") {
                    toastr.warning("Upload only (.docx,.pdf ) file.");
                    return false;
                }
            }
            fileData.append('JobId', JobId);
            fileData.append('FirstName', $("#UName").val());
            fileData.append('LastName', $("#ULastName").val());
            fileData.append('Phone', $("#Phoneno").val());
            fileData.append('Email', $("#UEmail").val());
            fileData.append('FileName', fileName);

            $.ajax({
                url: "/Admin/Admin/Createuploadresumesave",
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (data) {
                    if (data.StatusId == 1) {

                        toastr.success("Resume submited successfully.");
                        setTimeout(function () { window.location.reload() }, 800);
                    } else if (data.StatusId == 2) {
                        toastr.warning("This email already exists .");
                    }

                }
            });
        }
    }
}

function Createuploadresumesavevalidation() {

    $("#Candidateresumeblikform").validate({
        rules: {
            UName: {
                required: true,
            },
            ULastName: {
                required: true,
            },
            Phoneno: {
                required: true,
                number: true
            },
            UEmail: {
                required: true,
                email: true
            },
            Uploadfiles: {
                required: true,
            }

        }
    });


}

function Scanidatedetailpage(Id, JobId)
{
    var url = "/Admin/Candidate/Detail?Ids=" + Id + "&JobId=" + JobId; 
    window.location.href = url;
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

function candidatedetail(Id, JobId)
{
    var url = "/Admin/Candidate/detailedprofile?Ids=" + Id + "&JIds=" + JobId;
    window.open(url, '_blank');
}


function sharjobIdziprecuiter(Id,JobPostStatus) {
     
    if (sharjobIdziprecuiterConfirm(JobPostStatus) === false) {
        return false;
    }
    model = {
        Ids: Id,
        JobPostStatus: JobPostStatus
    }
    $.get("/Admin/Admin/Updatesharejobsstatus", model, function (data) {
 
        if (JobPostStatus == 1) {
            toastr.success("Job share stopped successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        }
        else {
            toastr.success("Job shared successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        } 
    });
}


function sharjobIdziprecuiterConfirm(JobPostStatus) {
    if (JobPostStatus == 1) {
        return confirm("Do you really want to stop sharing this job from ziprecruiter ?");
    } else {
       

        return confirm("Do you really want to share this job on ziprecruiter ?");
    }
     
}

//function Updatesharejobsstatus(Id)
//{
//    model = {
//        JobId: Id,
//        JobPostStatus :1
//    }
//    $.get("/Admin/Admin/Updatesharejobsstatus", model, function (data) {
//        toastr.success("shar job  successfully.");
//        setTimeout(function () { window.location.reload() }, 800);
//    });
//}

//---client jobshar---


function clientsharjobIdziprecuiter(Id,JobPostStatus)
{
    if (clientsharjobIdziprecuiterConfirm(JobPostStatus) === false) {
        return false;
    }
    model = {
        Ids: Id,
        JobPostStatus: JobPostStatus
    }
    
    $.get("/Client/ClientUpdatesharejobsstatus", model, function (data) {
        if (JobPostStatus == 1) {
            toastr.success("Job share stopped successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        }
        else {
            toastr.success("Job shared successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        }
    });
}

function clientsharjobIdziprecuiterConfirm(JobPostStatus) {
    if (JobPostStatus == 1) {
        return confirm("Do you really want to stop sharing this job from ziprecruiter ?");
    } else {


        return confirm("Do you really want to share this job on ziprecruiter ?");
    }

}

//function ClientUpdatesharejobsstatus(Id)
//{
//     
//    model = {
//        JobId: Id,
//        JobPostStatus: 1
//    }
//    $.get("/Client/ClientUpdatesharejobsstatus", model, function (data) {
//        toastr.success("shar job  successfully.");
//        setTimeout(function () { window.location.reload() }, 800);
//    });
//}