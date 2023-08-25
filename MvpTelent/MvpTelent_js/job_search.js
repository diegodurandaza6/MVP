$(document).ready(function () {
    $("#dv_searchsection").hide();
    $("#dv_joblist").hide();

});


function job_search() {

    var city = '';
    var Id = '';

    if (parseInt($("#autocomplete_search").val())) {
        $("#milessection").show();
        $("#postal_code").val($("#autocomplete_search").val());
    } else {
        $("#milessection").hide();
        $("#postal_code").val('');
        city = $("#autocomplete_search").val();
    }

    if ($("#JobTitle").val() == "" && $("#autocomplete_search").val() == "" && $("#Tags").val() == "") {
        toastr.info("Please enter keyword or location .");
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


    var minsal = $("#slider-range").slider("values", 0);
    var maxsal = $("#slider-range").slider("values", 1);



    model = {
        jobtitle: $("#JobTitle").val(),
        Tags: $("#Tags").val(), // Keywords
        City: city, // Location value
        zipcode: $("#postal_code").val(), // Zip code 
        mile: $("input[name='miles']:checked").val(),
        days: $("#Days").val(),
        Jobtype: Id,
        Jobcatagory: JobCatagory,
        MinSalary: $("#slider-range").slider("values", 0),
        MaxSalary: $("#slider-range").slider("values", 1)
    }
    debugger
    $.get("/Home/jobPartialView", model, function (response) {
        debugger;//22
        $("#joblist").html();
        $("#joblist").html(response);
       
        $("#beforesearchsection").hide();
        $("#filterlistsection").show();

    });
}





function jobdetailbbyid(id) {

    if (parseInt($("#autocomplete_search").val())) {
        var url = "/Home/jobdetail?Id=" + id + "&zip=" + $("#autocomplete_search").val() + "&mile=" + $("input[name='miles']:checked").val()
        window.open(url, "_blank");
    }
    else {
        var url = "/Home/jobdetail?Id=" + id;
        window.open(url, "_blank");
    }

 
}




