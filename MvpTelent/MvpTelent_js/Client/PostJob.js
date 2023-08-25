function enterkeypressskill(event) {
    if (event.which == 13) {


        model = {
            Id: $("#hJobId").val(),
            KeySkills: $("#skill").val(),
            SId: $("#hSId").val(),
        }

        $.get("/Home/AddSkills", model, function (response) {
            $("#dv_JobSkills").html(response);
            $("#skill").val('');
        });

    }
}
function GetSubjobByJobId(JobCategoryId) {
    $("#SubCategoryId").empty();
    $("#SubCategoryId").append($("<option />").val("").html("Please select sub category"));
    model = {
        Id: JobCategoryId
    }
    $.get("/Client/GetSubJobByJId", model, function (data) {

        $.each(data, function () {
            $("#SubCategoryId").append($("<option />").val(this.SubCategoryId).html(this.SubCategoryName));
        });

    });
}

function CheckSalaryNumeric(e) {
    debugger;
    if (window.event) // IE
    {
        if (e.keyCode == 46) {
            event.returnValue = true;
            return true;
        }
        else
        {
            if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8 && e.keyCode != 44) {
                event.returnValue = false;
                return false;
            }
        }
    }
    else { // Fire Fox
        if (e.keyCode == 46) {
            event.returnValue = true;
            return true;
        }
        else {
            if ((e.which < 48 || e.which > 57) & e.which != 8 && e.which != 44) {
                e.preventDefault();
                return false;
            }
        }
    }
}

function enterkeypresstags(event) {
    if (event.which == 13) {
        model =
        {
            Id: $("#htagJobId").val(),
            Tags: $("#Jobtags").val(),
            TId: $("#hTId").val(),
        }
        $.get("/Home/AddTags", model, function (response) {
            $("#dv_Jobtags").html(response);
            $("#Jobtags").val('');
        });
    }
}


function enterkeypresstags_focusout() { 
    model =
    {
        Id: $("#htagJobId").val(),
        Tags: $("#Jobtags").val(),
        TId: $("#hTId").val(),
    }
    
    $.get("/Home/AddTags", model, function (response) {
        $("#dv_Jobtags").html(response);
        $("#Jobtags").val('');
    });
}

function enterkeypresstagsfocusout() {
    if ($("#Jobtags").val() != "") {
        if ($("#Jobtags").val().trim() != "") {
            setTimeout(function () { enterkeypresstags_focusout() }, 500);
            
        }
    }
}




function SearchJobvalidation() {
    $("#SearchIdfrom").validate({
        rules: {
            JobTitle: {
                required: true,
            }
        }

    });
}

function CityAutoComplete(Id) {

    var model = {
        prefix: Id
    };
    if (Id > 0) {

        autocomplete(document.getElementById("AutocompleteCity"), '/Home/cityautocomplete', model);
    }
}


function getJobList() {

    var sharedjobid = "";
    if ($('input[name="sharedjobid"]').prop("checked") === true) {
        sharedjobid = 1;
    }
    else if ($('input[name="sharedjobid"]').prop("checked") === false) {
        sharedjobid = 0;
    }
    var JobStatusId = $("#JobStatusId").val();
    var JobTitle = $("#_jobtilte").val();
    var JobTypeId = $("#JobTypeId").val();
    var url = "/Client/JobList?JobStatusId=" + JobStatusId + "&JobTypeId=" + JobTypeId + "&SharedJob=" + sharedjobid + "&jobtitle=" + JobTitle;
    window.location.href = url;
}

function JobsReset() {

    var url = "/Client/JobList";
    window.location.href = url;
}

function onfocusout() {

    //if ($("#skill").val() != '') {
    //    setTimeout(function () {
    //        model = {
    //            Id: $("#hJobId").val(),
    //            KeySkills: $("#skill").val(),
    //            SId: $("#hSId").val(),
    //        }
    //        $.get("/Home/AddSkills", model, function (response) {
    //            $("#dv_JobSkills").html(response);
    //            $("#skill").val('');
    //        });
    //    }, 500);
    //}
}


//function onfocusout() {

//    if ($("#tags").val() != '') {
//        setTimeout(function () {
//            model = {
//                Id: $("#htagJobId").val(),
//                KeySkills: $("#tags").val(),
//                SId: $("#hTId").val(),
//            }
//            $.get("/Home/AddTags", model, function (response) {
//                $("#dv_Jobtags").html(response);
//                $("#tags").val('');
//            });
//        }, 500);
//    }
//}




function deleteJobskill(Id, JobId, SId) {
    model = {
        Id: Id,
        Ids: JobId,
        SId: SId
    }

    $.get("/Home/deleteJobskill", model, function (response) {

        $("#dv_JobSkills").html(response);
        //  location.reload();
    });
}

function deleteJobtags(Id, JobId, TId) {
    model = {
        Id: Id,
        Ids: JobId,
        TId: TId
    }

    $.get("/Home/deleteJobtags", model, function (response) {

        $("#dv_Jobtags").html(response);
        //  location.reload();
    });
}




function movesubmittedprofile(JobId, JobStatusId) {
    var url = "/Admin/Candidate/Applicant?JobId=" + JobId + "&JobStatusId=" + JobStatusId;
    window.location.href = url;
}




function jobCancel() {

    var url = "/Client/JobList";
    window.location.href = url;
}
function CreateJobs(Id) {

  
    var SharedJob = "";
    if ($('input[name="SharedJob"]').prop("checked") === true) {
        SharedJob = 1;
    }
    else if ($('input[name="SharedJob"]').prop("checked") === false) {
        SharedJob = 0;
    }

    var Featured = "";
    if ($('input[name="Featured"]').prop("checked") === true) {
        Featured = 1;
    }
    else if ($('input[name="Featured"]').prop("checked") === false) {
        Featured = 0;
    }

    if ($("#hcheckplan").val() == "1") {

    }

    if ($("#hcheckplan").val() == "1")
    {
        CreateJobsvalidation();
        if ($("#PostJobfrom").valid())
        { 
            $("#createJob").attr('disable', true);

            model = {
                Id: Id,
                jobtitle: $("#jobtitle").val(),
                JobTypeId: $("#JobTypeId").val(),
                JobCategoryId: $("#JobCategoryId").val(),
                SId: $("#hSId").val(),
                TId: $("#hTId").val(),
                Designation: $("#Designation").val(),
                JobDescription: CKEDITOR.instances['JobDescription'].getData(),
                WorkExperienceMin: $("#WorkExperienceMin").val(),
                WorkExperienceMax: $("#WorkExperienceMax").val(),
                MinSalary: $("#AnnualCTCMin").val(),
                MaxSalary: $("#AnnualCTCMax").val(),
                QualificationId: $("#QualificationId").val(),
                JobStatusId: $("#JobStatusId").val(),
                CountryId: 0,// $("#CountryId").val(),
                StateId: 0, //$("#StateId").val(),
                City: "",//$("#AutocompleteCity").val(),

                LeftJobs: $("#JobTypeId").val(),
                zipcode: $("#zipcode").val(),
                sortdescription: $("#sortdescription").val(),
                location: $("#autocomplete_search").val(),
                SharedJob: SharedJob,
                Featured: Featured,
                JobTypeName: $("#JobTypeId option:selected").text(),
                JobCategoryName: $("#JobCategoryId option:selected").text(),
                SubCategoryName: $("#SubCategoryId option:selected").text(),
                StateName: "",//$("#StateId option:selected").text(),
                CountyName: "",// $("#CountryId option:selected").text(),
                SubCategoryId: $("#SubCategoryId").val(),
                PositionLevelId: $("#PositionLevelId").val(),
            }
            $.post("/Client/CreateJobs", model, function (data) {
                if (Id == 0) {
                    toastr.success("Job created successfully.");

                }
                else {
                    toastr.success("Job updated  successfully.");

                }
                var url = "/Client/JobList";

                setTimeout(function () { window.location.href = url }, 1000);
            });
            $("#createJob").attr('disable', false);

        }
    }
    else if ($("#hcheckplan").val() == "2") {
        toastr.info("Plan expired, Please renew !");
        return false;
    }

    else {
        toastr.info("Please purchase a plan !");
        return false;
    }



}
function Close() {
    var url = "/Admin/Admin/JobLists";
    window.location.href = url;
}
function CreateJobsvalidation() {
    //$.validator.addMethod('Salary', function (value, element) {
    //    return /[0-9]/i.test(value) && /,/i.test(value);
    //},'Please enter salary in correct format. For eg. 10,000')

    $("#PostJobfrom").validate({
        rules: {
            jobtitle: {
                required: true,
            },
            JobTypeId: {
                required: true,
            },
            JobStatusId: {
                required: true,
            },
            zipcode: {
                required: true,
                number: true
            },
            AnnualCTCMin: {
                required: true,                                               
            },
            AnnualCTCMax: {
                required: true,                                              
            }
            //terams: {
            //    required: true,
            //},
            //JobCategoryId: {
            //    required: true,
            //},
            //KeySkills: {
            //    required: true,
            //},
            //Designation: {
            //    required: true,
            //},
            //JobDescription: {
            //    required: true,
            //},
            //WorkExperienceMin: {
            //    required: true,
            //    number: true
            //},
            //WorkExperienceMax: {
            //    required: true,
            //},
            //AnnualCTCMin: {
            //    required: true,
            //    number: true
            //},
            //AnnualCTCMax: {
            //    required: true,
            //    number: true,
            //    //min: function () {
            //    //    return parseInt($('#AnnualCTCMin').val());
            //},
            //sortdescription: {
            //    required: true,
            //},
            //QualificationId: {
            //    required: true,
            //},
           
            //CountryId: {
            //    required: true,
            //},
            //StateId: {
            //    required: true,
            //},
            //autocomplete_search: {
            //    required: true,
            //},
           
            //autocomplete_search: {
            //    required: true,
            //},
            ////SubCategoryId: {
            ////    required: true,
            ////},
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

function GetEditJobbyId(Id) {
    var url = "/Client/Jobs?Ids=" + Id;
    window.open(url);
}

function GetJobDetailbyId(Id) {
    var url = "/Client/JobDetail?Ids=" + Id;
    window.location.href = url;
}

function JobDetailDeletebyId(Id) {

    if (JobDetailDeletebyIdvalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },

        $.get("/Home/JobDetailDeletebyId", model, function (data) {

            toastr.success("Job deleted  successfully.");


            setTimeout(function () { location.reload() }, 1000);
        });
}

function JobDetailDeletebyIdvalidation() {
    return confirm("Do you really want to delete this job?")
}
function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}

function AdminPostJobs(Id) {

    AdminPostJobsvalidation();
    if ($("#adminPostJobfrom").valid()) {
        model = {
            Id: Id,
            jobtitle: $("#jobtitle").val(),
            JobTypeId: $("#JobTypeId").val(),
            JobCategoryId: $("#JobCategoryId").val(),
            SId: $("#hSId").val(),
            TId: $("#hTId").val(),
            Designation: $("#Designation").val(),
            JobDescription: CKEDITOR.instances['JobDescription'].getData(),
            WorkExperienceMin: $("#WorkExperienceMin").val(),
            WorkExperienceMax: $("#WorkExperienceMax").val(),
            MinSalary: $("#AnnualCTCMin").val(),
            MaxSalary: $("#AnnualCTCMax").val(),
            QualificationId: $("#QualificationId").val(),
            JobStatusId: $("#JobStatusId").val(),
            ClientId: $("#ClientId").val(),
            CountryId: 0, //$("#CountryId").val(),
            StateId: 0,      /* $("#StateId").val(),*/
            sortdescription: $("#sortdescription").val(),
            City: 0, /*$("#AutocompleteCity").val(),*/
            zipcode: $("#zipcode").val(),
            location: $("#autocomplete_search").val(),

            JobTypeName: $("#JobTypeId option:selected").text(),
            JobCategoryName: $("#JobCategoryId option:selected").text(),
            SubCategoryName: $("#SubCategoryId option:selected").text(),

            StateName: ' ', /*$("#StateId option:selected").text(),*/
            CountyName: ' ', /*$("#CountryId option:selected").text(),*/
            SubCategoryId: $("#SubCategoryId").val(),
            PositionLevelId: $("#PositionLevelId").val(),
        }
        debugger;
        $.post("/Admin/Admin/AdminPostJobs", model, function (data) {
            if (Id === 0) {
                url = "/Admin/Admin/JobLists";
                setTimeout(function () { window.location.href = url }, 2000);
                toastr.success("Job created successfully.");
            }
            else {
                Url = "/Admin/Admin/JobLists";
                setTimeout(function () { window.location.href = Url }, 2000);
                toastr.success("Job updated  successfully.");

            }


        });
    }
}

function AdminPostJobsvalidation() {
   
    $("#adminPostJobfrom").validate({
        rules: {
            jobtitle: {
                required: true,
            },
            JobTypeId: {
                required: true,
            },
            JobStatusId: {
                required: true,
            },
            zipcode: {
                required: true,
                number: true
            },
            AnnualCTCMin: {
                 required: true,
               
            },
            AnnualCTCMax: {
                required: true,
                
            },
        
        },             
    });
}

function GetadminEditJobbyId(Id) {
    debugger;
    var url = "/Admin/Admin/PostJobs?JIds=" + Id;
    window.location.href = url;
}

function getSearchjobByName() {
    var JobTitle = $("#_jobtilte").val();
    var JobStatusId = $("#JobStatusId").val();
    debugger
    if (JobStatusId == '') {
        JobStatusId = 2;
    }
    var Url = "/Admin/Admin/JobLists?jobtitle=" + JobTitle + "&JobStatusId=" + JobStatusId;
    window.location.href = Url;

}

function GetadminJobDetailbyId(Id) {
    var url = "/Admin/Admin/JobDetails?Ids=" + Id;
    window.location.href = url;
}




function ResetSearchjob() {
    var url = "/Admin/Admin/JobLists";
    window.location.href = url;
}


function ResteSearchJob() {
    var url = "/Home/job";
    window.location.href = url;
}

function getJobDetail(Id) {
    var url = "/Home/jobdetail?Ids=" + Id;
    window.open(url, '_blank');
}

function SearchJob() {

    if ($("#SearchIdfrom").valid()) {
        SearchJobvalidation();
        var JobTitle = $("#JobTitle").val();
        var StateId = $("#StateId").val();
        var City = $("#location").val();
        var url = "/Home/job?JobTitle=" + JobTitle + "&City=" + City;
        window.location.href = url;
    }
}

function jobapplicantlist(JobId, jobStatus) {
    debugger;
    /*var url = "/Client/applicant?JIds=" + JobId + "&jobStatus=" + jobStatus;*/
    var url = "/Client/applicant?JobId=" + JobId + "&jobStatus=" + 2;
    window.location.href = url;
}



