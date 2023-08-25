

function Createassignpay(Id)
{
     
    if ($("#PayClientId").val() == 0) {
        toastr.error("Search Email.");
    }
    else {
    Createassignvalidation();
    if ($("#clientpayform").valid()){
        model = {
            Id: Id,
          
            Number: $("#Number").val(),
            DueDate: $("#CDate").val(),
            Amount: $("#Amount").val(),
            Point: $("#point").val(),
        }
        $.get("/Admin/Admin/Createassignpay", model, function (data) {
         
            toastr.success("Payment Success.");
                setTimeout(function () { location.reload(true); }, 1000);
        


        });
    }
    }
}

function Createassignvalidation() {
    $("#clientpayform").validate({
        rules: {
            Number: {
                required: true,
                
            },
            CDate: {
                required: true,
                
            },
            Amount: {
                required: true,
                number: true
            },
            point: {
                required: true,
                
            }
        }
    });
}


function getassignByEmail()
{
    debugger
    getassignByvalidation();
    if ($("#assignEmailform").valid()) {
        var Email = $("#Email").val();
        var url = "/Admin/Admin/Assign?Email=" + Email;
        window.location.href = url;
    }

}

function getassignByvalidation()
{
    $("#assignEmailform").validate({
        rules: {
            Email: {
                required: true,
                email: true
            }
        }
    });
}

function ResetEmail() {
    var url = "/Admin/Admin/Assign";
    window.location.href = url;
}