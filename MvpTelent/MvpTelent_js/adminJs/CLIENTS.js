function StateList(Id) {

    var model = { Id: Id };
    $.get("/Admin/Admin/StateList", model, function (data) {
        $("#StateId").empty();
        $("#StateId").append($("<option />").val("").html("Select State"));
        $.each(data, function () {

            $("#StateId").append($("<option />").val(this.Id).html(this.Name));
        });
    });
}

function CityList(Id) {

    var model = {
        Id: Id
    };
    $.get("/Admin/Admin/CityList", model, function (data) {
        $("#CityId").empty();

        $("#CityId").append($("<option />").val("").html("Select City"));


        $.each(data, function () {
            $("#CityId").append($("<option />").val(this.Id).html(this.Name));
        });
    });
}

function CreateCompany(Id) {
    debugger;

    if ($("#CompanyName").val() == "") {
        $('#lblName').text('This field is required.');
        return false;

    }
    else {
        if ($("#CompanyName").val().trim() == "") {
            $('#lblName').text('This field is required.');
            return false;
        }
        else {
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
            fileData.append('name', $("#CompanyName").val());
            fileData.append('Website', $("#Website").val());
            fileData.append('Description', $("#Description").val());
            fileData.append('Address', $("#Address").val());
            fileData.append('Location', $("#autocomplete_search").val());
            fileData.append('Zip', $("#Zip").val());


            $.ajax({
                type: "Post",
                url: "/Admin/Admin/CreateClient",
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




}


function CreateCompanyvalidation() {

    $("#addclientforms").validate({
        rules: {
            username: {
                required: true,
            },
            //Website: {
            //    required: true,
            //},

            //Phone1: {
            //    required: true,
            //    minlength: 9,
            //    maxlength: 10,
            //    number: true
            //},
            //Phone2: {
            //    required: true,
            //    minlength: 9,
            //    maxlength: 10,
            //    number: true
            //},
            //autocomplete_search: {
            //    required: true,
            //},
            Zip: {
                /*required: true,*/
                number: true
            },
            //JobPostingUrl: {
            //    required: true,
            //},
        }
    });
}

function ClientEditById(Id) {

    var url = "/Admin/Admin/Client?Id=" + Id;
    window.location.href = url;

}

function ClientDelete(Id, StatusId) {
    debugger;
    if (ClientDeleteConfirmation() === false) {
        return false;
    }
    model = {
        Id: Id,
        Status: StatusId,
    },
        $.post("/Admin/Admin/ClientDelete", model, function () {
            toastr.success("Status change successfully.");
            setTimeout(function () { window.location.reload(); }, 800);
        });
}

function ClientDeleteConfirmation() {
    return confirm(" Do you really want to change status?");
}

function clientdetail(Ids) {

    var url = "/Admin/Admin/clientdetail?Ids=" + Ids;
    window.open(url);

}

function getClientByStatus() {
    var Name = $('#Name').val();
    var Zip = 0;
    var Location = 0;

    if (parseInt($("#zip").val())) {
        Zip = $("#zip").val();
        var MileId = $("#MileId").val();
        url = "/Admin/Admin/company?Name=" + Name + "&Zip=" + Zip + "&MileId=" + MileId;
        window.location.href = url;
    }
    else {

        Location = $("#zip").val();
        url = "/Admin/Admin/company?Name=" + Name + "&Location=" + Location;
        window.location.href = url;
    }


}

function ResetSearch() {
    url = "/Admin/Admin/company";
    window.location.href = url;
}

function ClientContact(ClientId, Id, UseraccountprofileId) {

    model = {
        CompanyId: ClientId,
        Id: Id,
        UseraccountprofileId: UseraccountprofileId
    };
    debugger
    $.get("/Admin/Admin/ClientContact", model, function (response) {
        $("#ClientContactDetails_PopUp").html(response);
        jQuery.noConflict();
        $("#ClientContactDetails_PopUp").modal("show");
    });
}

function AddClientContact(Id, ClientId, UseraccountprofileId) {
    debugger

    var _LoginAccess = "";
    if ($('input[name="LoginAccess"]').prop("checked") === true) {
        _LoginAccess = 1;
    }
    else if ($('input[name="LoginAccess"]').prop("checked") === false) {
        _LoginAccess = 2;
    }
    if (_LoginAccess == 1) {
        if ($("#Email").val().trim() == "") {
            $('#lblemail').text('This field is required.');
            return false;
        }
    }
    else {
        $('#lblemail').text('');
    }


    if ($("#UserName").val().trim() != "")
    {
        if ($("#Email").val().trim() == "" && $("#phone").val().trim() == "") {
            $('#lblemailphone').text('One fields is required in email and phone number.');
            return false;

        } else {
            $('#lblemailphone').text('');
        }  
        if ($("#Email").val() != "") {
            if ($("#Email").val().trim() != "") {
                var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
                if ($("#Email").val().match(mailformat)) {
                    Add_Client_Contact(Id, ClientId, UseraccountprofileId, _LoginAccess);
                }
                else {
                    $('#lblemail').text('Please enter a valid email address.');
                    return false;
                }
            }
        }
        else {
            Add_Client_Contact(Id, ClientId, UseraccountprofileId, _LoginAccess);
        }
    }
    else {
        $('#lblName').text('This field is required.');
        if ($("#Email").val().trim() == "" && $("#phone").val().trim() == "") {
            $('#lblemailphone').text('One fields is required in email and phone number.');
            return false;

        } else {
            $('#lblemailphone').text('');
        }
    }


}

function Add_Client_Contact(Id, ClientId, UseraccountprofileId, _LoginAccess) {

    model = {
        Id: Id,
        CompanyId: ClientId,
        UseraccountprofileId: UseraccountprofileId,
        Name: $("#UserName").val(),
        LastName: $("#LastName").val(),
        Email: $("#Email").val().trim(),
        Phone1: $("#phone").val(),
        Position: $("#Position").val(),
        FaceBook: $("#FaceBook").val(),
        twitter: $("#twitter").val(),
        Linkdin: $("#Linkdin").val(),
        Instagram: $("#Instagram").val(),
        lastemailsent: $("#lastemailsent").val(),
        LoginAccess: _LoginAccess
    },
        $.get("/Admin/Admin/AddClientContact", model, function (data) {
            if (data.Status == 2) {
                setTimeout(function () { window.location.reload(); }, 2000);
                toastr.success("Contact created successfully.");
            }
            else if (data.Status == 3) {
                setTimeout(function () { window.location.reload(); }, 2000);
                toastr.success("Contact updated successfully.");
            }
            else {
                toastr.error("This contact already exists.");
            }
        });
}




function AddClientContactvalidation() {
    $("#ClientContactForm").validate({
        rules: {
            UserName: {
                required: true,
            },
            //Email: {
            //    required: true,
            //    email: true
            //},
            //Phone: {
            //    required: true,
            //},
        }
    });
}

function MakePhoneRequiredFalse() {
    debugger;
    $("#ClientContactForm").validate({
        rules: {
            Phone: {
                required: false,
            },
        }
    });
}

function MakeEmailRequiredFalse() {
    $("#ClientContactForm").validate({
        rules: {
            Email: {
                required: false,
            },
        }
    });
}

function Admin_DeleteCompanyContact(Id) {

    if (DeleteClientContactconfrimation() === false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.post("/Admin/Admin/Admin_DeleteCompanyContact", model, function () {

            setTimeout(function () { window.location.reload(); }, 2000);
            toastr.success("Contact deleted successfully.");
        });
}
function DeleteClientContactconfrimation() {
    return confirm(" Do you really want to delete this contact?");
}

function Createclientpopup(Id) {

    model = { Id: Id },

        $.get("/Admin/Admin/Company_popup", model, function (response) {

            $("#Clientcreate_PopUp").html(response);
            jQuery.noConflict();
            $("#Clientcreate_PopUp").modal("show");
        });

}


function CreateCompanypopup(Id) {

    model = { Id: Id },

        $.get("/Admin/Admin/Createclientpopup", model, function (response) {
            $("#Clientcreate_PopUp").html(response);
            $("#Clientcreate_PopUp").modal("show");
        });

}

function SaveNotes(Id) {
    SaveNotesvalidation()
    if ($("#notesform").valid()) {

        model = {
            Id: Id,
            comments: $("#comment").val()
        }
        $.post("/Admin/Admin/SaveNotes", model, function () {


            setTimeout(function () { window.location.reload(); }, 2000);
            toastr.success("Company notes saved successfully.");
        });
    }
}

function SaveNotesvalidation() {
    $("#notesform").validate({
        rules: {
            comment: {
                required: true,
            }
        }

    });
}

function NOtesDelete(Id) {
    if (NOtesDeletevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.post("/Admin/Admin/NOtesDelete", model, function () {
        setTimeout(function () { window.location.reload(); }, 2000);
        toastr.success("Company notes deleted successfully.");

    });

}

function NOtesDeletevalidation() {
    return confirm("Do you really want to delete this Notes?")
}

function AddCompanyToDoPopUp(Id, CLientId) {
    model = {
        Id: Id,
        CLientId: CLientId
    },
        $.get("/Admin/Admin/AddCompanyToDoPopUp", model, function (response) {

            $("#Company_todo_popup").html(response);
            jQuery.noConflict();
            $("#Company_todo_popup").modal("show");

        });
}

var check = 0;

function checkCompanyName() {
    if ($("#CompanyName").val() == "") {
        $('#lblCompanyName').text('This field is required.');
        return false;

    }
    else {
        if ($("#CompanyName").val().trim() == "") {
            $('#lblCompanyName').text('This field is required.');
            return false;
        }
        else {
            $('#lblCompanyName').text('');

            return true;
        }
    }
}
function checkName() {
    if ($("#FirstName").val() == "") {
        $('#lblFirstName').text('This field is required.');
        return false;

    }
    else {
        if ($("#FirstName").val().trim() == "") {
            $('#lblFirstName').text('This field is required.');
            return false;
        }
        else {
            $('#lblFirstName').text('');
            return true;
        }
    }
}

function checkemail() {
    debugger;
    if ($("#email").val() == "") {
        $('#lblemail').text('This field is required.');
        return false;

    }
    else {
        if ($("#email").val().trim() == "") {
            $('#lblemail').text('This field is required.');

        }
        else {
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if ($("#email").val().match(mailformat)) {
                $('#lblemail').text('');
                return true;
            }
            else {
                $('#lblemail').text('Please enter a valid email address.');
                return false;
            }




        }
    }
}

function Create_Company(Id) {

    if (checkCompanyName() == false) {

    }
    if (checkName() == false) {

    }
    if (checkemail() == false) {
        return false;
    }
    if (checkCompanyName() == true && checkName() == true && checkemail() == true) {
        var _LoginAccess = "";
        if ($('input[name="LoginAccess"]').prop("checked") === true) {
            _LoginAccess = 1;
        }
        else if ($('input[name="LoginAccess"]').prop("checked") === false) {
            _LoginAccess = 2;
        }
        model =
        {
            Id: 0,
            FirstName: $("#FirstName").val(),
            LastName: $("#LastName").val(),
            Email: $("#email").val(),
            Company: $("#CompanyName").val(),
            Address: $("#Address").val(),
            Website: $("#Website").val(),
            Location: $("#autocomplete_search").val(),
            Zip: $("#Zip").val(),
            LoginAccess: _LoginAccess
        },
            $.get("/Admin/Admin/CreateCompany", model, function (data) {
                if (data == 1) {
                    toastr.success("Company created successfully.");
                    setTimeout(function () { location.reload() }, 400);
                }
                else if (data == 2) {
                    toastr.info("This email already exists. Chanage your email");
                } else {
                    toastr.info("Server error !");
                }

            });
    }

}



function CreatecompanyToDo(Id, ClientId) {

    if ($("#subject").val() == "") {
        toastr.info("Please enter subject.");
        return false;
    }
    else {
        if ($("#subject").val().trim() == "") {
            toastr.info("Please enter subject.");
            return false;
        }
    }

    if ($("#date").val() == "") {
        toastr.info("Please select date.");
        return false;
    }
    else {
        if ($("#subject").val().trim() == "") {
            toastr.info("Please select date.");
            return false;
        }
    }




    model = {
        Id: Id,
        ClientId: ClientId,
        Subject: $("#subject").val(),
        /*Email: $("#Uemail").val(),*/
        DueDate: $("#date").val(),
        /*ZoneId: $("#ZoneId").val(),*/
        Description: $("#description").val(),
        TypeId: "1"
    },
        $.get("/Admin/Admin/CreatecompanyToDo", model, function (data) {
            if (Id == 0) {
                setTimeout(function () { window.location.reload(); }, 1000);
                toastr.success("To-Do items saved successfully.");
            }
            else {
                setTimeout(function () { window.location.reload(); }, 1000);
                toastr.success("To-Do Items updated successfully.");
            }
        });






    //CreatecompanyToDovalidation();
    //if ($("#ComapnyToDoform").valid()) {


    //}
}

function CreatecompanyToDovalidation() {
    $("#ComapnyToDoform").validate({
        rules: {
            subject: {
                required: true,
            },
            Uemail: {
                required: true,
            },
            date: {
                required: true,
            },
            ZoneId: {
                required: true,
            },
            //description: {
            //    required: true,
            //},
        }



    });
}

function MeetingActiveTab(Id) {

    model = {
        Id: Id
    },
        $.get("/Admin/Admin/MeetingActiveTabActiveTab", model, function (Response) {

            $("#dashboardtodo_PopUp").html(Response);

            jQuery.noConflict();
            $("#dashboardtodo_PopUp").modal("show");
        });

}

function companytodounactive(Id) {

    if (companytodounactivevalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.post("/Admin/Admin/companytodounactive", model, function () {
        setTimeout(function () { window.location.reload(); }, 2000);
        toastr.success("To-Do Inactivated successfully.");

    });
}
function companytodounactivevalidation() {
    return confirm(" Do you really want to inactive this To-Do?")
}

function companytodoactive(Id) {
    if (companytodoactivevalidations() == false) {
        return false;
    }
    model =
    {
        Id: Id
    }
    $.post("/Admin/Admin/companytodoactive", model, function () {
        setTimeout(function () { window.location.reload(); }, 2000);
        toastr.success("To-Do Activated successfully.");

    });
}

function companytodoactivevalidations() {
    return confirm("Do you really want to Active this To Do?");
}


function ActiveTab(Id, tabId) {
    url = "/Admin/Admin/clientdetail?Id=" + Id + "&TabId=" + tabId;
    window.location.href = url;
}


function PagerClick(CurrentPageIndex) {

    var Name = $("#Name").val();
    var Zip = $("#zip").val();
    var MileId = $("#MileId").val();
    url = "/Admin/Admin/Company?Name=" + Name + "&Zip=" + Zip + "&MileId=" + MileId + "&CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}


function searchKeyPresss(e, CId) {

    if (e.keyCode === 13) {
        Companytagvalue(CId);
    }
    return true;
}

function Companytagvalue(CId) {

    if ($("#CandidateTag").val().trim() === "") {
        return false;
    }
    model = {
        CId: CId,

        CandidateTag: $("#CandidateTag").val(),
        TagtypeId: 2,
        tagtype_Id:1
    }
    debugger; // ++
    $.get("/Admin/Candidate/Candidatetagvalue", model, function (data) { 
        toastr.success("Company tags saved successfully.");
        setTimeout(function () { location.reload() }, 600);
    });

}

function deletecandidatetag(Id) {
    if (deletecandidatetagvalidation() == false) {
        return false;
    }
    model = {

        Id: Id,

    }
    $.post("/Admin/Candidate/deletecandidatetag", model, function (data) {
        toastr.success("Company tag deleted successfully.");
        setTimeout(function () { location.reload() }, 600);

    });
}

function deletecandidatetagvalidation() {
    return confirm("Are you sure you want to delete this tag?");
}


function LeadStatusPopup(tId, id) {

    var CId = '';
    $.each($("input[name='contactId']:checked"), function () {
        CId = CId + $(this).val() + ',';
    });
    if (CId === '') {
        toastr.info("You must select at least one!");
        return false;
    }
    else {

        $("#h_tId").val(tId);
        $("#H_ContactIs").val(CId);
        $("#LeadStatus").val(id);
        $("#pipelinestatis_Popup").modal("show");
    }
}


function checkcontactphone() {
    $('#lblemailphone').text('');

}

function checkcontactemail() {
      $('#lblemailphone').text('');
      

    if ($("#Email").val() == "") {
        $('#lblemail').text('');
        //return false;
    }
    else {
        if ($("#Email").val().trim() == "") {
            $('#lblemail').text('');
        }
        else {

            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if ($("#Email").val().match(mailformat)) {
                $('#lblemail').text('');
                return true;
            }
            else {
                $('#lblemail').text('Please enter a valid email address.');
                return false;
            }
        }
    }
}