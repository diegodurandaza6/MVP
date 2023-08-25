 

function ChangePasswordEmail() {
    ChangePasswordEmailvalidation();
    if ($("#ChangePasswordform").valid()) {
        model = {
            Id: Id,
            oldpassword: $("#oldpassword").val(),
            newpassword: $("#newpassword").val(),
        },
            $.get("/Home/ChangePasswordEmail", model, function (data) {               
                if (data.Status === 1) {
                    toastr.success("Password updated successfully.");
                }
                else if (data.Status === 2) {
                    toastr.warning("Old password not match.");
                }
            });
    }
}
 
function selectvalue(title, Id, location) {
   
    if (Id == '0' || Id > 0)
    {
        if (location != "") {
            $("#jobLocationid").text(title + ' - ' + location);
        } else {
            $("#jobLocationid").text(title);
        }
        if (Id == '00') {
            $("#jobid").val('');
        } else {
            $("#jobid").val(Id);
        }
    } 
}
 
function ChangePasswordEmailvalidation() {
    $("#ChangePasswordform").validate({
        rules: {
            oldpassword: {
                required: true
            },
            newpassword: {
                required: true
            },
            confirmpassword: {
                required: true,
                equalTo: "#newpassword"
            }
        }
    });
}
function ClientSendenquery(Id, AccountType) { 
    if (AccountType == 2) { 
        ClientSendqueryvalidation();
        if ($("#sendenquery").valid()) {
            if (window.FormData !== undefined) {
                var fileUpload = $("#file").get(0);
                var files = fileUpload.files;
                var fileData = new FormData();
                var model = new Object(); 

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
                fileData.append('CandidateId', Id);
                fileData.append('Name', $("#EName").val());
                fileData.append('Phone1', $("#Phone").val());
                fileData.append('Email', $("#Email").val());
                fileData.append('JobId', $("#jobid").val());
                fileData.append('Description', $("#Description").val());
                fileData.append('FileName', fileName);

                $("#btnsend").text('Processing...');
                $("#btnsend").attr("disabled", true); 
                $.ajax({
                    url: "/Client/ClientSendenquery",
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: fileData,
                    success: function (data) {
                        if (data == 0) {
                            toastr.info("Interview request already send");
                            setTimeout(function () { window.location.reload(); }, 800);
                        } else {
                            toastr.success("Message sent successfully.");
                            setTimeout(function () { window.location.reload(); }, 800);
                        }
                        
                    }
                });
            }
        }

    }
    else {
        toastr.info("You are not authorized.  Please login.");
    }  
}
function _ClientSendenquery(CandidateId) {
        ClientSendqueryvalidation(); 
}

function ClientSendqueryvalidation() {
    $("#sendenquery").validate({
        rules: {
            EName: {
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            Phone: {
                required: true,

            },
           
            Description: {
                required: true,
            },
            CheckboxID: {
                required: true,
            },
            jobid: {
                required: true,
            }


        }



    });
}

function favoritecandidatevalidation() {
    return confirm("Do you really want to remove this favorite candidate ?");
}

function favoritecandidateremove(CandidateId, ClientId, StatusId) { 
    if (favoritecandidatevalidation() == false) {
        return false;
    }
    model = {
        Id: CandidateId,
        ClientId: ClientId,
        Status: StatusId
    }
    $.get("/Client/favoritecandidate", model, function (data) {
        if (data.Status == 1) {
            toastr.success("Candidate add to favorite  successfully.");
            setTimeout(function () { window.location.reload() }, 2000);
        }
        else {
            toastr.success("Removed successfully.");
            setTimeout(function () { window.location.reload() }, 2000);
        }
    });
}

function favoritecandidate(CandidateId, ClientId, StatusId, Id) {
     
    if (Id == 1) {
        toastr.info("You are not authorized.  Please login.");
        setTimeout(function () { window.location.reload() }, 2000);
        return false;
    } 
    model = {
        Id: CandidateId,
         ClientId: ClientId, 
        Status: StatusId
    }
    $.get("/Client/favoritecandidate", model, function (data) {
        if (data.Status == 1) {
            toastr.success("Candidate favorite successfully.");
            setTimeout(function () { window.location.reload() }, 2000);
        }
        else {
            toastr.success("Candidate removed successfully.");
            setTimeout(function () { window.location.reload() }, 2000);
        }
    });
}

function StateList(Id) { 
    var model = { Id: Id };
    $.get("/Client/StateList", model, function (data) {
        $("#StateId").empty();
        $("#StateId").append($("<option />").val("").html("Select State"));
        $.each(data, function () { 
            $("#StateId").append($("<option />").val(this.Id).html(this.Name));
        });
    });
}

function CityList(Id) {
    var model = {
        Id: Id
    };
    $.get("/Candidates/CityList", model, function (data) {
        $("#CityId").empty();
        $("#CityId").append($("<option />").val("").html("Select City"));
        $.each(data, function () {
            $("#CityId").append($("<option />").val(this.Id).html(this.Name));
        });
    });
}


function ClientProfileupdate(Id) {
     
    ClientProfileupdatevalidation();
    if ($("#ClientProfileupdatefrom").valid()) {
        if (window.FormData !== undefined) {
            var FileName = $("#clientlogofile").get(0);
            var files = FileName.files;
            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
                var fileName = files[i].name;
            
           
                var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
                if (fileExtension.toLowerCase() != "jpg" && fileExtension.toLowerCase() != "png" && fileExtension.toLowerCase() != "jpeg") {
                    toastr.warning("Upload only (.jpg , .png , .Jpeg) file.");
                    return false;
                }
            }
            var fileUploadedName = $("#hclientlogo").val();
            var fileName = fileName === undefined ? fileUploadedName : fileName;
            //fileName = fileName === undefined ? $("#hclientlogo").text() : fileName;
            fileData.append('Id', Id);
            fileData.append('CompanyName', $("#Companyname").val());
       
            fileData.append('clientLogo', fileName);
            fileData.append('Website', $("#Website").val());

            fileData.append('Name', $("#FirstName").val());
            fileData.append('LastName', $("#LastName").val());
            fileData.append('ClientPhone', $("#ClientPhone").val());

            fileData.append('Address', $("#Address").val());
            fileData.append('FaceBook', $("#facebookurl").val());
            fileData.append('Twitter', $("#twitterurl").val());
            fileData.append('Linkdin', $("#linkedinurl").val());
            //fileData.append('CountryId', $("#CountryId").val());
            //fileData.append('StateId', $("#StateId").val());
            fileData.append('Location', $("#autocomplete_search").val());
            fileData.append('Zip', $("#zipcode").val());
            fileData.append('Description', $("#Description").val());
            $.ajax({
                url: "/Client/ClientProfileupdate",
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (data) {
                    toastr.success("Client profile updated successfully.");
                    setTimeout(function () { window.location.reload() }, 800);
                }
            });
        }
    }
    }


function ClientProfileupdatevalidation() {
    $("#ClientProfileupdatefrom").validate({
        rules: {
            Companyname: {
                required: true,
            },
            Website: {
                required: true,
                url: true

            },

            FirstName: {
                required: true,
            },

            //LastName: {
            //    required: true,
            //},
            ClientPhone: {
                required: true,
                number: true
            },


            zipcode: {
                required: true,
                number:true
            },
            Address: {
                required: true,
            },
            facebookurl: {
                required: true,
            },
            twitterurl: {
                required: true,
            },
            linkedinurl: {
                required: true,
            },
            CountryId: {
                required: true,
            },
            StateId: {
                required: true,
            },
            autocomplete_search: {
                required: true,
            },
            Description: {
                required: true,
            }
        }
    });
}



function candidateshortlist(Id, ClientId) {

    if (ClientId > 0) {
        model = {
            Id: Id,
            ClientId: ClientId
        }
        $.get("/Client/candidateshortlist", model, function (data) {
         
            if (data.Status == 0) {
                toastr.success("Candidate shortlisted successfully.");
                setTimeout(function () { window.location.reload() }, 2000);
            }
            else {
                toastr.info("This candidate already added.");
                setTimeout(function () { window.location.reload() }, 2000);
            }
        });
    }
    else {
        toastr.info("You are not authorized to access this feature.");
    }
}

function viewcandidatedetail(CandidateId) {
  
    var url = "/Home/details?Id=" + CandidateId;
    window.location.href = url;
}




function InterviewSchedulepopup(Id, CandidateId,JobId) {
     
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


function ClientUpdateInterviewschedule(Id, ClientId, CandidateId) {
 
    UpdateInterviewschedulevalidation();
    if ($("#Interviewsecduleform").valid()) {
        model = {
            Id: Id,
            JobId: $("#JobId").val(),
            ClientId: ClientId,
            CandidateId: CandidateId,
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
        $.get("/Client/ClientUpdateInterviewschedule", model, function (data) {
            if (data.Status == 1) {
                toastr.success("Interview scheduled  successfully.");
                setTimeout(function () { window.location.reload() }, 1200);
            }
            else if (data.Status == 2) {
                toastr.success(" Interview rescheduled  successfully.");
                setTimeout(function () { window.location.reload() }, 1200);
            }
            else if (data.Status == 3) {
                toastr.info("Your plan is active but the interview points have expired.");
                setTimeout(function () { window.location.reload() }, 800);
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
            JobId: {
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


function interviewStatusPopup(Id,InterviewSId,JobId) {
     
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

function ClientInterviewstatuschangevalidation()
{
    $("#clientform").validate({

        rules: {
            InterviewSId: {
                required: true,
            },
            JobId: {
                required: true,
            },
        }
    

    });
}


function resumealertmassege() {
    toastr.warning("Resume Not found.");
}

function ResetApplicant() {
    var url = "/Client/applicant";
    window.location.href = url;
}