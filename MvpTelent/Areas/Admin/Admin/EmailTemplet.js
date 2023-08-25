
function NewTemplate(Id) {
     
    model = { Id: Id };
    $.get("/Admin/Admin/GetEmailTempleteById", model, function (response) {
        $("#AddNewTemplatePopup").html(response);
        $("#AddNewTemplatePopup").modal('show');


    });
}
function getTempletByName() {
  
    var Name = $('#_Name').val();
    var Status = $('#StatusID').val();
    url = "/Admin/Admin/email?Name=" + Name + "&EmailStatus=" + Status;;
    debugger
    window.location.href = url;
}
function Reset() {
    url = "/Admin/Admin/email";
    window.location.href = url;
}


function EmailTemplatevalidations() {
    $("#EmailTemplateForm_Popup").validate({
        rules: {
            Name: {
                required: true
            },
            Subject: {
                required: true
            },
            Description: {
                required: true
            }
        }
    });
}

function DeleteEmailTemplate(Id, StatusId) {
    if (DeleteContactconfirm() === false) {
        return false;
    }

    model = {
        Id: Id,
        StatusId: StatusId
    };
    $.get("/Admin/Admin/DeleteEmailTemplate", model, function (data) {
        toastr.success("Status change successfully.");
        setTimeout(function () { location.reload() }, 600);
    });

}
function DeleteContactconfirm() {
    return confirm("Are you sure want to change status?");
}
function AddUpdateEmailTemplate(Id) {
     
    EmailTemplatevalidations();
    if ($('#EmailTemplateForm_Popup').valid()) {

        model = {
            Id: Id,
            Name: $("#Name").val(),
            Subject: $("#Subject").val(),
            Description: $("#Description").val(),
            Description1: $("#Description1").val(),
            Description2: $("#Description2").val(),
            Description3: $("#Description3").val(),
            
        };
        $.post("/Admin/Admin/AddUpdateEmailTemplate", model, function (data) {
             
            if (Id === 0) {
                toastr.success("Email templete saved successfully.");
                setTimeout(function () { window.location.reload() }, 600);
            }
            else {
                toastr.success("Email templete updated successfully.");
                setTimeout(function () { window.location.reload() }, 600);
            }
        });
    }
}