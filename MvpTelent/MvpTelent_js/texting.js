

function ClientSendenquery(Id)
{
    ClientSendenqueryvalidation();
    if ($("#sendenquery").valid()) {
        model = {
            Id:Id,
            Name: $("#EName").val(),
            Email: $("#Email").val(),
            Phone: $("#Phone").val(),
            JobPostingUrl: $("#JobPostingUrl").val(),
            Description: $("#Description").val(),
              

        }
        $.get("/Home/ClientSendenquery", model, function (data) {
            //toastr.success("Update client logo successfully.");
            setTimeout(function () { window.location.reload() }, 800);

        });






    }
}

function ClientSendenqueryvalidation()
{
    $("#sendenquery").validate({
        rules: {
            EName: {
                required: true,
              
            },
            Email: {
                required: true,
                 email: true
            },
            Phone: {
                required: true,
                number: true
            },
            JobPostingUrl: {
                required: true
            },
            Description: {
                required: true
            },
        }




    });
}