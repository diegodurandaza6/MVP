
var url = window.location.pathname;
 
if (url.indexOf('/Client/Index') > -1) {
    document.getElementById('dashboardid').className = 'nav-link active';
}

if (url.indexOf('/Client/CompanyProfile') > -1) {
    document.getElementById('comapnieprofileId').className = 'nav-link active';
}

if (url.indexOf('/Client/applicant') > -1) {
    document.getElementById('applicantsId').className = 'nav-link active';
}

if (url.indexOf('/Client/interviewschedulelist') > -1) {
    document.getElementById('interviewId').className = 'nav-link active';
}

if (url.indexOf('/Client/paymenthistory') > -1) {
    document.getElementById('paymenthistoryId').className = 'nav-link active';
}

if (url.indexOf('/Client/ClientenquireyList') > -1) {
    document.getElementById('sentitemId').className = 'nav-link active';
}

if (url.indexOf('/Client/ChangePassword') > -1) {
    document.getElementById('passwordId').className = 'nav-link active';
}

if (url.indexOf('/Home/candidatelist') > -1) {

    document.getElementById('searchcandidateId').className = 'nav-link active';
    document.getElementById('collapseOne').className = 'collapse show';
}

if (url.indexOf('/client/myfavorite') > -1) {

    document.getElementById('favoriteId').className = 'nav-link active';
    document.getElementById('collapseOne').className = 'collapse show';
}

if (url.indexOf('/Client/Jobs') > -1) {

    document.getElementById('postId').className = 'nav-link active';
    document.getElementById('jobs').className = 'collapse show';
}

if (url.indexOf('/Client/JobList') > -1) {

    document.getElementById('myjobsId').className = 'nav-link active';
    document.getElementById('jobs').className = 'collapse show';
}


