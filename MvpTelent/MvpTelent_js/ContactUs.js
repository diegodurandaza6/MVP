

function CreateContactUs()
{ 
    CreateContactUsvalidation();
    debugger;
    if ($("#contactinqueryfrom").valid()) {
        model = {
            Name: $("#UName").val(),
            LastName: $("#LName").val(),
            Email: $("#Email").val(),
            Phone: $("#Phone").val(),
            SubJect: $("#Subject").val(),
            Message: $("#Message").val(),
            typeId: 2
        } 
        $("#btncontact").text('Processing...');
   
        $("#btncontact").attr('disable', true);
   
        $.post("/Home/CreateContactUs", model, function (data) {
         
                toastr.success("Your query sent successfully.");
                 var url = "/Home/contact";
                setTimeout(function () { window.location.href = url; }, 800);
           
            
        });
    };
}

function CreateContactUsvalidation()
{
    $("#contactinqueryfrom").validate({
        rules: {
            UName: {
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
            Subject: {
                required: true,

            },
            Message: {
                required: true,

            }
        }



    });
}

function CreatePatnership()
{
    CreatePatnershipvalidation();
    if ($("#contactpatrnershipform").valid()) {
        model = {
            Name: $("#UName").val(),
            Email: $("#Email").val(),
            Phone: $("#Phone").val(),
            SubJect: $("#Subject").val(),
            Message: $("#Message").val(),
            typeId: 1
        }
        $("#btncontact").text('Processing...');
     
        $("#btncontact").attr('disable', true);
     
        $.get("/Home/CreateContactUs", model, function (data) {
            toastr.success("Your query sent successfully.");
            var url = "/Home/partnership"
            setTimeout(function () { window.location.href = url; }, 800);
        });
    };
}


function CreatePatnershipvalidation() {
    $("#contactpatrnershipform").validate({
        rules: {
            UName: {
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
            Subject: {
                required: true,

            },
            Message: {
                required: true,

            },
            contactCheck: {
                required: true,
            }

        }



    });
}