function Buy(typeid, UsertypeId, Id) {
     
    JobapplyLogin(typeid, Id);
    //if (UsertypeId == 0) {
    //    JobapplyLogin(Id);
    //}
    //else {
    //    if (UsertypeId == 3) {
    //        if (typeid == 3) {
    //            var url = "/Candidates/payment?PlanId=" + Id;
    //            window.location.href = url;
    //        }
    //        // go to client 
    //    }
    //    else if (UsertypeId == 2) {
    //        // go to Candidate
    //        if (typeid == 2) {
    //            var url = "/Client/payment?PlanId=" + Id;
    //            window.location.href = url;
    //        }
    //    }
    //    else {
    //        toastr.info("You are not authorized to access this feature.");
    //    }
    //}
}
function JobapplyLogin(typeid, Id) {
     
    model = {
        Ids: Id,
        usertype: typeid
    };
    $.get("/Home/PlanLogin", model, function (response) {
        $("#login_popup").html(response);
        $("#login_popup").modal("show");
    });
}
 
function userlogin(PId, UserAccountType) {
    
    CandidateLoginsvalidation();
    if ($("#ApplyJobform").valid()) {
        model = {
            UsertypeId: UserAccountType,
            Email: $("#username").val().trim(),
            Password: $("#password").val().trim(),
        };
        $.get("/Home/CandidateLogin", model, function (data) { 
            if (data.Status == 1) {
                if (data.UsertypeId == 1) {
                    toastr.info("You are not authorized to access this feature.");
                }
                else {
                    $("#login_popup").modal("hide"); 
                    toastr.success("Login successful."); 
                    var url = "/Home/payment?pid=" + PId;
                     setTimeout(function () { location.reload()}, 1000);  
                                   
                    /*setTimeout(function () { window.open(url, "", "width:80%,height:80%") }, 300);*/
                    setTimeout(function () { window.open(url) }, 300);
                }
            }
            else {
                toastr.error("Invalid email address or password.");
            }
        });
    }
}
function CandidateLoginsvalidation() {
    $("#ApplyJobform").validate({
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