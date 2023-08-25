
function Details(Id, tabId) {

    url = "/Admin/Admin/clientdetail?Ids=" + Id + "&tid=" + tabId;
    window.open(url);
}
function companylist() {
    url = "/Admin/Admin/Company";
    window.location.href = url;
}
function Candidateslist() {

    url = "/Admin/Candidate/CandidateList";
    window.location.href = url;
}

function SharedJoblist() {

    url = "/Admin/Admin/sharedJob";
    window.location.href = url;
}

function Interviewdetailpopup(Id) {
    model = {
        Id: Id
    }
    $.get("/Admin/Admin/Interviewdetailpopup", model, function (response) {
        $("#Interviewdetail_PopUp").html(response);
        $("#Interviewdetail_PopUp").modal("show");


    });
}


function interviewlist() {

    url = "/Admin/Admin/InterviewSceduleList";
    window.location.href = url;
}

function InterviewsRequestList() {

    url = "/Admin/Admin/ClientSendenquery";
    window.location.href = url;
}

function InterviewsRequestList_Candidate() {

    url = "/Admin/Admin/interviewsrequestbycandidates";
    window.location.href = url;
}



function GeneralMessageslist() {

    url = "/Admin/Admin/generalmessages";
    window.location.href = url;
}



function joblist() {

    url = "/Admin/Admin/JobLists";
    window.location.href = url;
}

function Detailpage() {

    url = "/Admin/Admin/enquires";
    window.location.href = url;
}

function MeetingActiveTab(Id) {
    model = {
        Id: Id
    },
        $.get("/Admin/Admin/MeetingActiveTabActiveTab", model, function (Response) {

            $("#dashboardtodo_PopUp").html(Response);
            $("#dashboardtodo_PopUp").modal("show");
        });
}