
function AdminCandididaterefencessave(Id, CandidateId) {

    AdminCandididaterefencessavevalidation();
    if ($("#refrencesform").valid()) {
        model = {
            Id: Id,
            candidateId: CandidateId,
            Name: $("#Name").val(),
            Phone: $("#Phone").val(),
            PreferredEMail: $("#RefrenceeMail").val(),
            Title: $("#Title").val()
        },
            $.get("/Admin/Admin/AdminCandididaterefencessave", model, function (data) {
                if (Id == 0) {
                    setTimeout(function () { window.location.reload() }, 2000);
                    toastr.success("Candidate Refrence saved successfully.");
                }
                else {
                    setTimeout(function () { window.location.reload() }, 2000);
                    toastr.success("Candidate Refrence updated successfully.");
                }
            });
    }
}

function CandidateProfileImageUpload(Id) {

    debugger;

    var imagename = $("input[name='gridRadios']:checked").val();
    if (imagename == undefined) {
        toastr.info("Please select a image.");
        return false;
    }
    model = {
        Id: Id,
        FileName: $("input[name='gridRadios']:checked").val()
    }

    $.get("/Home/ProfileImageUpload", model, function (data) {
        toastr.success("Image uploaded successfully.");
        location.reload();
    });
}

function ResumeUpload(Id) {

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
        fileData.append('Id', Id);
        fileData.append('Resumefile', fileName);

        $.ajax({
            url: "/Home/ResumeUpload",
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (data) {
                toastr.success("File uploaded successfully.");
                setTimeout(function () { window.location.reload(); }, 800);
            }
        });
    }
}
function Candidatedefaultimage(Id) {

    model = {
        Id: Id
    }
    $.get("/Home/Candidatedefaultimage", model, function (response) {
        $("#Candidatedeultimagepopup").html(response);
        $("#Candidatedeultimagepopup").modal("show")

    });
}
function AdminCandididaterefencessavevalidation() {
    $("#refrencesform").validate({
        rules: {
            Name: {
                required: true,
            },
            Phone: {
                required: true,
                number: true
            },
            RefrenceeMail: {
                required: true,
                email: true
            },
            Title: {
                required: true,
            },

        }


    });
}

function AdminCandidaterefrencespopup(Id, candidateId) {

    model = {
        Id: Id,
        CandidateId: candidateId
    },
        $.get("/Admin/Admin/AdminCandidaterefrencespopup", model, function (response) {
            $("#Candidaterefences").html(response);
            $("#Candidaterefences").modal("show");

        });
}

function AdminCandidateEducationpopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    }
    $.get("/Admin/Admin/AdminCandidateEducationpopup", model, function (response) {
        $("#candidateeducation_PopUp").html(response);
        $("#candidateeducation_PopUp").modal("show");
    });
}


function Admincreateeducationcandidate(Id, CandidateId) {

    Admincreateeducationcandidatevalidation();
    if ($("#CandidateEducationpopup").valid()) {
        model = {
            Id: Id,
            CandidateId: CandidateId,
            education: $("#education").val(),
            EducaStartYear: $("#year").val(),
            EducaEndYear: $("#endyear").val(),
            univarsity: $("#uunivarsity").val(),
            description: $("#description").val(),
            visibleid: $("#visibleid").val()
        }
        debugger
        $.get("/Admin/Admin/Admincreateeducationcandidate", model, function (data) {
            if (Id == 0) {
                toastr.success("Education saved successfully.");
                setTimeout(function () { window.location.reload(); }, 800);
            }
            else {
                toastr.success("Education updated successfully.");
                setTimeout(function () { location.reload() }, 800);
            }
        });
    }
}

function Admincreateeducationcandidatevalidation() {
    $("#CandidateEducationpopup").validate({
        rules: {
            education: {
                required: true,
            },
            year: {
                number: true
            },
            //uunivarsity: {
            //    required: true,
            //},
            //description: {
            //    required: true,
            //},
            endyear: {
                number: true,
                /* min: "year"*/
            },
            visibleid: {
                required: true,
            }
        }
    });
}

function AdminCandidateworkexperiencepopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    }
    $.get("/Admin/Admin/AdminCandidateworkexperiencepopup", model, function (response) {
        $("#candidateworkexperience_PopUp").html(response);
        $("#candidateworkexperience_PopUp").modal("show");
    });
}

function Admincreateworkexperiencecandidate(Id, CandidateId) {
    Admincreateworkexperiencecandidatevalidation();
    if ($("#Candidateworkexperiencepopup").valid()) { 
        if ($("#todate").val() != "") {
            if ($("#todate").val().length != 10) {
                toastr.warning("Please select valid start date.");
                return false;
            }
        } 
        if ($("#fromdate").val() != "") {
            if ($("#fromdate").val().length != 10) {
                toastr.warning("Please select valid end date.");
                return false;
            }
        }
        model = {
            Id: Id,
            CandidateId: CandidateId,
            Company: $("#company").val(),
            Title: $("#title").val(),
            Todate: $("#todate").val(),
            Fromdate: $("#fromdate").val(),
            description: CKEDITOR.instances['description'].getData(), 
            visibleid: $("#visibleid").val()
        }, 
        $.post("/Admin/Admin/Admincreateworkexperiencecandidate", model, function (data) {
            if (Id == 0) {
                toastr.success("Work experience created successfully.");
                setTimeout(function () { window.location.reload(); }, 800);
            }
            else {
                toastr.success("Work experience updated successfully.");
                setTimeout(function () { location.reload() }, 800);
            }
        });
    }
}
function Admincreateworkexperiencecandidatevalidation() {
    $("#Candidateworkexperiencepopup").validate({
        rules: {
            company: {
                required: true,
            },
            //todate: {
            //    required: true,
            //},
            //fromdate: {
            //    required: true,
            //},
            //description: {
            //    required: true,
            //},

            visibleid: {
                required: true,
            }
        }
    });
}



function AdminCandidateAwardspopup(Id, CandidateId) {
    model = {
        Id: Id,
        CandidateId: CandidateId
    },
        $.get("/Admin/Admin/AdminCandidateAwardspopup", model, function (response) {
            $("#candidateawrds_PopUp").html(response);
            $("#candidateawrds_PopUp").modal("show");
        });
}
function Admincreateawardscandidate(Id, CandidateId) {
    Admincreateawardscandidatevalidation();
    if ($("#CandidateAwardspopup").valid()) {
        model = {
            Id: Id,
            CandidateId: CandidateId,
            Title: $("#Title").val(),
            year: $("#year").val(),
            description: $("#description").val(),
            visibleid: $("#visibleid").val()
        },
            $.get("/Admin/Admin/Admincreateawardscandidate", model, function (data) {
                if (Id == 0) {
                    toastr.success("Awards created successfully.");
                    setTimeout(function () { window.location.reload(); }, 800);
                } else {
                    toastr.success("Awards updated successfully.");
                    setTimeout(function () { location.reload() }, 800);
                }
            });
    }
}
function Admincreateawardscandidatevalidation() {
    $("#CandidateAwardspopup").validate({
        rules: {
            Title: {
                required: true,
            },
            year: {
                required: true,
            },
            description: {
                required: true,
            },
            visibleid: {
                required: true,
            }
        }
    });
}


function AdminCandidateportfoliosave(Id, CandidateId) {
    if (Id == 0) {
        PortfolioSaveValid();

    }
    else {
        PortfolioUpdateValid();
    }
    if ($("#CandidateAwardspopup").valid()) {
        if (window.FormData !== undefined) {

            var fileData = new FormData();

            fileData.append('CandidateId', CandidateId);
            fileData.append('Id', Id);
            fileData.append('description', $("#description").val());

            fileData.append('visibleid', $("#visibleid").val());
            $.ajax({
                url: "/Admin/Admin/AdminCandidateportfoliosave",
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (data) {
                    if (Id == 0) {
                        toastr.success("Scouting report created successfully.");
                        setTimeout(function () { location.reload() }, 800);
                    } else {
                        toastr.success("Scouting report Updated successfully.");
                        setTimeout(function () { location.reload() }, 800);
                    }

                }
            });
        }
    }

};

function PortfolioSaveValid() {
    $("#CandidateAwardspopup").validate({
        rules: {

            description: {
                required: true
            },
            visibleid: {
                required: true
            },

        }

    });
}
function PortfolioUpdateValid() {
    $("#CandidateAwardspopup").validate({
        rules: {

            description: {
                required: true
            },
            visibleid: {
                required: true
            },

        }

    });
}
function AdminCandidateportfoliopopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    },
        $.get("/Admin/Admin/AdminCandidateportfoliopopup", model, function (response) {
            $("#AddUpdateportfolioPopup").html(response);
            $("#AddUpdateportfolioPopup").modal("show");
        });
}

function AdminAddUpdateSkillsPopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    }
    $.get("/Admin/Admin/AdminAddUpdateSkillsPopup", model, function (response) {
        $("#AddUpdateSkillsPopup").html(response);
        $("#AddUpdateSkillsPopup").modal("show");
    });
}
function check_skill() {

    $("#errormessage").text("");
}
function AdminSkillAddUpdate(Id, CandidateId, Ids) {


    if ($("#skill").val() != "") {
        if ($("#skill").val().trim() != "") {
            $("#errormessage").text("");
            model = {
                Id: Id,
                CandidateId: CandidateId,
                skill: $("#skill").val(),
                percentage: $("#percentage").val(),
                visibleid: $("#visibleid").val()
            },
                $.get("/Admin/Admin/AdminSkillAddUpdate", model, function (data) {
                    if (Id == 0) {
                        toastr.success("Skill saved successfully.");
                    }
                    else {
                        toastr.success("Skill  updated successfully.");
                    }

                    var url = "/Admin/Candidate/CandidateDetail?Ids=" + Ids + "&TabId=" + 3;
                    window.location.href = url;
                    setTimeout(function () { window.location.href = url }, 800);


                });
        }
        else {
            $("#errormessage").text("This field is required.");
            return false;
        }
    }
    else {
        $("#errormessage").text("This field is required.");
        return false;
    }





}






function AddUpdateLicensesCertification(Id, CandidateId) {
    debugger;
    AddUpdateLicensesCertificationvalidation();
    if ($("#CandidateEducationpopup").valid()) {
        model = {
            Id: Id,
            CandidateId: CandidateId,
            education: $("#education").val(),
            year: $("#year").val(),
            EndYear: $("#endyear").val(),
            univarsity: $("#uunivarsity").val(),
            description: $("#description").val(),
            visibleid: $("#visibleid").val(),
            TabId: 5
        }
        $.get("/Admin/Candidate/addupdatelicensescertification", model, function (data) {
            if (Id == 0) {
                toastr.success("Licenses certification saved successfully.");
                setTimeout(function () { window.location.reload(); }, 800);
            }
            else {
                toastr.success("Licenses certification updated successfully.");
                setTimeout(function () { location.reload() }, 800);
            }
        });
    }
}

function AddUpdateLicensesCertificationvalidation() {
    $("#CandidateEducationpopup").validate({
        rules: {
            education: {
                required: true,
            },
            //year: {
            //    required: true,
            //},
            //uunivarsity: {
            //    required: true,
            //},
            //description: {
            //    required: true,
            //},
            //endyear: {
            //    required: true,
            //},
            visibleid: {
                required: true,
            }
        }
    });
}



function LicensesCertificationsDelete(Id) {
    if (LicensesCertificationsDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Admin/Candidate/LicensesCertificationsDelete", model, function (data) {
        toastr.success("licenses certifications deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);
    })
}
function LicensesCertificationsDeletevalidation() {
    return confirm("Do you really want to delete this licenses certifications?");
}



function LicensesCertificationspopup(Id, candidateId) {

    model = {
        Id: Id,
        CandidateId: candidateId
    },
        $.get("/Admin/Candidate/LicensesCertificationspopup", model, function (response) {
            $("#LicensesCertificationspopup").html(response);
            $("#LicensesCertificationspopup").modal("show");

        });




}
function AdminSkillAddUpdatevalidation() {
    $("#skillform").validate({
        rules: {
            skill: {
                required: true,
            },
            percentage: {
                required: true,
                number: true
            }
        }
    });
}

function AdminCandidateEducationDelete(Id) {
    if (CandidateEducationDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Admin/Admin/AdminCandidateEducationDelete", model, function (data) {
        toastr.success("Education deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);
    })
}

function CandidateEducationDeletevalidation() {
    return confirm("Do you really want to delete this candidate education?");
}


function AdminCandidateworkexperienceDelete(Id) {
    if (CandidateworkexperienceDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.get("/Admin/Admin/AdminCandidateworkexperienceDelete", model, function () {
            toastr.success("Work experience deleted successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
}
function CandidateworkexperienceDeletevalidation() {
    return confirm("Do you really want to delete this candidate work experience?");
}


function Admindeleteskill(Id) {
    if (deleteskillvalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.post("/Admin/Admin/Admindeleteskill", model, function () {
            toastr.success("Skill deleted successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
}
function deleteskillvalidation() {
    return confirm("Do you really want to delete this skill?");
}


function AdminCandidateportfolioDelete(Id, CandidateId) {
    if (CandidateportfolioDeletevalidation() == false) {
        return false;
    }

    model = {
        ID: Id,
        CandidateId: CandidateId
    },
        $.get("/Admin/Admin/AdminCandidateportfolioDelete", model, function (Data) {
            toastr.success("Scouting Report Deleted successfully.");
            setTimeout(function () { location.reload() }, 800);
        });
}
function CandidateportfolioDeletevalidation() {
    return confirm("Do you really want to delete this Scouting Report?");
}


function AdminCandidateawardsDelete(Id) {
    if (CandidateawardsDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.post("/Admin/Admin/AdminCandidateawardsDelete", model, function () {
            toastr.success("Award deleted successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
}
function CandidateawardsDeletevalidation() {
    return confirm("Do you really want to delete this candidate Awards?");
}

function AdmincandidaterefrenceDelete(Id) {
    if (candidaterefrenceDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Admin/Admin/AdmincandidaterefrenceDelete", model, function (data) {
        setTimeout(function () { window.location.reload() }, 2000);
        toastr.success("Candidate Refrence Deleted successfully.");
    });

}

function candidaterefrenceDeletevalidation() {
    return confirm("Do you really want to delete this candidate refrences?");
}


function candidateprofilepopup(Id) {

    model = { Id: Id },
        $.get("/Admin/Candidate/candidateprofilepopup", model, function (response) {
            $("#candidateprofilepopup").html(response);
            $("#candidateprofilepopup").modal("show");
        });
}


function UpdateCandidate(Id) {

    UpdateCandidatevalidation();
    if ($("#clientform").valid()) { 
        var Featured = "";
        if ($('input[name="Featured"]').prop("checked") === true) {
            Featured = 1;
        }
        else if ($('input[name="Featured"]').prop("checked") === false) {
            Featured = 0;
        } 
        model = {
            Id: Id,
            Zipcode: $("#zipcode").val(),
            Name: $("#Name").val(),
            LastName: $("#LastName").val(),
            Phone: $("#Phone").val(),
            PreferredEMail: $("#PreferredEMail").val(),
            DesiredTitle1: $("#DesiredTitle1").val().trim(),
            DesiredTitle2: $("#DesiredTitle2").val().trim(),
            Industry: $("#Industry").val(),
            JobTypeId: $("#JobTypeId").val(),
            Title: $("#Title").val().trim(),
            CountryId: $("#CountryId").val(),
            StateId: $("#StateId").val(),
            CityName: $("#AutocompleteCity").val(),
            Address1: $("#Address1").val(),
            experience: $("#experience").val(),
            age: $("#age").val(),
            CurrentSalaryId: $("#CurrentSalaryId").val(),
            expectedSalaryId: $("#expectedSalaryId").val(),
            Educationlevels: $("#Educationlevels").val(),
            Facebook: $("#Facebook").val(),
            Twitter: $("#Twitter").val(),
            Linkedin: $("#Linkedin").val(),
            description: $("#Description").val(),
            Location: $("#autocomplete_search").val(),
            Certifications: $("#certifications").val(),
            Relocation: $("#Relocation").val(),
            Email: $("#hEmail").val(),
            EducationlevelName: $("#Educationlevels option:selected").text(),
            IndustryName: $("#Industry option:selected").text(),
            StateName: $("#StateId option:selected").text(),
            CountryName: $("#CountryId option:selected").text(),
            JobType: $("#JobTypeId option:selected").text(),
            CurrentSalary: $("#CurrentSalaryId option:selected").text(),
            Featured: Featured,
            experienceName: $("#experience option:selected").text(),
        };

        $("#candidatebttn").text('Processing...');
        $("#candidatebttn").attr('disable', true);

        $.post("/Admin/Candidate/UpdateCandidate", model, function () {
            toastr.success("Candidate updated successfully.");
            setTimeout(function () { location.reload() }, 800);
        });
    }
}
function UpdateCandidatevalidation() {
    $("#clientform").validate({
        rules: {
            Name: {
                required: true,
            },
            Title: {
                required: true,
            },
            JobTypeId: {
                required: true,
            },
            //Address1: {
            //    required: true,
            //},        
            //Phone: {
            //    required: true,
            //},
            //PreferredEMail: {
            //    required: true,
            //},
            //DesiredTitle1: {
            //    required: true,
            //},
            //DesiredTitle2: {
            //    required: true,
            //},
            //Industry: {
            //    required: true,
            //},

            //experience: {
            //    required: true,
            //},
            //age: {
            //    required: true,
            //},
            //Facebook: {
            //    required: true,
            //},
            //Twitter: {
            //    required: true,
            //},
            //Linkedin: {
            //    required: true,
            //},
            //salary: {
            //    required: true,
            //},
            //qualification: {
            //    required: true,
            //},                      
            //autocomplete_search: {
            //    required: true,
            //},
            //CurrentSalaryId: {
            //    required: true,
            //},
            //expectedSalaryId: {
            //    required: true,
            //},
            //description: {
            //    required: true,
            //},
            //zipcode: {
            //    required: true,
            //},

        }
    });
}


function GroupMove(Id) {

    model = { Id: Id },
        $.get("/Admin/Candidate/GroupMovePopup", model, function (response) {

            $("#grouppopup").html(response);
            $("#grouppopup").modal("show");
        })
}

function AddInGroupvalidation() {
    $("#MoveGroup").validate({
        rules: {
            groupId: {
                required: true,
            }
        }
    });
}
function AddInGroup(Id) {
    AddInGroupvalidation();
    if ($("#MoveGroup").valid()) {

        model = {
            Id: Id,
            Status: $("#groupId").val()
        };

        $.get("/Admin/Candidate/AddInGroup", model, function (data) {
            if (data.Status == 0) {
                toastr.success("Candidate added successfully.");
                setTimeout(function () { location.reload() }, 600);
            } else {
                toastr.info("Candidate already added  in this group .");
            }
        });
    }
}