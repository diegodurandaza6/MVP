function closegm() {
    url = "/Admin/Admin/generalmessages";
    window.location.href = url;
}
$.post("/Home/ClientCandidateNameAutoComplete", function (response) {

    $("#name").autocomplete({
        source: response,
        select: function (event, ui) {
            var e = ui.item;

            $("#h_ClientId").val(e.id)
        }
    });
});
$.post("/Home/ClientNameAutoComplete", function (response) {

    $("#Clientname").autocomplete({
        source: response,
        select: function (event, ui) {
            var e = ui.item;
            $("#h_ClientId").val(e.id)
            $("#Candidatename").prop('disabled', true);
        }
    });
});
$.post("/Home/CandidateNameAutoComplete", function (response) {

    $("#Candidatename").autocomplete({
        source: response,
        select: function (event, ui) {
            var e = ui.item;
            $("#h_candidateId").val(e.id)
            $("#Clientname").prop('disabled', true);
        }
    });
});
function PagerClick(CurrentPageIndex) {
    url = "/Client/ClientenquireyList?CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}