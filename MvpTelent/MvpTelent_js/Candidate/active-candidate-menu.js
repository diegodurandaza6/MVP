
var url = window.location.pathname;
 
if (url.indexOf('/Candidates/Dashboard') > -1) {
    document.getElementById('dashboardId').className = 'nav-link active';
}


if (url.indexOf('/Candidates/myProfile') > -1) {
    document.getElementById('myprofileId').className = 'nav-link active';
}

if (url.indexOf('/Home/details') > -1) {
    document.getElementById('mypublicId').className = 'nav-link active';
}

if (url.indexOf('/Candidates/MyappliedJob') > -1) {
    document.getElementById('appliedjobId').className = 'nav-link active';
}

if (url.indexOf('/Candidates/MySavedJobList') > -1) {
    document.getElementById('savejobId').className = 'nav-link active';
}

if (url.indexOf('/Candidates/Setting') > -1) {
    document.getElementById('changepasswordId').className = 'nav-link active';
}

if (url.indexOf('/Candidates/paymenthistory') > -1) {
    document.getElementById('paymentId').className = 'nav-link active';
}

