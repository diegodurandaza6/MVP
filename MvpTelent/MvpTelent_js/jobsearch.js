$(document).ready(function () {
    $("#dv_searchsection").hide();
    $("#dv_joblist").hide(); 

});

 

function getId() {
    var ddd = $("#JobTitle").val();

}

var minPriceInRupees = 0;
var maxPriceInRupees = 500;
var currentMinValue = 33;
var currentMaxValue = 333;

var SolarPageIndex = 0;
var JobboardPageIndex = 0;
var PageCout = 0;
var CurrentPageIndex = 1;
var JobBoardCondition = true;
var html = '';

//click on search buttion
function GetSearchJob(CurrentPageIndex, checkid)
{
    if (checkid == 1)
    {
        $("#Days").val("");
        $('input[name="JobtypeId"]').each(function () {
            this.checked = false;
        });
        $('input[name="JobCatagoryId"]').each(function () {
            this.checked = false;
        });
        
    }
    var city = '';
    var Id = '';

    if (parseInt($("#autocomplete_search").val()))
    {
        $("#milessection").show();
        $("#postal_code").val($("#autocomplete_search").val());
    } else
    {
        $("#milessection").hide();
        $("#postal_code").val('');
        city = $("#autocomplete_search").val();
    }
    debugger;
    if ($("#JobTitle").val() == "" && $("#autocomplete_search").val() == "" && $("#Tags").val() == "") {
        toastr.info("Please enter keyword or location .");
        setTimeout(function () {
            $("#overlay").fadeOut(10);
        }, 20);
        return false;
    }

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


    var _Days = '';
    $.each($("input[name='Days']:checked"), function () {
        _Days += $(this).val() + ",";
    });
    if (_Days != '') {
        _Days = _Days.slice(0, -1);
    }


    var minsal = $("#slider-range").slider("values", 0);
    var maxsal = $("#slider-range").slider("values", 1);
    var daysid = $("input[name='Days']:checked").val();
    debugger;


    model = {
        jobtitle: $("#JobTitle").val(),
        Tags: $("#Tags").val(), // Keywords
        City: city, // Location value
        zipcode: $("#postal_code").val(), // Zip code 
        mile: $("input[name='miles']:checked").val(),
        days:   $("#Days").val(),
        salertchangeId: $("#salertchangeId").val(),
        Jobtype: Id,
        Relevance: 2, // $("#Relevance").val(),
        JobCategoryId: $("input[name='JobCatagoryId']:checked").val(), /*$("#JobCatagoryId").val()*/
        MinSalary: $("#slider-range").slider("values", 0),
        MaxSalary: $("#slider-range").slider("values", 1),
        CurrentPageIndex: CurrentPageIndex
    } 
    getjoblist(model); 
}


function getjoblist(model) { 
         html = '';
        $("#joblist").html('');
    $.ajax({
        url: "/Home/GetJobssearch",
        method: "GET",
        data: model,
        success: function (response) {
            $("#JobListPartialView").html();
            $("#JobListPartialView").html(response);
            //html = '';
            //$("#joblist").html('');
            //$.each(response.SolrJobListCollection, function () {
            //    var today = new Date(this.created_date);
            //    html += '<li>'
            //    html += '<div class="search-best-jobs-tiles-inner-body"> '
            //    html += '<a onclick="jobdetailbbyid(' + "'" + this.ids + "'" + ')" target="_blank" class="jobs-img"> '
            //    html += '<img src="' + this.ImagePath + '"  alt="image" />'
            //    html += '</a>'
            //    html += '<div class="jobs-body"> '
            //    html += '<div> '
            //    if (this.CategoryName == null) {
            //        html += 'N/A'
            //    } else {
            //        html += '<p class="head">' + this.CategoryName + '<i class="fas fa-check-circle"></i></p> '
            //    }

            //    html += '<a onclick="jobdetailbbyid(' + "'" + this.ids + "'" + ')" target="_blank" style="cursor:pointer">' + this.jobtitle + '</a>'
            //    html += '<p class="text">'

            //    if (this.SubCategoryName == null) {
            //        html += 'N/A'
            //    } else {
            //        html += '' + this.SubCategoryName + ''
            //    }

            //    html += '</p>'
            //    html += '</div>'
            //    html += '</div>'
            //    html += '<div class="jobs-star">'
            //    html += '<i class="fas fa-star"></i>'
            //    html += '</div>'
            //    html += '</div>'
            //    html += '<ul class="custom-filterlistsection">'
            //    html += '<li>'
            //    if (this.location == null) {
            //        html += '<span> N/A </span>'
            //    } else {
            //        html += '<span><i class="fas fa-map-marker-alt"></i> ' + this.location + '  </span>'
            //    }
            //    html += '</li>'
            //    html += '<li>'
            //    html += '<span><i class="fas fa-map-marker-alt"></i> ' + this.zip_code + '  </span>'
            //    html += '</li>'
            //    html += '<li>'
            //    html += '<span><i class="fas fa-briefcase"></i> ' + this.JobType + ' </span>'
            //    html += '</li>'
            //    html += '<li>'
            //    html += '<span><i class="fas fa-wallet"></i> $' + this.MinimumSalary + ' - $' + this.MaximumSalary + ' </span>'
            //    html += '</li>'
            //    html += '</ul>'
            //    html += '</li>'
            //});
            //if (html == '') {
            //    html += '<div class="no-data-section text-center">'
            //    html += '<figure class="no-data-img">'
            //    html += '<img src="/New_Content/images/404-img.png" class="img-fluid" />'
            //    html += '</figure>'
            //    html += '<p>Sorry , The data not found</p>'
            //    html += '</div>'
            //    $("#NextId").hide();

            //}
            //if (response.JobCountData < 10) {
            //    $("#NextId").hide();
            //}
            //$("#joblist").html(html);
            //if (response.JobCountData == 0) {
            //    JobBoardCondition = false;
            //    JobPerPage = 10;
            //    EmptyCondition = 1;
            //    // FindJobsZipRecruiter(JobPerPage, CurrentPageIndex, EmptyCondition, model);
            //}
            //else if (response.JobCountData < 10) {

            //    JobBoardCondition = false;
            //    JobPerPage = 10 - response.JobCountData;

            //    EmptyCondition = 1;
            //    // FindJobsZipRecruiter(JobPerPage, CurrentPageIndex, EmptyCondition, model);
            //}

            $("#beforesearchsection").hide();
            $("#filterlistsection").show();
        }
    }).done(function () {
        setTimeout(function () {
            $("#overlay").fadeOut(200);
        }, 500);
    });

    //$.get("/Home/GetJobssearch", model, function (response) {
    //    html = '';
    //    $("#joblist").html('');
    //    $.each(response.SolrJobListCollection, function () {
    //        var today = new Date(this.created_date); 
    //        html += '<li>'
    //        html += '<div class="search-best-jobs-tiles-inner-body"> '
    //        html += '<a onclick="jobdetailbbyid(' + "'" + this.ids + "'" + ')" target="_blank" class="jobs-img"> '
    //        html += '<img src="' + this.ImagePath + '"  alt="image" />'
    //        html += '</a>'
    //        html += '<div class="jobs-body"> '
    //        html += '<div> ' 
    //        if (this.CategoryName == null) {
    //            html += 'N/A'
    //        } else {
    //            html += '<p class="head">' + this.CategoryName + '<i class="fas fa-check-circle"></i></p> '
    //        }

    //        html += '<a onclick="jobdetailbbyid(' + "'" + this.ids + "'" + ')" target="_blank" style="cursor:pointer">' + this.jobtitle + '</a>'
    //        html += '<p class="text">' 

    //        if (this.SubCategoryName == null) {
    //            html += 'N/A'
    //        } else { 
    //            html += '' + this.SubCategoryName + ''
    //        }

    //        html += '</p>'
    //        html += '</div>'
    //        html += '</div>'
    //        html += '<div class="jobs-star">'
    //        html += '<i class="fas fa-star"></i>'
    //        html += '</div>'
    //        html += '</div>' 
    //        html += '<ul class="custom-filterlistsection">'
    //        html += '<li>' 
    //        if (this.location == null) { 
    //            html += '<span> N/A </span>' 
    //        } else {
    //            html += '<span><i class="fas fa-map-marker-alt"></i> ' + this.location + '  </span>'
    //        }  
    //        html += '</li>'
    //        html += '<li>'
    //        html += '<span><i class="fas fa-map-marker-alt"></i> ' + this.zip_code + '  </span>'
    //        html += '</li>'
    //        html += '<li>'
    //        html += '<span><i class="fas fa-briefcase"></i> ' + this.JobType + ' </span>'
    //        html += '</li>'
    //        html += '<li>'
    //        html += '<span><i class="fas fa-wallet"></i> $ ' + this.MinimumSalary + ' -$ ' + this.MaximumSalary + ' </span>'
    //        html += '</li>'
    //        html += '</ul>'
    //        html += '</li>' 
    //    }); 
    //    if (html == '') {
    //        html += '<div class="no-data-section text-center">'
    //        html += '<figure class="no-data-img">'
    //        html += '<img src="/New_Content/images/404-img.png" class="img-fluid" />'
    //        html += '</figure>'
    //        html += '<p>Sorry , The data not found</p>'
    //        html += '</div>'
    //        $("#NextId").hide();

    //    }
    //    if (response.JobCountData < 10) {
    //        $("#NextId").hide();
    //    }
    //    $("#joblist").html(html);
    //    if (response.JobCountData == 0) {
    //        JobBoardCondition = false;
    //        JobPerPage = 10;
    //        EmptyCondition = 1;
    //        // FindJobsZipRecruiter(JobPerPage, CurrentPageIndex, EmptyCondition, model);
    //    }
    //    else if (response.JobCountData < 10) {

    //        JobBoardCondition = false;
    //        JobPerPage = 10 - response.JobCountData;

    //        EmptyCondition = 1;
    //        // FindJobsZipRecruiter(JobPerPage, CurrentPageIndex, EmptyCondition, model);
    //    }

    //    $("#beforesearchsection").hide();
    //    $("#filterlistsection").show();
    //});
}
function FindJobsZipRecruiter(JobPerPage, JobboardPageIndex, EmptyCondition, model) {

    JobTitle = $("#JobTitle").val();
    Location = $("#autocomplete_search").val();
    if (Location == undefined) {
        Location = '';
    }
    if (model.days == undefined) { model.days = ''; }
    if (model.mile == undefined) { model.mile = ''; }

    var url = 'https://api.ziprecruiter.com/jobs/v1?search=' + JobTitle + '&location=' + Location + '&radius_miles=' + model.mile + '&days_ago=' + model.days + '&jobs_per_page=' + JobPerPage + '&page=' + JobboardPageIndex + '&api_key=55hd44exbh9ikyw4ffkcu6ryazfnqgqk';

    $.ajax({
        url: url,

        dataType: 'jsonp',
        success: function (response) {

            $.each(response.jobs, function () {
                var jobs = this;

                html += '<li>'
                html += '<div class="search-best-jobs-tiles-inner-body"> '
                html += '<a href="' + jobs.url + '" target="_blank" class="jobs-img"> '
                html += '<img src="/New_Content/images/zip.png"  alt="image" />'
                html += '</a>'
                html += '<div class="jobs-body"> '
                html += '<div> '
                html += '<p class="head">' + jobs.category + '<i class="fas fa-check-circle"></i></p> '
                html += '<a href="' + jobs.url + '" target="_blank" style="cursor:pointer">' + jobs.name + '</a>'
                html += '<p class="text">'
                html += '' + jobs.snippet + ''
                html += '</p>'
                html += '</div>'
                html += '</div>'
                html += '<div class="jobs-star">'
                html += '<i class="fas fa-star"></i>'
                html += '</div>'
                html += '</div>'

                html += '<ul>'
                html += '<li>'
                html += '<span><i class="fas fa-map-marker-alt"></i> ' + jobs.location + ' </span>'
                html += '</li>'
                html += '<li>'
                /* html += '<span><i class="fas fa-briefcase"></i>  Full Time  </span>'*/
                html += '</li>'
                html += '<li>'
                /* html += '<span><i class="fas fa-wallet"></i> $ ' + jobs.salary_min + ' -$ ' + jobs.salary_max + ' </span>'*/
                html += '</li>'
                html += '<li>'
                html += '<span><i class="far fa-clock"></i> ' + jobs.job_age + ' days ago </span>'
                html += '</li>'
                html += '</ul>'
                html += '</li>'

            });
            if (html == '') {
                html += '<div class="no-data-section text-center">'
                html += '<figure class="no-data-img">'
                html += '<img src="/New_Content/images/404-img.png" class="img-fluid" />'
                html += '</figure>'
                html += '<p>Sorry , The data not found</p>'
                html += '</div>'
                $("#NextId").hide();

            }
            $("#joblist").html(html);
            //$("#PageCountId").text(PageCout);
        },
        //error: function (xhr, ajaxOptions, thrownError) {
        //    $("#output").html("Error fetching " + URL);
        //}
    });
    $("#NextId").show();
}

function PagingNext() {
    PageCout++;
    CurrentPageIndex++;
    GetSearchJob();
    $("#PreviousId").show();
}

function PagingPrevious() {
    if (CurrentPageIndex > 0) {
        CurrentPageIndex--;
    }
    SolarPageIndex--;
    if (CurrentPageIndex == 1) {
        $("#PreviousId").hide();

    }
    if (SolarPageIndex == 1) {
        $("#PreviousId").hide();

    }
    PreviousFindJobs();
}
function PreviousFindJobs() {


    var Id = '';
    var city = '';
    var Jobtype = [];
    var SearchId = 1;
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
    if (parseInt($("#autocomplete_search").val())) {
        $("#postal_code").val($("#autocomplete_search").val());
        //city = $("#autocomplete_search").val();
    }
    else {
        city = $("#autocomplete_search").val();
        $("#postal_code").val('');
    }
    model = {
        CurrentPageIndex: CurrentPageIndex,
        jobtitle: $("#JobTitle").val(),
        zipcode: $("#postal_code").val(),
        StateId: $("#StateId").val(),
        City: city,
        JobStatusId: $("#JobSearchId").val(),
        Jobtype: Id,
        JobCategoryName: $("#JobSearchId").text(),
        days: $("input[name='Days']:checked").val(),
        mile: $("input[name='miles']:checked").val(),
        SearchId: SearchId

    }
    getjoblist(model);
}

function jobdetailbbyid(id) {
    debugger
    if (parseInt($("#autocomplete_search").val())) {
        var url = "/Home/jobdetail?Ids=" + id + "&zip=" + $("#autocomplete_search").val() + "&mile=" + $("input[name='miles']:checked").val()
        window.open(url, "_blank");
    }
    else {
        var url = "/Home/jobdetail?Ids=" + id;
        window.open(url, "_blank");
    }


}




