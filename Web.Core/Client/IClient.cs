using System.Data;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Core.Client
{
    public interface IClient
    {
        void ClientSendenquery(ClientModel model);
        void favoritecandidate(ClientModel model);
        void myfavourite(CandidateModel model);
        void CompanyProfile(ClientModel model);
        void StateList(ClientModel model);
        void ClientProfileupdate(ClientModel model);
        void ClientenquireyList(ClientModel model);
        void enquireydetails(ClientModel model);
        void interviewsrequestbycandidatesdetail(ClientModel model);
        void sendconversationsaved(ClientModel model);
        void sendconversationsavedpopup(ClientModel model);
        void dashboard(ClientModel model);
        void sendClientconversationsaved(ClientModel model);
        void Clientlogoupdate(ClientModel model);
        void candidateshortlist(ClientModel model);
        void skillautocomplete(CandidateModel model);
        void ShortList(ClientModel model);
        void Jobs(JobsModel model);
        void CreateJobs(JobsModel model);

        void Admin_CreateJobs(JobsModel model);
        void JobList(JobsModel model);
        void JobDetail(JobsModel model);
        void JobDetailById(JobsModel model);
        void JobDetailDeletebyId(JobsModel model);
        void AddSkills(JobsModel model);
        void deleteskill(JobsModel model);
        void Applicant(CandidateModel model);
        void viewCandidate(ClientModel model);
        void SharedJobCount(JobsModel model);
        void Tagsautocomplete(CandidateModel model);
        void AddTags(JobsModel model);
        void deleteJobtags(JobsModel model);
        void mycandidate(CandidateModel model);
        void clientNotesave(CandidateModel model);
        void clientNotesDelete(CandidateModel model);
        void Clientnotepopup(CandidateModel model);
        void conversation(Candidateconversationmodel model);
        void Candidateconversationsaved(Candidateconversationmodel model);
        void messages(ClientModel model);
        void sendgeneralmessages(ClientModel model);
        void messagesdetails(ClientModel model);
        void savesendgeneralmessage(ClientModel model);
        void ClientNameAutoComplete(CandidateModel model);

        void ClientCandidateNameAutoComplete(CandidateModel model);

        void CandidateNameAutoComplete(CandidateModel model);
        void Pipelinemessageslist(ClientModel model);
        void GetSubJobByJId(JobsModel model);
        void ResendActivationEmail(ClientModel model);
        void GetjobByCompanyIdId(JobsModel model);
        void AddTofavoritecandidate(ClientModel model);
        void getCandidateTitleList(CandidateModel model);
        void jobtitleautocomplate(CandidateModel model);
        void getFavoriteCandidateTitleList(CandidateModel model);
    }
}
