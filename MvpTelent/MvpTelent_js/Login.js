

function UserAccountType(Id) {

    UserAccountTypeId = Id;
}

function CandidateLogin() { 
    CandidateLoginvalidation();
    if ($("#loginform").valid()) {

        if ($('#KeepLogIn:checked').val() == "on") {
            KeepLogIn = 1;
        }
        else { KeepLogIn = 0; }
        $("#Clientlogin").prop('disabled', true);
        model = {
            Email: $("#username").val().trim(),
            Password: $("#password").val().trim(),
            KeepLogIn: KeepLogIn
        };

        $.get("/Home/CandidateLogin", model, function (data) {
            if (data.Status == 1) {

                if (data.UsertypeId == 1) {
                    url = "/Admin/Admin/Index";
                    toastr.success("Login successful.");
                    setTimeout(function () { window.location.href = url; }, 300);
                }
                else if (data.UsertypeId == 2) {
                    url = "/Client/dashboard";
                    toastr.success("Login successful.");
                    setTimeout(function () { window.location.href = url; }, 300);
                }
                else if (data.UsertypeId == 3) {
                    url = "/Candidates/myprofile";
                    toastr.success("Login successful.");
                    setTimeout(function () { window.location.href = url; }, 300);
                }
            }
            else if (data.Status === 4) {
                toastr.error("Password Incorrect.");
            }
            else if (data.Status === 9) {
                toastr.warning("Your account has been deactivated");
            }
            else if (data.Status === 0) {
                toastr.warning("Please confirm your account from email");
            }
            else if (data.Status === 5) {
                toastr.warning("Email doesn't exist/ try another email.");
            }

            $("#Clientlogin").prop('disabled', false);
        });
    }
}
function CandidateLoginvalidation() {
    $("#loginform").validate({
        rules: {
            username: {
                required: true,
                email: true
            },
            password: {
                required: true
            },

        }
    });
}

function ForgotPasswordEmail() {

    ForgotPasswordvalidation();
    if ($("#Forgotpasswordform").valid()) {
        model = {
            Email: $("#username").val().trim(),
        },
        $("#btn").text('Processing...');
        $("#btn").attr('disable', true);

        $.get("/Home/ForgotPasswordEmail", model, function (data) {
            if (data.Status === 1) {
                toastr.success("We've sent a message to your email address. Please click the link in the message to reset your password.");
                url = "/Home/Login";
                setTimeout(function () { window.location.href = url }, 2200);
            }
            else if (data.Status === 2) {
                toastr.warning("Please check your email, To account confirm.");
                url = "/Home/ForgotPassword";
                setTimeout(function () { window.location.href = url }, 1000);
            } else {
                toastr.info("Enter your registered email.");
                url = "/Home/ForgotPassword";
                setTimeout(function () { window.location.href = url }, 1000);
            }
        });
    };
}
function ForgotPasswordvalidation() {
    $("#Forgotpasswordform").validate({
        rules: {
            username: {
                required: true,
                email: true
            }
        }
    });
}
function ChangePasswordEmail(Id) {

    ChangePasswordEmailvalidation();
    if ($("#ChangePasswordform").valid()) {
        model = {
            Id: Id,
            oldpassword: $("#oldpassword").val(),
            newpassword: $("#newpassword").val(),
        },
            $.get("/Home/ChangePasswordEmail", model, function (data) {

                if (data.Status === 1) {
                    toastr.success("Password updated successfully.");
                    setTimeout(function () { window.location.reload(); }, 400);
                }
                else if (data.Status === 2) {
                    toastr.warning("Old password not match.");
                }
            });
    }
}

function ChangePasswordEmailvalidation() {
    $("#ChangePasswordform").validate({
        rules: {
            oldpassword: {
                required: true
            },
            newpassword: {
                required: true
            },
            confirmpassword: {
                required: true,
                equalTo: "#newpassword"
            }
        }
    });
}
function updateforgotPassword(Id) {

    updateprofilevalidation();
    if ($("#UpadtePasswordform").valid()) {
        model = {
            Id: Id,
            Password: $("#password").val()
        },
            $.post("/Home/updateforgotPassword", model, function () {
                url = "/Home/Login";
                toastr.success("Password Update Successfully.");
                setTimeout(function () { window.location.href = url; }, 500);
            });
    }
}
function updateprofilevalidation() {
    $("#UpadtePasswordform").validate({
        rules: {
            password: {
                required: true,
            },
            Cpassword: {
                required: true,
                equalTo: "#password"
            },
        }
    });
}
function Logout() {

    $.get("/Home/Logout", function (data) {
        Url = '/Home/Login';
        setTimeout(function () { window.location.href = Url }, 600);
    })
}
function CreateCandidates() {
 
    CreateCandidatevalidation();
    if ($("#Candidateform").valid()) {
        model = {
            Name: $("#UName").val(),
            Email: $("#UEmail").val(),
            LastName: $("#ULastName").val(),
            Phone: $("#Phoneno").val(),
            Password: $("#Password").val(),
            AccountType: '3',
        },
            $("#signup").text('Processing...');
        $("#signup").attr("disabled", true);

        $.get("/home/CreateCandidate", model, function (data) {

            if (data.Status == 2) {
                url = "/home/login";
                setTimeout(function () { window.location.href = url }, 2000);
                toastr.success("Registration Completed Successfully! Please check your registered email.");
            }
            else {
                toastr.error("This email already exists .");
            }
            $("#signup").text('Create Account');
            $("#signup").attr("disabled", false);
        });
    }
}


function CreateCandidatevalidation() {
    $("#Candidateform").validate({
        rules: {
            UName: {
                required: true,
            },

            Password: {
                required: true,
            },
            CPassword: {
                required: true,
                equalTo: "#Password"
            },
            UEmail: {
                required: true,
                email: true
            },
            CheckboxID: {
                required:true
            }
        }
    });
}







function CreateClient() {


    CreateClientvalidation();
    if ($("#Clientform").valid()) {
        model = {
            Name: $("#CName").val(),
            Email: $("#CEmail").val(),
            LastName: $("#CLastName").val(),
            Phone: $("#CPhoneno").val(),
            Password: $("#ClientPassword").val(),
            AccountType: '2',
            Company: $("#Company").val(),
        },
        $("#Clientsignup").text('Processing...');
        $("#Clientsignup").attr("disabled", true);

        $.get("/home/CreateCandidate", model, function (data) {
            if (data.Status == 2) {
                url = "/home/login";
                setTimeout(function () { window.location.href = url }, 2000);
                toastr.success("Registration Completed Successfully! Please check your registered email.");
            }
            else {
                toastr.error("This email already exists .");
            }
            $("#Clientsignup").text('Create Account');
            $("#Clientsignup").attr("disabled", false);
        });
    }
}
function CreateClientvalidation() {
    $("#Clientform").validate({
        rules: {
            Company: {
                required: true,
            },
            CName: {
                required: true,
            },
           
            ClientPassword: {
                required: true,
            },
            ConfrimPassword: {
                required: true,
                equalTo: "#ClientPassword"
            },
            CEmail: {
                required: true,
                email: true
            },
            CheckboxID: {
                required:true
            }
        }
    });
}
function viewmyprofile(Id) {
  
    model = {
        Id: Id,
    },
        $.get("/home/GetId", model, function (data) {
            var Url = "/Home/details?Id=" + data;
            window.location.href = Url;
        });
}
function clientslogo(Id) {
    if (window.FormData !== undefined) {
        var fileUpload = $("#clientlogo").get(0);
        var files = fileUpload.files;
        var fileData = new FormData();
        var fileName = '';
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
            fileName += files[i].name;
            var fileExtension = fileName.substring(fileName.lastIndexOf('.') + 1, fileName.length) || fileName;

            if (fileExtension.toLowerCase() !== "jpg" && fileExtension.toLowerCase() != "png") {
                toastr.warning("Upload only (.jpf,.png) file.");
                return false;
            }
        }
        fileData.append('Id', Id);
        fileData.append('clientLogo', fileName);
        $.ajax({
            url: "/Client/Clientlogoupdate",
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (data) {
                toastr.success("Image Updated successfully.");
                setTimeout(function () { window.location.reload() }, 800);
            }
        });
    }
}



function NewletterCreate() {
    NewletterCreatevalidation();
    if ($("#newletterform").valid()) {
        model = {
            Name: $("#name").val(),
            Email: $("#email").val()
        }
        $.post("/Home/NewletterCreate", model, function () {
            toastr.success("Thank you for subscribing.");
            setTimeout(function () { window.location.reload() }, 800);
        });

    }
}

function NewletterCreatevalidation() {
    $("#newletterform").validate({
        rules: {
            name: {
                required: true,
            },

            email: {
                required: true,
                email: true
            },
        }
    });
}

function howitwork() {

    $.get("/Home/Howitwork", function (response) {

        $("#HowItworkpopup").html(response);
        $("#HowItworkpopup").modal("show");

    });
}
















////////////////////////////////////////

