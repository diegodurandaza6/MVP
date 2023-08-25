


function candidateconversation(CandidateId) {
    url = "/Client/conversation?CId=" + CandidateId + "&jId=" + $("#JobId").val();
    window.location.href = url;
}


function Candidateconversationsaved(CandidateId,JobId) {
     
    Candidateconversationsavedvalidation();
    if ($('#candidateConverform').valid()) {
        model = {
            CId: CandidateId,
             jId :JobId,           
            Description: $("#massege").val()
        }

        $.post("/Home/Candidateconversationsaved", model, function () {
            var url = "/Client/conversation?CId=" + $("#messageid").val() + "&jId=" + JobId;            
            window.location.href = url;
           
            setTimeout(function () { window.location.href = url }, 1800);
            toastr.success("Message sent successfully.");
        });
    }
}

function Candidateconversationsavedvalidation() {
    $("#candidateConverform").validate({
        rules: {
            massege: {
                required: true
            },

        }
    });
}
