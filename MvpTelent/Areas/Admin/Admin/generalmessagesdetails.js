function savesendgeneralmessagebyadmin(Id, ClientId) {

    savesendgeneralmessagebyadminvalidation();
    if ($('#Gmessagechatform').valid()) {
        model = {
            Id: Id,
            ToId: ClientId,
            CandidateId: $("#h_CandidateId").val(),
            Description: $("#massege").val()
        }
        $.post("/Admin/Admin/savesendgeneralmessagebyadmin", model, function (data) {
            var url = "/Admin/Admin/generalmessagesdetails?Ids=" + $("#GMId").val();
            toastr.success("Messages sent  successfully.");
            setTimeout(function () { window.location.href = url; }, 300);
        });
    }
}
function savesendgeneralmessagebyadminvalidation() {
    $("#Gmessagechatform").validate({
        rules: {
            massege: {
                required: true
            },
        }
    });
}
//function msgsent(event) {
//    var keycode = (event.keyCode ? event.keyCode : event.which);
//    if (keycode == '13') {
//        savesendgeneralmessagebyadmin(@Model.Id, @Model.ClientId);
//    }
//}
function confidentialprofile(Id) {

    var url = "/Admin/Candidate/confidentialprofile?Ids=" + Id;
    window.open(url);
}

function clientdetail(Ids) {
    debugger;
    //var url = "/Admin/Admin/clientdetail?Ids=" + Ids;
    //window.open(url);

}