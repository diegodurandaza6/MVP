using System.Data;
using Web.Model.Admin;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;

namespace Web.Core.Candidate
{
    public interface ICandidate
    {
        void CreateCandidate(CandidateModel model);
        void CadidateList(CandidateModel model);
        void Candidates(CandidateModel model);
        void CandidateDelete(CandidateModel model);
        void CandidateDetail(CandidateModel model);
        void candidateprofilepopup(CandidateModel model);
        void UpdateCandidate(CandidateModel model);
        void candidatedetailbyId(CandidateModel model);
        void CandidateVediopopu(CandidateModel model);
        void createeducationcandidate(CandidateModel model);
        void Dashboard(CandidateModel model);
        void StateList(CandidateModel model);

        void CityList(CandidateModel model);
        void GetAllCandidateList(CandidateListModel model);
        void ResumeImageUpload(CandidateModel model);
        void ProfileImageUpload(CandidateModel model);

        void CandidateEducationpopup(CandidateModel model);
        void CandidateEducationDelete(CandidateModel model);
        void createworkexperiencecandidate(CandidateModel model);
        void Candidateworkexperiencepopup(CandidateModel model);
        void CandidateworkexperienceDelete(CandidateModel model);
        void createawardscandidate(CandidateModel model);
        void CandidateAwardspopup(CandidateModel model);
        void getAllPaymentHistory(PlansListModel model);
        void CandidateawardsDelete(CandidateModel model);
        void Candidateportfoliosave(CandidateModel model);

        void AddUpdateSkillsPopup(CandidateModel model);
        void SkillAddUpdate(CandidateModel model);
        void Deleteskill(CandidateModel model);
        void CandidateResumeUpload(CandidateModel model);
        void SaveTransaction(PlansViewModel model);
        void UploadVideo(CandidateModel model);
        void CandidateportfolioDelete(CandidateModel model);
        void Candidateportfoliopopup(CandidateModel model);
        void Candididaterefencessave(CandidateModel model);
        void Candidaterefrencespopup(CandidateModel model);
        void candidaterefrenceDelete(CandidateModel model);
        void Candidateskillsvaluesave(CandidateModel model);
        void AutoCompleteSkills(CandidateModel model);

        void MyappliedJob(JobsModel model);
        void JobAppliedDeletebyId(JobsModel model);
        void MySavedJobList(JobsModel model);
        void JobSavedDeletebyId(JobsModel model);

        void Applicant(CandidateModel model);
        void ApplicantDelete(CandidateModel model);
        void Interviewstatus(CandidateModel model);
        void interviewStatusPopup(CandidateModel model);
        void interviewscedulelist(ClientModel model);
        void Interviewdetailpopup(ClientModel model);
        void InterViewdelete(ClientModel model);
        void CDetail(CandidateModel model);
        void PlanCreatepopup(PlanModel model);
        void CreatePlan(PlanModel model);
        void Plan(PlanModel model);
        void PlanDelete(PlanModel model);
        void Candidatedefaultimage(CandidateModel model);
        void paymenthistory(PlansListModel model);
        void CandidatesharedJobpopup(CandidateModel model);
        void AddSharedJobcandidatebyId(CandidateModel model);


        void SubmitCandidateProfile(CandidateModel model);

        void UpdateCandidateOnsolr(CandidateModel model);
        void stoppayment(CandidateModel obj);
        void Clientinterviewscedulelist(ClientModel model);
        void getsharedjobbyclientid(CandidateModel model);
        void Candidatetagvalue(Tagsmodel model);
        void AutoCompleteCandidatetags(CandidateModel model);
        void deletecandidatetag(CandidateModel model);
        void InterviewSchedulecalenderlist(ClientModel model);
        void getinterviewschedulelist(ClientModel model);
        void getallunreadmessage(ClientModel model);
        void interviewlistbycandidate(ClientModel model);
        void messageslist(Candidateconversationmodel model);
        void conversation(Candidateconversationmodel model);
        void Candidateconversationsaved(Candidateconversationmodel model);
        void generalmessagelist(Candidateconversationmodel model);
        void generalmessagedetail(Candidateconversationmodel model);
        void generalmessageconversationsaved(Candidateconversationmodel model);
        void sendgeneralmessages(ClientModel model);
        void CandidateNnotification(ClientModel model);
        void AdminNotification(ClientModel model);
        void Error(long id, string error);
        void CandidateDetailsbyId(CandidateModel model);
        void LicensesCertificationspopup(CandidateModel model);
        void addupdatelicensescertification(CandidateModel model);
        void LicensesCertificationsDelete(CandidateModel model);

        void PlanActiveInactive(PlanModel model);
        
        void submitedprofile(Candidateconversationmodel model);
        void submitedprofiledetail(Candidateconversationmodel model);
        void submitedMessageprofile(Candidateconversationmodel model);
        void getallzipcodeinradius(CandidateModel model);
        void refundpayment(CandidateModel obj);
        void Renewpayment(CandidateModel obj);
        void GetJobOnwerDetailById(Candidateconversationmodel model);
        DataTable CoreUpdate();
        void CheckAndInsertZipCode(CandidateModel model);
        DataTable getallFavoritescandidatelistByClient(CandidateListModel model);
    }
}
