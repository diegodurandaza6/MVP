function getcampainByName() {
    var Name = $("#_Name").val();
    url = "/Admin/Admin/NewLetter?Name=" + Name;
    window.location.href = url;
}
function NewLettterReset() {
    url = "/Admin/Admin/NewLetter";
    window.location.href = url;
}
function DeleteNewletter(Id) {
    if (DeleteNewlettervalidation() == false) {
        return false;
    }
    model = {
        Id: Id
    }
    $.post("/Admin/Admin/DeleteNewletter", model, function () {
        toastr.success("Subscription deleted successfully.");
        setTimeout(function () { window.location.reload(); }, 2000);
    });
}
function DeleteNewlettervalidation() {
    return confirm("Do you really want to delete this subscription?");
}