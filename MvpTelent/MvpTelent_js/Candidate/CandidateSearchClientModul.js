
function Addcandidateshortlistbyid(Id) {
 
    model = {
        Id: Id,
        ClientId: $("#clientId").val(),
        Status: 0
    }
    $.get("/Client/AddTofavoritecandidate", model, function (data) {
        if (data.Status == 0) {

            CandidateSearchByClient(1, null, null);
         

            toastr.success("Candidate added to your Favorites list successfully."); 
            var favourite_heart1 = document.getElementById("favourite_heart_" + Id);
            favourite_heart1.classList.add("fa");
            favourite_heart1.classList.add("fa-heart");
            favourite_heart1.classList.remove("fa-heart-o");

            var count = $("#lblFavoriteTotalRowCount").text();
            var ICount = parseInt(count) + 1;
            $("#lblFavoriteTotalRowCount").text(ICount);
            debugger;
        }
        else {
            toastr.info("This candidate already add in favorite lists");
        }
    });
}
function Confirmation() {
    return confirm("Are you sure you want to favorite this candidates?");
}



function removefavoritecandidate(CandidateId, StatusId) {
    debugger;
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

            CandidateSearchByClient(1, null, null); 

            toastr.success("Favorite candidate removed successfully.");
        
            var favourite_heart1 = document.getElementById("icon_" + CandidateId);
            favourite_heart1.classList.add("fa-heart-o");
            favourite_heart1.classList.remove("fas");
            favourite_heart1.classList.remove("fa-heart");

            var count = $("#lblFavoriteTotalRowCount").text();
            var ICount = parseInt(count) - 1;

            if (ICount == 0 || ICount > 0) {
                $("#lblFavoriteTotalRowCount").text(ICount);
            }
             

        }
    });

}




function clearfilter() { 
    $("#miles").val(25);
    $('input[name="JobtypeId"]').each(function () {
        this.checked = false;
    });

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

    CandidateSearchByClient(1, 0)
}

function CandidateSearchByClient(CurrentPageIndex, gId, checkid) {
    debugger
    if (checkid == 1) {
        $("#h_tabid").val(0)
    }
    if ($("#h_tabid").val() == 0) {
        if (checkid == 1) {
            $("#miles").val(25);
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
            document.getElementById("home-tab").className = 'nav-link active';
            document.getElementById("home").className = 'tab-pane active';

            document.getElementById("profile-tab").className = 'nav-link';
            document.getElementById("profile").className = 'tab-pane';
        }
        var SearchId = 1;

        var Id = '';

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
            gid: gId,
            StateId: 0,
            Jobcatagory: JobCatagory,
            Jobtype: Id,
            mile: $("#miles").val(), // $("input[name='miles']:checked").val(),
            experienceIds: ExperienceIds, // $("input[name='experienceId']:checked").val(),
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
                url: "/Home/CandidateSearchByClient",
                method: "GET",
                data: model,
                success: function (response) {
                    $("#CandiateListTable").html();
                    $("#CandiateListTable").html(response);
                    $("#filtersection").show();
                    $("#recentsearch").hide();
                    $("#beforesearchsection").hide();
                    $("#TotalRowCount").text($("#h_TotalRowCount").val())
                  
                  //  searchmyfavourite(1, 1)
                }
            }).done(function () {
                setTimeout(function () {
                    $("#overlay").fadeOut(100);
                }, 300);
            });
    } else {
        searchmyfavourite(1, 0);
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

function decrementValue() { 

    if ($("#autocomplete_search").val() == "") {
        toastr.info("Please enter city / state / zip code.");
        return false;
    } 

    var value = parseInt(document.getElementById('miles').value);
    if (value < 25 || value == 25) {
        const button1 = document.getElementById("btndecrement");
        button1.disabled = true; // disabling it by default 
        document.getElementById('btndecrement').style.backgroundColor = '#f5f5f5';

    } else { 
        if (value != 0) {
            value = isNaN(value) ? 0 : value;
            value = parseInt(value) - parseInt(25);
            document.getElementById('miles').value = value;
            document.getElementById('btndecrement').style.backgroundColor = '#f5f5f5';
            document.getElementById('btnincrement').style.backgroundColor = '#f5f5f5';

            if (value == 25) {
                const button1 = document.getElementById("btndecrement");
                button1.disabled = true; // disabling it by default 
                document.getElementById('btndecrement').style.backgroundColor = '#f5f5f5';

            }

        }
    }
    if (value == 100 || value < 100) {
        const button1 = document.getElementById("btnincrement");
        button1.disabled = false;
    }


    CandidateSearchByClient(1, null, null);
}
function incrementValue()
{
    if ($("#autocomplete_search").val() == "") {
        toastr.info("Please enter city / state / zip code.");
        return false;
    }
    var value = parseInt(document.getElementById('miles').value);

    if (value > 99 || value == 100) {
        const button1 = document.getElementById("btnincrement");
        button1.disabled = true;
        document.getElementById('btnincrement').style.backgroundColor = '#f5f5f5';
         

    }
    else {
        value = isNaN(value) ? 0 : value;
        value = parseInt(value) + parseInt(25);
        document.getElementById('miles').value = value;
        document.getElementById('btndecrement').style.backgroundColor = '#f5f5f5';
        document.getElementById('btnincrement').style.backgroundColor = '#f5f5f5';
        if (value == 100) {
            const button1 = document.getElementById("btnincrement");
            button1.disabled = true;
            document.getElementById('btnincrement').style.backgroundColor = '#f5f5f5';
             

        }
    }

    if (value > 25 || value == 25) {
        const button1 = document.getElementById("btndecrement");
        button1.disabled = false;
    } 
    CandidateSearchByClient(1, null, null);
}


function candidatedetails(Id, jobtypeId) {
    if (parseInt($("#autocomplete_search").val())) {
        var Url = "/Home/details?Id=" + Id + "&JobTypeId=" + jobtypeId + "&zip=" + $("#autocomplete_search").val() + "&mile=" + $("input[name='miles']:checked").val();
        window.open(Url, '_blank');
    }
    else {
        var Url = "/Home/details?Id=" + Id + "&JobTypeId=" + jobtypeId;
        window.open(Url, '_blank');
    }
}

