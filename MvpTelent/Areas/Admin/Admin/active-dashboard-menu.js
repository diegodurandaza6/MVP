var url = window.location.pathname;
 
if (url.indexOf('/Admin/Admin/index') > -1) {  
    document.getElementById('DashBoard').className = 'nav-item active';
}



if (url.indexOf('/Admin/Admin/Company') > -1) {
    document.getElementById('2').className = 'nav-item active';
    document.getElementById('collapse1').className = 'collapse show';
}


if (url.indexOf('/Admin/Admin/Users') > -1) {
    document.getElementById('11').className = 'collapse show';
    document.getElementById('11').className = 'nav-item active';
   
}



if (url.indexOf('/Admin/Admin/Pipeline') > -1) {
    
    document.getElementById('Lead Pipeline').className = 'nav-item active';
    document.getElementById('collapse1').className = 'collapse show';
}


if (url.indexOf('/Admin/Admin/Alert') > -1) {

    document.getElementById('Alert').className = 'nav-item active';
    document.getElementById('collapse1').className = 'collapse show';
}





if (url.indexOf('/admin/candidate/group') > -1) {
  
    document.getElementById('Group').className = 'nav-item active';
    document.getElementById('collapse1').className = 'collapse show';
}
 
if (url.indexOf('/Admin/Admin/email') > -1) {
   
    document.getElementById('Email Template').className = 'nav-item active';
    document.getElementById('collapse1').className = 'collapse show';
}

if (url.indexOf('/Admin/Candidate/CandidateList') > -1) {
   
    document.getElementById('CadidateList').className = 'nav-item active';
    document.getElementById('collapse2').className = 'collapse show';
}
if (url.indexOf('/Admin/Candidate/applicant') > -1) {
    document.getElementById('applicantlist').className = 'nav-item active';
    document.getElementById('collapse2').className = 'collapse show';
}

if (url.indexOf('/Admin/Admin/InterviewSceduleList') > -1) {
    document.getElementById('InterviewScedule_List').className = 'nav-item active';
}

if (url.indexOf('/Admin/Admin/Campaign') > -1) {
    document.getElementById('campaignlist').className = 'nav-item active';
    document.getElementById('collapse33').className = 'collapse show';
}

if (url.indexOf('/Admin/Admin/campaignhistory') > -1) {
    document.getElementById('campaignhistorylist').className = 'nav-item active';
    document.getElementById('collapse33').className = 'collapse show';
}




if (url.indexOf('/Admin/Admin/enquires') > -1) {
    document.getElementById('enquireslist').className = 'nav-item active';
    document.getElementById('collapse3').className = 'collapse show';
}

if (url.indexOf('/Admin/Admin/ClientSendenquery') > -1) {
    document.getElementById('ClientSendenquery').className = 'nav-item active';
    document.getElementById('collapse3').className = 'collapse show';
}
 
if (url.indexOf('/Admin/Admin/sharedJob') > -1) {
    document.getElementById('sharedJoblist').className = 'nav-item active';
    document.getElementById('collapse9').className = 'collapse show';
}


if (url.indexOf('/Admin/Admin/SubmissionProfile') > -1) {
    document.getElementById('SubmissionProfilelist').className = 'nav-item active';
    document.getElementById('collapse9').className = 'collapse show';
}
if (url.indexOf('/Admin/Admin/JobLists') > -1) {
    document.getElementById('joblist').className = 'nav-item active'; 
}


if (url.indexOf('/Admin/Candidate/Plan') > -1) {
    document.getElementById('planlist').className = 'nav-item active';
}




