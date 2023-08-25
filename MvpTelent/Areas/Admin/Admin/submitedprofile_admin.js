function GetadminJobDetailbyId(Id) {
    var url = "/Admin/Admin/JobDetails?Ids=" + Id;
    window.open(url);
}

function GetclientdetailbyId(Id) {
    var url = "/Admin/Admin/clientdetail?Ids=" + Id;
    window.open(url);
}
function detailedprofile(Id) {

    var url = "/Admin/Candidate/CandidateDetail?Ids=" + Id;
    window.open(url);
}
function submitedprofiledetail(Id) {
    var url = "/Admin/Candidate/submitedprofiledetail?Ids=" + Id;
    window.open(url);
}


function searchbyname() {
    var url = "/Admin/Admin/submitedprofile?Name=" + $("#name").val();
    window.location.href = url;
}


function closegm() {
    url = "/Admin/Admin/submitedprofile";
    window.location.href = url;
}


function PagerClick(CurrentPageIndex) {
    url = "/Admin/Admin/submitedprofile?CurrentPageIndex=" + CurrentPageIndex;
    window.location.href = url;
}