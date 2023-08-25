
function AdminUsermanage(Id) {
    AdminUservalidation();
    if ($("#adminuserform").valid()) {
        model = {
            Id: Id,
            FirstName: $("#Fname").val(),
            LastName: $("#Lname").val(),
            Email: $("#Email").val(),
            Phoneno: $("#Phoneno").val(),
            RoleId: $("#RoleId").val(),
            Password: $("#Password").val(),
            AccounttypeId: 4
        },
         $("#createUser").text('Processing...');
        $("#createUser").attr("disabled", true); 
        $.get("/Admin/Admin/AdminUsermanage", model, function (data) { 
            if (data.StatusId == 2) {
                url = "/Admin/Admin/UserList";
                setTimeout(function () { window.location.href = url }, 2000);
                toastr.success("User created successfully.");
            }
            else if (data.StatusId == 1) {
                toastr.warning("This email already exist.");
            }
            else {
                url = "/Admin/Admin/UserList";
                setTimeout(function () { window.location.href = url }, 2000);
                toastr.success("User updated successfully.");
            }
        });
    }
}


function AdminUservalidation() {
    $("#adminuserform").validate({
        rules: {
            Fname: {
                required: true,
            },
            //Lname: {
            //    required: true,
            //},
            Phoneno: {
                required: true,
                /*  number: true*/
            },
            Email: {
                required: true,
                email: true
            },
            RoleId: {
                required: true,
            },
            Password: {
                required: true,
            },
            cPassword: {
                required: true,
                equalTo: "#Password"
            }
        }


    });
}

function edituserlist(Id) {

    url = "/Admin/Admin/Users?Ids=" + Id;
    window.location.href = url;
}

function deleteUsers(Id) {
    if (deleteUserListvalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    },
        $.get("/Admin/Admin/deleteUsers", model, function (data) {
            toastr.success("User Deleted Successfully.");
            setTimeout(function () { window.location.reload() }, 800);
        });
}

function deleteUserListvalidation() {
    return confirm("Do you really want to delete this user?");
}

function Close() {
    url = "/Admin/Admin/UserList";
    window.location.href = url;
}