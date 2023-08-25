function getcandidatedetails(Id, JobId) {
    var Url = "/Client/detail?Ids=" + Id + "&JIds=" + JobId;
    window.open(Url);
}
function getcandidateConfidetails(Id, JobId) {
    var Url = "/Home/details?Id=" + Id + "&JobTypeId=" + JobId;
    window.open(Url);
}
function PagerClick(CurrentPageIndex) {
    var CandidateName = $("#_CName").val();
    var location = $("#location").val();
    url = "/client/myfavorite?CurrentPageIndex=" + CurrentPageIndex + "&CandidateName=" + CandidateName + "&location=" + location;
    window.location.href = url;
}
function favoritecandidateremove(CandidateId, StatusId) {
     
    model = {
        Id: CandidateId,
        ClientId: $("#clientId").val(),
        Status: StatusId
    }
    $.get("/Client/favoritecandidate", model, function (data) {
        if (data.Status == 1) {
            toastr.success("Candidate add to favorite  successfully.");
            setTimeout(function () { window.location.reload() }, 2000);
        }
        else {
            toastr.success("Favorite candidate removed successfully.");
            searchmyfavourite(1, 0);
        }
    });
      
}


function favoritecandidateremoveconfirm() {
    return confirm("Are you sure  you want to deleted this candidate from favorite list.");
} 

function searchmyfavourite(CurrentPageIndex, checkid) {
    
    $("#h_tabid").val(1);
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
    setTimeout(function () {
        $("#overlay").fadeOut(10);
    }, 20);
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
    city = $("#autocomplete_search").val();
    
    var ids11 = $("input[name='educationlavelId']:checked").val();
    var level = $('#' + ids11).html();
   
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
    
    model = {
        CurrentPageIndex: CurrentPageIndex,
        Title: $("#Title").val(),
        Keyword: $("#Keyword").val(),
        location: city,
        Zipcode: $("#postal_code").val(),
        mile: $("#miles").val(),/* $("input[name='miles']:checked").val(),*/
        JobTypeName: Id,
        experienceIds: ExperienceIds, // $("input[name='experienceId']:checked").val(),
        educationlevel: educationlavelIds,
        JobCategoryName: JobCatagory,
    }, 
    $.ajax({
        url: "/Client/myfavoritePartialView",
        method: "GET",
        data: model,
        success: function (response) {
            $("#myfavoriteListTable").html();
            $("#myfavoriteListTable").html(response);
            $("#filtersection").show(); 
            $("#beforesearchsection").hide();
            $("#lblFavoriteTotalRowCount").text($("#h_TotalFavoriteRowCount").val())
        }
    }).done(function () {
        setTimeout(function () {
            $("#overlay").fadeOut(100);
        }, 300);
    });

}

function myfavouritereset() {
    var Url = "/client/myfavorite";
    window.location.href = Url;
}


function favoritecandidatevalidation() {
    return confirm("Do you really want to remove this favorite candidate ?");
}

function removecandidateinfavorite(CandidateId, StatusId) {
    debugger
    if (favoritecandidatevalidation() == false) {
        return false;
    }
    model = {
        Id: CandidateId,
        ClientId: $("#clientId").val(),
        Status: StatusId
    }
    $.get("/Client/favoritecandidate", model, function (data) {
        debugger;
        if (data.Status == 1) {
            toastr.success("Candidate add to favorite  successfully.");
            setTimeout(function () { window.location.reload() }, 2000);
        }
        else {
            toastr.success("Candidate delete  successfully from favorite list.");
            searchmyfavourite(1, 0);
        }
    });
}