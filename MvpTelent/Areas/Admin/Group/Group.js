
function NewGroup(Id) {
     
    model = { Id: Id };
    $.get("/Admin/Candidate/GroupPopup", model, function (response) {
        $("#AddNewGroupPopup").html(response);
        $("#AddNewGroupPopup").modal('show');
         
    });
}
function CandidateDetail(Id) {
     
    var url = "/Admin/Candidate/detailedprofile?Ids=" + Id;
    window.location.href = url;
}
function GroupDetail(Id ) {
     
    url = "/admin/candidate/details?Id=" + Id ;
    window.location.href = url;
}
function AddUpdateGroupValidation() {
    $("#Group_Popup").validate({
        rules: {
            Name: {
                required: true
            } 
        }
    });
}

function GroupStatusConfirm() {
    return confirm(" Do you really want to change the status?");
}


function status(Id,ids) {
    if (GroupStatusConfirm() === false) {
        return false;
    }
    model = {
        Id: Id,
        Status: ids
    };
    $.get("/Admin/Candidate/ChnageGroupStatus", model, function (data) {
        toastr.success("Status updated successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}


function removeingroupConfirm() {
    return confirm(" Do you really want to remove candidate in this group?");
}

function removeingroup(Id) {
    if (removeingroupConfirm() === false) {
        return false;
    }
    model = {
        Id: Id
    };
    $.get("/Admin/Candidate/removeingroup", model, function (data) {
         
        toastr.success("Candidate removed successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}

function AddUpdateGroup(Id) {

    AddUpdateGroupValidation();
    if ($('#Group_Popup').valid()) {
        model = {
            Id: Id,
            Name: $("#Name").val(),
            Description: $("#Description").val(), 
        }; 
        $.get("/Admin/Candidate/CreateGroup", model, function (data) {
             
            if (data.Id == 0) {
                toastr.success("Group created successfully.");
            } else {
                toastr.success("Group Updated successfully.");
            }
            setTimeout(function () { window.location.reload() }, 600);
        });
    }
}


function getGroupByName()
{
    var Name = $('#_Name').val();
    var Status = $('#StatusID').val();
    url = "/Admin/candidate/Group?Name=" + Name + "&Status=" + Status;
    window.location.href = url;

}

function Resetgroup()
{
    url = "/Admin/candidate/Group";
    window.location.href = url;

}