
function updateprofilevalidations() {
    $("#profileform").validate({
        rules: {
            Name: {
                required: true
            },
            PhoneNo: {
                required: true
            },
            companyName: {
                required: true
            },
            companywebsite: {
                required: true
            } 
        }
    });
}

 
function updateprofile(Id) {
     
    updateprofilevalidations();
    if ($('#profileform').valid()) {
        //model = {
        //    UserId: Id,
        //    Name: $("#Name").val(),
        //    Email: $("#Email").val(),
        //    PhoneNo: $("#PhoneNo").val(),
        //};
        //$.post("/Admin/Admin/updateprofile", model, function (data) {
        //     
        //         toastr.success("Profile Updated successfully.");
        //        setTimeout(function () { window.location.reload() }, 600);
             
        //});
        if (window.FormData !== undefined) {
            var FileName = $("#adminfile").get(0);
            var files = FileName.files;
            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
                var fileName = files[i].name;


                var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;
                if (fileExtension.toLowerCase() != "jpg" && fileExtension.toLowerCase() != "png" && fileExtension.toLowerCase() != "jpeg") {
                    toastr.warning("Upload only (.jpg , .png , .Jpeg) file.");
                    return false;
                }
            }
            var fileUploadedName = $("#hadminimage").val();
            var fileName = fileName === undefined ? fileUploadedName : fileName;
            //fileName = fileName === undefined ? $("#hclientlogo").text() : fileName;
            fileData.append('UserId', Id);
            fileData.append('Name', $("#Name").val());

            fileData.append('FileName', fileName);
            fileData.append('Email', $("#Email").val());
            fileData.append('PhoneNo', $("#PhoneNo").val());

            fileData.append('LastName', $("#LastName").val());
            fileData.append('CompanyName', $("#companyName").val());
            fileData.append('companywebsite', $("#companywebsite").val());
            fileData.append('CountryId', $("#CountryId").val());
            fileData.append('StateId', $("#StateId").val());
            //fileData.append('CityName', $("#AutocompleteCity").val());
            fileData.append('location', $("#autocomplete").val());
            $.ajax({
                url: "/Admin/Admin/updateprofile",
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (data) {
                    toastr.success(" Profile updated successfully.");
                    setTimeout(function () { window.location.reload() }, 800);
                }
            });
        }
    }
}