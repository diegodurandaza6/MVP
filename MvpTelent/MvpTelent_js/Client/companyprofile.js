function AddCompanyContact(CompanyId, Id, UseraccountprofileId) {

    var lastname = " ";
    AddCompanyContactvalidation();
    if ($("#lastname").val() == "") {
        lastname = " "
    } else {
        lastname = $("#lastname").val();
    }

    if ($("#ClientContactForm").valid()) {
        model =
        {
            Id: Id,
            CompanyId: CompanyId,
            Name: $("#firstname").val(),
            LastName: lastname, //$("#lastname").val(),
            Email: $("#email").val(),
            UseraccountprofileId: UseraccountprofileId,
            Phone1: $("#Phone").val(),
            Position: $("#Position").val(),
            Linkdin: $("#Linkdin").val(),
        },
            $.get("/Client/AddCompanyContact", model, function (data) {
                if (data == 2) {
                    toastr.success("Contact created successfully.");
                    setTimeout(function () { location.reload() }, 400);
                }
                else if (data == 1) {

                    toastr.info("This Email already exists.");
                }
                else {
                    toastr.success("Contact Update seccessfully.");
                    setTimeout(function () { location.reload() }, 400);
                }

            });
    }
}


function AddCompanyContactvalidation() {
    $("#ClientContactForm").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            firstname: {
                required: true,
            },
            //lastname: {
            //    required: true,
            //},
            Phone: {
                number: true,
            },

        }
    });
}


function Update_Company(Id) {
    debugger;
    Createcompanyvalidation();
    if ($("#Clientform").valid()) {

        var ImageFile = $("#CompanyImageId").get(0);
        var files = ImageFile.files;
        var fileData = new FormData();
        var fileName = '';
        if (files.length > 0) {
            fileData.append(files[0].name, files[0]);
            fileName += files[0].name;
            var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
            if (fileExtension.toLowerCase() !== "jpeg" && fileExtension.toLowerCase() != "png" && fileExtension.toLowerCase() !== "jpg" && fileExtension.toLowerCase() !== "bmp") {
                toastr.warning("Upload only (.jpg , .png , .jpeg, .bmp ) file.");
                return false;
            }
        }
        else {
            fileName = $("#labelId").text();
        }
        fileData.append('FileName', fileName);
        fileData.append('Id', Id);
        fileData.append('name', $("#company").val());
        fileData.append('Website', $("#Website").val());
        fileData.append('Description', $("#Description").val());
        fileData.append('Address', $("#Address").val());
        fileData.append('Location', $("#autocomplete_search").val());
        fileData.append('Zip', $("#Zip").val());


        $.ajax({
            type: "Post",
            url: "/Client/AddUpdateCompany",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (message) {
                if (Id == 0) {
                    toastr.success("Company created successfully.");
                }
                else {

                    toastr.success("Company updated  successfully.");
                }
                setTimeout(function () { location.reload(); }, 400);
            },
            error: function () {
                alert("There is an error uploading files!");
            }

        });

    }
}




function DeleteClientContact(UserId, Status) {

    if (DeleteClientContactconfrimation() === false) {
        return false;
    }
    model = {
        Id: UserId,
        Status: Status
    },
        $.post("/Client/DeleteClientContact", model, function () {

            setTimeout(function () { window.location.reload(); }, 2000);
            toastr.success("Status change successfully.");
        });
}
function DeleteClientContactconfrimation() {
    return confirm(" Do you really want to change status?");
}

function Createcompanyvalidation() {
    $("#Clientform").validate({
        rules: {
            company: {
                required: true,
            },
            Website: {
                required: true,
            },

        }
    });
}
function updatecompanypopup(Id) {
    model = {
        Id: Id
    }
    $.get("/Client/updatecompanypopup", model, function (response) {
        $("#dv_updatecompanypopup").html(response);
        $("#dv_updatecompanypopup").modal("show");
    });
}
function CompanyContact(ClientId, Id, UseraccountprofileId) {
    debugger
    model = {
        ClientId: ClientId,
        Id: Id,
        UseraccountprofileId: UseraccountprofileId
    };

    $.get("/Client/CompanyContact", model, function (response) {
        $("#ClientContactDetails_PopUp").html(response);
        $("#ClientContactDetails_PopUp").modal("show");
    });
}

function RedirectToDashboard() {
    url = "/client/dashboard";
    window.location.href = url;
}

function ResendActivationEmail(Id) {
    if (ResendActivationEmail_Confirm() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.post("/client/ResendActivationEmail", model, function () {
        toastr.success("Email sent successfully.");
        setTimeout(function () { window.location.reload(); }, 500);

    });
}

function ResendActivationEmail_Confirm() {
    return confirm('Are you sure to send resend activation email?');
}