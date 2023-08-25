//const { Alert } = require("bootstrap");

function messagesadmin_popup(Id) {
    $.get("/Admin/Admin/messagesadmin_popup", function (response) {
        $("#dv_messagesadmin_popup").html(response);
        $("#dv_messagesadmin_popup").modal("show");
    });
}


 // send message in admin
function sendAdmingeneralmessages() {
  

    sendAdmingeneralmessagesvalidation();
    if ($("#GeneralMessagefrom").valid()) {

        var ToId = 0;

        if ($('#h_candidateId').val() > 0) {
            ToId = $('#h_candidateId').val();
        }
        else {
            ToId = $('#h_ClientId').val();
        }
        
        model = {
            ToId : ToId,
            Title: $('#title').val(),
            Description: $('#Description').val()
        }  
        $.post("/Admin/Admin/sendAdmingeneralmessages", model, function (response) {
            toastr.success("Message sent successfully.");
            setTimeout(function () { window.location.reload(); }, 1200);
        });
       
    }
}

function sendAdmingeneralmessagesvalidation() {
    $("#GeneralMessagefrom").validate({
        rules: {
            Clientname: {
                required: true,
            },
            title: {
                required: true,
            },
            Description: {
                required: true,
            },
           
        }
    });
}




function Getgeneralmessagedetal(Id)
{
    var url = "/Admin/Admin/generalmessagesdetails?Ids=" + Id;
    window.location.href = url;
}

function searchbyclient() {
   /* url = "/Admin/Admin/generalmessages?Id=" + $("#h_ClientId").val();*/
    url = "/Admin/Admin/generalmessages?Name=" + $("#name").val() + "&Id=" + $("#h_ClientId").val()
    window.location.href = url;
}

function PagerClick(CurrentPageIndex) {
    url = "/Admin/Admin/generalmessages?CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}

function getadmingmessagesearch() {
     
    var ClientName = $("#clientById").val();
    var url = "/Admin/Admin/GeneralMessages?cids=" + ClientName;
    window.location.href = url;
}

function resetadmingmessage() {
    var url = "/Admin/Admin/GeneralMessages";
    window.location.href = url;
}

