function CreateCandidateValidactionWithEmail() {
    $("#Candidateform").validate({
        rules: {
            UName: {
                required: true,
            },
            UEmail: {
                required: true,
                email: true
            },
        }
    });
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
function CreateCandidate(Id) {
    debugger; //line 2
    var _LoginAccess = "";
    if ($('input[name="LoginAccess"]').prop("checked") === true) {
        _LoginAccess = 1;
    }
    else if ($('input[name="LoginAccess"]').prop("checked") === false) {
        _LoginAccess = 2;
    } 
    CreateCandidateValidactionWithEmail(); 
    if ($("#Candidateform").valid()) {  
        if (window.FormData !== undefined) {
            var fileUpload = $("#Uploadfiles").get(0);
            var files = fileUpload.files;
            var fileData = new FormData();
            var fileName = '';
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
                fileName += files[i].name;
                var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;

                if (fileExtension.toLowerCase() !== "doc" && fileExtension.toLowerCase() !== "docx" && fileExtension.toLowerCase() != "pdf" && fileExtension.toLowerCase() != "txt" && fileExtension.toLowerCase() != "rtf") {
                    toastr.warning("Upload only (.doc, .docx, .pdf, .txt, .rtf ) file.");
                    return false;
                }
            }
            fileData.append('Id', Id);
            fileData.append('AccountType', 3);
            fileData.append('Resumefile', fileName);
            fileData.append('Email', $("#UEmail").val());
            fileData.append('Name', $("#UName").val());
            fileData.append('LastName', $("#ULastName").val());
            fileData.append('Phone', $("#Phoneno").val());
            fileData.append('Password', $("#Password").val());
            fileData.append('Title', $("#Title").val().trim());

            $("#candidatebtn").val('Processing...');
            $("#candidatebtn").prop('disabled', true);

            $.ajax({
                url: "/Admin/Candidate/CreateCandidate",
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (data) {
                    if (data.StatusId == 2) {
                        debugger;
                        var url = "/Admin/Candidate/CandidateDetail?Ids=" + data.Ids;
                     
                          setTimeout(function () { window.location.href = url }, 2000);
                        toastr.success("Candidate created successfully.");
                    }
                    else if (data.StatusId == 3) {
                        url = "/Admin/Candidate/CandidateList";
                        setTimeout(function () { window.location.href = url }, 2000);
                        toastr.success("Candidate updated successfully.");
                    }
                    else {
                        toastr.error("EmailId already exist .");
                    }
                    $("#candidatebtn").val('Save');
                    $("#candidatebtn").prop('disabled', false);
                }
            });
        }
    }
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

            if (fileExtension.toLowerCase() !== "docx" && fileExtension.toLowerCase() !== "doc" && fileExtension.toLowerCase() != "pdf" && fileExtension.toLowerCase() != ".txt") {
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
                toastr.success("File upload successfully.");
                setTimeout(function () { window.location.reload(); }, 800);
            }
        });
    }
}
function ProfileImageUpload(Id) {
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

 
function candidateprofilepopup(Id) {
    model = { Id: Id },
        $.get("/Admin/Candidate/candidateprofilepopup", model, function (response) {
            $("#candidateprofilepopup").html(response);
            $("#candidateprofilepopup").modal("show");
        });
}

function candidateprofile_popup(Id) {
    model = { Id: Id }

    $.get("/Candidates/candidateprofile_popup", model, function (response) {
        $("#candidateprofile_popup").html(response);
        $("#candidateprofile_popup").modal("show"); 
    });
}

function LicensesCertificationspopup(Id, candidateId) {

    model = {
        Id: Id,
        CandidateId: candidateId
    },
        $.get("/Candidates/LicensesCertificationspopup", model, function (response) {
            $("#LicensesCertificationspopup").html(response);
            $("#LicensesCertificationspopup").modal("show");

        });
}

function Candidaterefrencespopup(Id, candidateId) {

    model = {
        Id: Id,
        CandidateId: candidateId
    },
        $.get("/Candidates/Candidaterefrencespopup", model, function (response) {
            $("#Candidaterefences").html(response);
            $("#Candidaterefences").modal("show");

        });
}


function candidaterefrenceDelete(Id) {
    if (candidaterefrenceDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Candidates/candidaterefrenceDelete", model, function (data) {
        setTimeout(function () { window.location.reload() }, 2000);
        toastr.success("Candidate Refrence Deleted successfully.");
    });

}

function candidaterefrenceDeletevalidation() {
    return confirm("Do you really want to delete this candidate refrences?");
}

function Candididaterefencessave(Id, CandidateId) {

    Candididaterefencessavevalidation();
    if ($("#refrencesform").valid()) {
        model = {
            Id: Id,
            candidateId: CandidateId,
            Name: $("#Name").val(),
            Phone: $("#Phone").val(),
            PreferredEMail: $("#RefrenceeMail").val(),
            Title: $("#Title").val()
        },
            $.get("/Candidates/Candididaterefencessave", model, function (data) {
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

function Candididaterefencessavevalidation() {
    $("#refrencesform").validate({
        rules: {
            Name: {
                required: true,
            },
            Phone: {
                required: true,
                number: true
            },
            PreferredEMail: {
                required: true,
                email: true
            },
            Title: {
                required: true,
            },

        }


    });
}




function CandidateEditById(Id) {

    var url = "/Admin/Candidate/Candidates?Id=" + Id;
    window.location.href = url;
}
function CandidateDelete(Id) {



    if (CandidateDeleteConfrim() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.post("/Admin/Candidate/CandidateDelete", model, function () {
            toastr.success("Candidate deleted successfully.");
            setTimeout(function () { window.location.reload(); }, 800);
        });
}

function CandidateDeleteConfrim() {
    return confirm("Do you really want to delete this Candidate?");
}
function CreateCandidatepopup(Id) {

    model = { Id: Id },
        $.get("/Admin/Candidate/CreateCandidatepopup", model, function (response) {
            $("#Candidatecreate_PopUp").html(response);
            $("#Candidatecreate_PopUp").modal("show");
        });
}

function CandidateDetail(Id) {

    var url = "/Admin/Candidate/CandidateDetail?Ids=" + Id;
    window.open(url);
}



function detailedprofile(Id) {

    var url = "/Admin/Candidate/detailedprofile?Ids=" + Id;
    window.open(url);
}

function confidentialprofile(Id) {

    var url = "/Admin/Candidate/confidentialprofile?Ids=" + Id;
    window.open(url);
}



function Detail(Id) {

    var url = "/Admin/Candidate/CDetail?Ids=" + Id;
    window.location.href = url;
}


function getCandidateByStatus() {

    //var Name = $('#UserName').val();
    var Email = $('#UserEmail').val();
    var Zipcode = $('#Zipcode').val();
    var Title = $('#Title').val();

    var UserPhone = $('#UserPhone').val();
    var UserFullName = $('#UserFullName').val();
    var Mile_Id = $('#MileId').val();
    var Keyword = $('#Keyword').val();
    var location = $('#autocomplete_search').val();

    debugger

    if (parseInt($("#autocomplete_search").val()))
    {
        if ($('#autocomplete_search').val().length >= 4)
        {
            var url = "/Admin/Candidate/CandidateList?Title=" + Title + "&Email=" + Email + "&CityName=" + location + "&Keyword=" + Keyword + "&Phone=" + UserPhone + "&Name=" + UserFullName + "&MileId=" + Mile_Id;
            window.location.href = url;
        }
        
    }
    else {
        $('#divDropdown').hide();
        $('#MileId').val('');
        var url = "/Admin/Candidate/CandidateList?Title=" + Title + "&Email=" + Email + "&CityName=" + location + "&Keyword=" + Keyword + "&Phone=" + UserPhone + "&Name=" + UserFullName;
        window.location.href = url;
    }






   
}


function ResetcandidateSearch() { 
    var url = "/Admin/Candidate/CandidateList";
    window.location.href = url;
}

function GroupMove(Id) { 
    model = { Id: Id },
        $.get("/Admin/Candidate/GroupMovePopup", model, function (response) { 
            $("#grouppopup").html(response);
            $("#grouppopup").modal("show");
        })
}

function UpdateCandidateprofilepopup() {
    $.get("/Candidates/UpdateCandidateprofilepopup", function (response) {
        $("#Candidatecupdateprofile_PopUp").html(response);
        $("#Candidatecupdateprofile_PopUp").modal("show");
    })
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
            /* PreferredEMail: $("#PreferredEMail").val(),*/
            DesiredTitle1: $("#DesiredTitle1").val().trim(),
            DesiredTitle2: $("#DesiredTitle2").val().trim(),
            Industry: $("#Industry").val(),
            JobTypeId: $("#JobTypeId").val(),
            Title: $("#Title").val(),
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
            //Certifications: $("#certifications").val(),
            Relocation: $("#Relocation").val(),
            Featured: Featured,
            Email: $("#hEmail").val(),
            EducationlevelName: $("#Educationlevels option:selected").text(),
            IndustryName: $("#Industry option:selected").text(),
            StateName: $("#StateId option:selected").text(),
            CountryName: $("#CountryId option:selected").text(),
            JobType: $("#JobTypeId option:selected").text(),


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
            Address1: {
                required: true,
            },
            Title: {
                required: true,
            },
            Phone: {
                required: true,
            },
            //PreferredEMail: {
            //    required: true,
            //},
            DesiredTitle1: {
                required: true,
            },
            DesiredTitle2: {
                required: true,
            },
            Industry: {
                required: true,
            },
            JobTypeId: {
                required: true,
            },
            experience: {
                required: true,
            },
            age: {
                required: true,
            },
            Facebook: {
                required: true,
            },
            Twitter: {
                required: true,
            },
            Linkedin: {
                required: true,
            },
            salary: {
                required: true,
            },
            qualification: {
                required: true,
            },
            Title: {
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
            CurrentSalaryId: {
                required: true,
            },
            expectedSalaryId: {
                required: true,
            },
            description: {
                required: true,
            },
            zipcode: {
                required: true,
            },

        }
    });
}

function CandidateEducationpopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    }
    $.get("/Candidates/CandidateEducationpopup", model, function (response) {
        $("#candidateeducation_PopUp").html(response);
        $("#candidateeducation_PopUp").modal("show");
    });
}


function createeducationcandidate(Id, CandidateId) {

    createeducationcandidatevalidation();
    if ($("#CandidateEducationpopup").valid()) {
        model = {
            Id: Id,
            CandidateId: CandidateId,
            education: $("#education").val(),
            EducaStartYear: $("#year").val(),
            EducaEndYear: $("#endyear").val(),
            univarsity: $("#uunivarsity").val(),
            description: $("#description").val(),
            visibleid: $("#visibleid").val(),
            TabId: 1
        }
        debugger
        $.get("/Candidates/createeducationcandidate", model, function (data) {
            if (Id == 0) {
                toastr.success("Education created successfully.");
                setTimeout(function () { window.location.reload(); }, 800);
            }
            else {
                toastr.success("Education updated successfully.");
                setTimeout(function () { location.reload() }, 800);
            }
        });
    }
}

function createeducationcandidatevalidation() {
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
                number: true
            },
            visibleid: {
                required: true,
            }
        }
    });
}







function AddUpdateLicensesCertification(Id, CandidateId) {

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
        $.get("/Candidates/addupdatelicensescertification", model, function (data) {
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
            
            visibleid: {
                required: true,
            }
        }
    });
}














function StateList(Id) {

    var model = { Id: Id };
    $.get("/Candidates/StateList", model, function (data) {
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





function LicensesCertificationsDelete(Id) {
    if (LicensesCertificationsDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Candidates/LicensesCertificationsDelete", model, function (data) {
        toastr.success("licenses certifications deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);
    })
}
function LicensesCertificationsDeletevalidation() {
    return confirm("Do you really want to delete this licenses certifications?");
}






function CandidateEducationDelete(Id) {
    if (CandidateEducationDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.get("/Candidates/CandidateEducationDelete", model, function (data) {
        toastr.success("Education deleted successfully.");
        setTimeout(function () { window.location.reload() }, 800);
    })
}
function CandidateEducationDeletevalidation() {
    return confirm("Do you really want to delete this candidate education?");
}
function Candidateworkexperiencepopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    }
    $.get("/Candidates/Candidateworkexperiencepopup", model, function (response) {
        $("#candidateworkexperience_PopUp").html(response);
        $("#candidateworkexperience_PopUp").modal("show");
    });
}




function createworkexperiencecandidate(Id, CandidateId) {
     
    createworkexperiencecandidatevalidation();
    if ($("#Candidateworkexperiencepopup").valid()) {
         
        if ($("#todate").val() != "")
        {
            if ($("#todate").val().length != 10)
            {
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
            visibleid: $("#visibleid").val(),
            TabId: 2
        },
            $.post("/Candidates/createworkexperiencecandidate", model, function (data) {
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
function createworkexperiencecandidatevalidation() {
    $("#Candidateworkexperiencepopup").validate({
        rules: {
            //title: {
            //    required: true,
            //},
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
            },
            company: {
                required: true
            }
        }
    });
}





function CandidateworkexperienceDelete(Id) {
    if (CandidateworkexperienceDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.post("/Candidates/CandidateworkexperienceDelete", model, function () {
            toastr.success("Work experience deleted successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
}
function CandidateworkexperienceDeletevalidation() {
    return confirm("Do you really want to delete this candidate work experience?");
}
function CandidateAwardspopup(Id, CandidateId) {
    model = {
        Id: Id,
        CandidateId: CandidateId
    },
        $.get("/Candidates/CandidateAwardspopup", model, function (response) {
            $("#candidateawrds_PopUp").html(response);
            $("#candidateawrds_PopUp").modal("show");
        });
}



function createawardscandidate(Id, CandidateId) {
    createawardscandidatevalidation();
    if ($("#CandidateAwardspopup").valid()) {
        model = {
            Id: Id,
            CandidateId: CandidateId,
            Title: $("#Title").val(),
            year: $("#year").val(),
            description: $("#description").val(),
            visibleid: $("#visibleid").val()
        },
            $.get("/Candidates/createawardscandidate", model, function (data) {
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
function createawardscandidatevalidation() {
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






function CandidateawardsDelete(Id) {
    if (CandidateawardsDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.post("/Candidates/CandidateawardsDelete", model, function () {
            toastr.success("Award deleted successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
}
function CandidateawardsDeletevalidation() {
    return confirm("Do you really want to delete this candidate Awards?");
}
function Candidateportfoliosave(Id, CandidateId) {
    debugger; /*oo*/
    if (Id > 0) {
        ValidateportfolioTosave_Edit();
    }
    else {
        ValidateportfolioTosave();
    }
    if ($("#CandidateAwardspopup").valid()) {
        if (window.FormData !== undefined) {
              
            var fileData = new FormData();
              
            fileData.append('CandidateId', CandidateId);
            fileData.append('Id', Id);
            fileData.append('description', $("#description").val());
            fileData.append('visibleid', $("#visibleid").val());
            fileData.append('TabId', 4);
            $.ajax({
                url: "/Candidates/Candidateportfoliosave",
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

function ValidateportfolioTosave() {
    $("#CandidateAwardspopup").validate({
        rules:
        {
           
            description: {
                required: true
            },
            visibleid: {
                required: true
            },
        }
    });
}
function ValidateportfolioTosave_Edit() {
    $("#CandidateAwardspopup").validate({
        rules:
        {
           
            description: {
                required: true
            },
            visibleid: {
                required: true
            },
        }
    });
}
function AddUpdateSkillsPopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    }
    $.get("/Candidates/AddUpdateSkillsPopup", model, function (response) {
        $("#AddUpdateSkillsPopup").html(response);
        $("#AddUpdateSkillsPopup").modal("show");
    });
}


function checkskill() {

    $("#errormessage").text("");
}



function SkillAddUpdate(Id, CandidateId) {
    //gg

    debugger;
    //kkkk
    if ($("#skill").val() != "") {
        if ($("#skill").val().trim() != "") {
            $("#errormessage").text("");
            model = {
                Id: Id,
                CandidateId: CandidateId,
                skill: $("#skill").val(),
                TabId: 3
            },
                $.get("/Candidates/SkillAddUpdate", model, function (data) {
                    if (Id == 0) {
                        toastr.success("Skill  created successfully.");
                        setTimeout(function () { location.reload() }, 800);
                    }
                    else {
                        toastr.success("Skill  updated successfully.");
                        setTimeout(function () { location.reload() }, 800);
                    }
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
function SkillAddUpdatevalidation() {

    if ($("#skill").val() != "") {
        if ($("#skill").val().trim() == "") {
            $("#skill").val(null);
        }
    }


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



function deleteskill(Id) {
    if (deleteskillvalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.post("/Candidates/Deleteskill", model, function () {
            toastr.success("Skill deleted successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
}
function deleteskillvalidation() {
    return confirm("Do you really want to delete this skill?");
}
function CandidateResumeUpload() {

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
        fileData.append('Resumefile', fileName);
        $.ajax({
            url: "/Candidates/CandidateResumeUpload",
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (data) {
            }
        });
    }
}
function UploadVideo(Id) {

    VideoValidation();
    if ($('#videoForm').valid()) {
        model = {
            Id: Id,
            Title: $("#Title").val(),
            VideoUrl: $("#VideoUrl").val(),
            description: $("#description").val(),
        };

        $.post("/Candidates/UploadVideo", model, function (data) {
            toastr.success("Video uploaded successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
    }
}
function VideoValidation() {
    $("#videoForm").validate({
        rules: {
            Title: {
                required: true
            },
            Url: {
                required: true
            }
        },
        messages: {
            VideoTitle: {
                required: "Please enter video title"
            },
            Location: {
                required: "Please enter video url"
            }
        }
    });
}
function Candidateportfoliopopup(Id, CandidateId) {

    model = {
        Id: Id,
        CandidateId: CandidateId
    },
        $.get("/Candidates/Candidateportfoliopopup", model, function (response) {
            $("#AddUpdateportfolioPopup").html(response);
            $("#AddUpdateportfolioPopup").modal("show");
        });
}



function CandidateportfolioDelete(Id, CandidateId) {
    if (CandidateportfolioDeletevalidation() == false) {
        return false;
    }

    model = {
        ID: Id,
        CandidateId: CandidateId
    },
        $.get("/Candidates/CandidateportfolioDelete", model, function (Data) {
            toastr.success("Scouting Report Deleted successfully.");
            setTimeout(function () { location.reload() }, 800);
        });
}
function CandidateportfolioDeletevalidation() {
    return confirm("Do you really want to delete this Scouting Report ?");
}

function CandidateVedio(Id) {

    model = {
        Id: Id
    }

    $.get("/Candidates/CandidateVedio", model, function (response) {
        $("#CandidateVedio").html(response);
        $("#CandidateVedio").modal("show");

    });
}


function ChangePasswordEmail(Id) {
    debugger;
    ChangePasswordEmailvalidation();

    if ($("#ChangePasswordform").valid()) {
        model = {
            Id: Id,
            oldpassword: $("#oldpassword").val(),
            newpassword: $("#newpassword").val(),
        },
            $.get("/Home/ChangePasswordEmail", model, function (data) {

                if (data.Status === 1) {
                    toastr.success("Password changed successfully.");
                    setTimeout(function () { window.location.reload(); }, 400);
                }
                else if (data.Status === 2) {
                    toastr.warning("Old password not match.");

                }

            });



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
function getcandidatedetails(Id, jobtypeId) {

    if (parseInt($("#autocomplete_search").val()))
    {
        var Url = "/Home/details?Id=" + Id + "&JobTypeId=" + jobtypeId + "&zip=" + $("#autocomplete_search").val() + "&mile=" + $("input[name='miles']:checked").val();
        window.open(Url, '_blank');
    }
    else
    {
        var Url = "/Home/details?Id=" + Id + "&JobTypeId=" + jobtypeId;
        window.open(Url, '_blank');
    } 
}

function resumealertmassege() {
    toastr.warning("Resume Not found.");
}


function Update_Candidate(Id) { 
    UpdateCandidate_validation();
    if ($("#CandidateProfilePopup").valid()) {

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
            /* PreferredEMail: $("#PreferredEMail").val(),*/
            DesiredTitle1: $("#DesiredTitle1").val().trim(),
            DesiredTitle2: $("#DesiredTitle2").val().trim(),
            Industry: $("#Industry").val(),
            JobTypeId: $("#JobTypeId").val(),
            Title: $("#Title").val(),
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
            Relocation: $("#Relocation").val(),
            Featured: Featured,
            location: $("#autocomplete_search").val(),

            EducationlevelName: $("#Educationlevels option:selected").text(),
            IndustryName: $("#Industry option:selected").text(),
            StateName: $("#StateId option:selected").text(),
            CountryName: $("#CountryId option:selected").text(),
            JobType: $("#JobTypeId option:selected").text(), 
        }; 
        $.post("/Candidates/Update_Candidate", model, function () {
            toastr.success("Candidate updated successfully.");
            setTimeout(function () { location.reload() }, 800);
        });
    }
}
function UpdateCandidate_validation() {
    /*check*/

    $("#CandidateProfilePopup").validate({
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
            //experience: {
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
            
            //CountryId: {
            //    required: true,
            //},
            //StateId: {
            //    required: true,
            //},
            //Industry: {
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
            //    number: true
            //},
            //JobTypeId: {
            //    required: true,
            //},
            //Educationlevels: {
            //    required: true,
            //},

            //Relocation: {
            //    required: true,
            //},
            
            //LastName: {
            //    required: true,
            //},
            //Phone: {
            //    required: true,
            //    number: true
            //},
            ////PreferredEMail: {
            ////    required: true,
            ////    email:true
            ////},
            //DesiredTitle1: {
            //    required: true,
            //},

        }
    });
}

function ResumeImage_Upload(Id) {

    if (window.FormData !== undefined) {
        var fileUpload = $("#Imagefiles").get(0);
        var files = fileUpload.files;
        var fileData = new FormData();
        var fileName = '';
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
            fileName += files[i].name;
            var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;

            if (fileExtension.toLowerCase() !== "jpg" && fileExtension.toLowerCase() != "png") {
                toastr.warning("Upload only (.jpf,.png) file.");
                return false;
            }
        }
        fileData.append('Id', Id);
        fileData.append('FileName', fileName);
        $.ajax({
            url: "/Candidates/ProfileImage_Upload",
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (data) {
                location.reload();
                toastr.success("Image upload successfully.");

            }
        });
    }
}

function Resume_Upload(Id) {
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
            url: "/Candidates/Resume_Upload",
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (data) {
                toastr.success("File upload successfully.");
                setTimeout(function () { window.location.reload(); }, 800);
            }
        });
    }
}


function ActiveTab(Id, tabId) {
    url = "/Admin/Candidate/CandidateDetail?Id=" + Id + "&TabId=" + tabId;
    window.location.href = url;
}


function GetResetCandidates() {
    var url = "/Home/candidatelist";
    window.location.href = url;
}

$(document).ready(function () {
    if ($("#checkgroupId").val() > 0) {
        
        GetSearchCandidates(1, $("#checkgroupId").val());
    } 
});

function GetSearchCandidates(CurrentPageIndex, gId, checkid) {
    if (checkid == 1) {
        $('input[name="JobtypeId"]').each(function () {
            this.checked = false;
        });
        $('input[name="JobCatagoryId"]').each(function () {
            this.checked = false;
        });
        $('input[name="experienceId"]').each(function () {
            this.checked = false;
        });
        $('input[name="educationlavelId"]').each(function () {
            this.checked = false;
        }); 
    } 
    var SearchId = 1;
    var hh = $("#checkgroupId").val();
    if ($("#checkgroupId").val() == 0) {
        var checkgroupId = $("#checkgroupId").val();
        if ($("#Title").val() == "" && $("#Keyword").val() == "" && $("#autocomplete_search").val() == "") {
            toastr.info("Please enter keyword, title or location .");
            setTimeout(function () {
                $("#overlay").fadeOut(10);
            }, 20);
            return false;
        }
    }
    else {
        SearchId = 2;
    }
    var Id = '';
    var city = '';
    var Jobtype = [];
    $.each($("input[name='JobtypeId']:checked"), function () {
        Id += $(this).val() + ",";
    });
    if (Id != '') { Id = Id.slice(0, -1); }
    var JobCatagory = '';
    $.each($("input[name='JobCatagoryId']:checked"), function () {
        JobCatagory += $(this).val() + ",";
    });
    if (JobCatagory != '') {
        JobCatagory = JobCatagory.slice(0, -1);
    }
    $("#beforesearchsection").hide();

    if (parseInt($("#autocomplete_search").val())) {
        $("#postal_code").val($("#autocomplete_search").val());
        $("#milesfiltersection").show();
         
    }
    else {
        city = $("#autocomplete_search").val();
        $("#postal_code").val('');
        $("#milesfiltersection").hide();
    }
    var ids11 = $("input[name='educationlavelId']:checked").val();
    var level = $('#' + ids11).html();
    if (parseInt($("#autocomplete_search").val())) {
        $("#milesfiltersection").show();
    } else {
        $("#milesfiltersection").hide();
    }
    var ExperienceIds = '';
    $.each($("input[name='experienceId']:checked"), function () {
        ExperienceIds += $(this).val() + ",";
    });
    if (ExperienceIds != '') {
        ExperienceIds = ExperienceIds.slice(0, -1);
    }

    var educationlavelIds = '';
    $.each($("input[name='educationlavelId']:checked"), function () {
        educationlavelIds += $(this).val() + ",";
    });
    if (educationlavelIds != '') {
        educationlavelIds = educationlavelIds.slice(0, -1);
    } 
    debugger;
    model = {
        CurrentPageIndex: CurrentPageIndex,
        gid: gId,
        StateId: 0,
        Jobcatagory: JobCatagory,
        Jobtype: Id,
        mile: $("input[name='miles']:checked").val(),
        experienceIds: ExperienceIds,
        educationlavel: educationlavelIds, 
        City: city,
        Zip: $("#postal_code").val(),
        Keyword: $("#Keyword").val(),
        Title: $("#Title").val(),
        SearchId: SearchId,
        IndustryId: 0,
        gids: $("#checkgroupId").val(),
        salery: $("#salertfilter").val()
    }, 
        $.ajax({
            url: "/Home/GetSearchCandidates",
            method: "GET",
            data: model,
            success: function (response)
            { 
                
                $("#CandiateListTable").html();
                $("#CandiateListTable").html(response);
                $("#filtersection").show();
                $("#recentsearch").hide();
                $("#beforesearchsection").hide();
            }
        }).done(function () {
            setTimeout(function () {
                $("#overlay").fadeOut(100);
            }, 300);
        });

}
 
//function GetresentSearchCandidates(CurrentPageIndex, gId, Title, Keyword, City) {

//    if (Title != '') {
//        $("#Title").val(Title);
//    }
//    if (Keyword != '') {
//        $("#Keyword").val(Keyword);
//    }
//    if (City != '') {
//        $("#autocomplete_search").val(City);
//    }

//    model = {
//        CurrentPageIndex: CurrentPageIndex,
//        gid: gId,
//        StateId: 0,
//        City: City,
//        Zip: $("#Zip").val(),
//        Keyword: Keyword,
//        Title: Title,
//        SearchId: 2
//    },
//        $.get("/Home/GetSearchCandidates", model, function (response) {
//            $("#CandiateListTable").html();
//            $("#CandiateListTable").html(response);

//            $("#filtersection").show();
//            $("#recentsearch").hide();
//        });
//}

function searchKeyPresss(e, candidateId) {

    if (e.keyCode === 13) {
        Candidateskillsvaluesave(candidateId);
    }
    return true;
}

function Candidateskillsvaluesave(candidateId) {

    if ($("#skill").val().trim() === "") {
        return false;
    }
    model = {
        CandidateId: candidateId,
        skill: $("#skill").val(),
    }
    $.get("/Candidates/Candidateskillsvaluesave", model, function (data) {
    });
}


function getCandidateByStatus() {
     
    var Email = $('#UserEmail').val(); 
    var Title = $('#Title').val(); 
    var UserPhone = $('#UserPhone').val();
    var UserFullName = $('#UserFullName').val();
    var Mile_Id = $('#MileId').val();
    var Keyword = $('#Keyword').val();
    var location = $('#autocomplete_search').val();

    debugger

    if (parseInt($("#autocomplete_search").val())) {
        if ($('#autocomplete_search').val().length >= 4) {
            var url = "/Admin/Candidate/CandidateList?Title=" + Title + "&Email=" + Email + "&CityName=" + location + "&Keyword=" + Keyword + "&Phone=" + UserPhone + "&Name=" + UserFullName + "&MileId=" + Mile_Id;
            window.location.href = url;
        } 
    }
    else {
        $('#divDropdown').hide();
        $('#MileId').val('');
        var url = "/Admin/Candidate/CandidateList?Title=" + Title + "&Email=" + Email + "&CityName=" + location + "&Keyword=" + Keyword + "&Phone=" + UserPhone + "&Name=" + UserFullName;
        window.location.href = url;
    } 
}

function PagerClick(CurrentPageIndex) {
    var Email = $('#UserEmail').val();
    var Title = $('#Title').val();
    var UserPhone = $('#UserPhone').val();
    var UserFullName = $('#UserFullName').val();
    var Mile_Id = $('#MileId').val();
    var Keyword = $('#Keyword').val();
    var location = $('#autocomplete_search').val();

    if (parseInt($("#autocomplete_search").val())) {
        if ($('#autocomplete_search').val().length >= 4) {
            var url = "/Admin/Candidate/CandidateList?Title=" + Title + "&Email=" + Email + "&CityName=" + location + "&Keyword=" + Keyword + "&Phone=" + UserPhone + "&Name=" + UserFullName + "&MileId=" + Mile_Id + "&CurrentPageIndex=" + CurrentPageIndex;
            window.location.href = url;
        }
    }
    else {
        $('#divDropdown').hide();
        $('#MileId').val('');
        var url = "/Admin/Candidate/CandidateList?Title=" + Title + "&Email=" + Email + "&CityName=" + location + "&Keyword=" + Keyword + "&Phone=" + UserPhone + "&Name=" + UserFullName + "&CurrentPageIndex=" + CurrentPageIndex;
        window.location.href = url;
    } 
}

function PagerClick1(CurrentPageIndex, gid) {

    var Email = $("#email").val();
    var StateId = $("#StateId").val();
    var City = $("#AutocompleteCity").val();
    var Zip = $("#Zip").val();
    var Title = $("#Title").val();
    url = "/Home/candidatelist?Email=" + Email + "&StateId=" + StateId + "&City=" + City + "&Zip=" + Zip + "&Title=" + Title + "&CurrentPageIndex=" + CurrentPageIndex + "&gId=" + gid;
    window.location.href = url;
}


function Candidatedefaultimage(Id) {

    model = {
        Id: Id,

    }
    $.get("/Home/Candidatedefaultimage", model, function (response) {
        $("#Candidatedeultimagepopup").html(response);
        $("#Candidatedeultimagepopup").modal("show")

    });
}