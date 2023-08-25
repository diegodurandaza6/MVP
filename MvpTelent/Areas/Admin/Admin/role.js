function search() {
    
    var Name = $('#Name').val();
    url = "/Admin/Admin/Rolelist?Name=" + Name;
     
    window.location.href = url;
}

function Reset() {
    url = "/Admin/Admin/Rolelist";
    window.location.href = url;

}



function getpage() {
     
    var model = {
        Id: 0
    };
    $.get("/Admin/Admin/getpage", model, function (data) {

        $("#pageli").empty();
        var html = "";
        $.each(data, function () {
            html += '<li><a><input class="clsrole" type="checkbox" name="' + this.Id + '" value="' + this.Id + '" /> ' + this.Name + '</a></li>';
        });
        $("#pageli").append(html);

        var data = $("#hdnPageids").val();
        if (data != null) {
            var arr = data.split(',');
            for (i = 0; i < arr.length; ++i) {
                $("input[name=" + arr[i] + "]:checkbox").prop('checked', true);
            }
        }
    });

}

function addnewrole(Id) {
    debugger
    model = { Id: Id };
    $.get("/Admin/Admin/addnewrole", model, function (response) {
        $("#AddNewRolePopup").html(response);
        $("#AddNewRolePopup").modal('show');

        getpage();
    });


}

function AddUpdateRole(Id) {
    debugger;

   
    AddUpdateCampaignvalidate();
    if ($('#RoleForm_Popup').valid()) {

        var PageId = "";
        $("input:checkbox[class=clsrole]:checked").each(function () {
            PageId += $(this).val() + ",";
        });

        if (PageId == "") {
            toastr.info("Please select page.");
            return false;
        }

        PageId = PageId.slice(0, -1);
        debugger;



        model = {
            Id: Id,
            Name: $("#Role").val(),
            PageId: PageId,
            description: $("#description").val(),
            statusId: $("#statusId").val() 
        }
        $.post("/Admin/Admin/AddUpdateRole", model, function (data) {
            if (Id === 0) {
                toastr.success("Role Saved Successfully.");
                setTimeout(function () { window.location.reload() }, 600);
            }
            else {
                toastr.success("Role Updated Successfully.");
                setTimeout(function () { window.location.reload() }, 600);
            }

        });
    }
}



function AddUpdateCampaignvalidate() {
    $("#RoleForm_Popup").validate({
        rules: {
            Role: {
                required: true
            },
            statusId: {
                required: true
            } 
        }
    });
}

