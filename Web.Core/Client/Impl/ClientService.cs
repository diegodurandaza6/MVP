
using System.Data;
using Web.Dal.Client;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Core.Client.Impl
{
    public class ClientService : IClient
    {
        ClientFactory _ClientFactory = new ClientFactory();
        ClientDel _ClientDel = new ClientDel();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public void AddSkills(JobsModel model)
        {
            dt = _ClientDel.AddSkills(model);
            _ClientFactory.AddSkills(model, dt);
        }
        public void deleteskill(JobsModel model)
        {
            dt = _ClientDel.deleteskill(model);
            _ClientFactory.AddSkills(model, dt);
        }
        public void candidateshortlist(ClientModel model)
        {
            _ClientDel.candidateshortlist(model);
        }

        public void ClientenquireyList(ClientModel model)
        {
            dt = _ClientDel.ClientenquireyList(model);
            _ClientFactory.ClientenquireyList(model, dt);
        }

        public void Clientlogoupdate(ClientModel model)
        {
            _ClientDel.Clientlogoupdate(model);
        }

        public void ClientProfileupdate(ClientModel model)
        {
            _ClientDel.ClientProfileupdate(model);
        }

        public void ClientSendenquery(ClientModel model)
        {
            dt = _ClientDel.ClientSendenquery(model);
            _ClientFactory.ClientSendenquery(model, dt);
        }

        public void CompanyProfile(ClientModel model)
        {
            ds = _ClientDel.CompanyProfile(model);
            _ClientFactory.CompanyProfile(model, ds);
        }

        public void CreateJobs(JobsModel model)
        {
            _ClientDel.CreateJobs(model);
        }
        public void Admin_CreateJobs(JobsModel model)
        {
            _ClientDel.Admin_CreateJobs(model);
        }

        public void enquireydetails(ClientModel model)
        {
            ds = _ClientDel.enquireydetails(model);
            _ClientFactory.enquireydetails(model, ds);
        }

        public void interviewsrequestbycandidatesdetail(ClientModel model)
        {
            ds = _ClientDel.interviewsrequestbycandidatesdetail(model);
            _ClientFactory.interviewsrequestbycandidatesdetail(model, ds);
        }


        public void favoritecandidate(ClientModel model)
        {
            ds = _ClientDel.favoritecandidate(model);
            _ClientFactory.favoritecandidate(model, ds);
        }
        public void AddTofavoritecandidate(ClientModel model)
        {
            dt = _ClientDel.AddTofavoritecandidate(model);
            _ClientFactory.AddTofavoritecandidate(model, dt);
        }
        public void JobDetail(JobsModel model)
        {
            ds = _ClientDel.JobDetail(model);
            _ClientFactory.JobDetail(model, ds);
        }
        public void JobDetailById(JobsModel model)
        {
            ds = _ClientDel.JobDetailById(model);
            _ClientFactory.JobDetailById(model, ds);
        }
        public void JobDetailDeletebyId(JobsModel model)
        {
            _ClientDel.JobDetailDeletebyId(model);
        }

        public void JobList(JobsModel model)
        {
            ds = _ClientDel.JobList(model);
            _ClientFactory.JobList(model, ds);
        }

        public void Jobs(JobsModel model)
        {
            ds = _ClientDel.Jobs(model);
            _ClientFactory.Jobs(model, ds);
        }

        public void myfavourite(CandidateModel model)
        {
            ds = _ClientDel.myfavourite(model);
            _ClientFactory.myfavourite(model, ds);
        }

        public void sendClientconversationsaved(ClientModel model)
        {
            _ClientDel.sendClientconversationsaved(model);
            _ClientFactory.sendClientconversationsaved(model);


        }

        public void sendconversationsaved(ClientModel model)
        {
            dt = _ClientDel.sendconversationsaved(model);
            _ClientFactory.sendconversationsaved(model, dt);
        }

        public void sendconversationsavedpopup(ClientModel model)
        {
            dt = _ClientDel.sendconversationsavedpopup(model);
            _ClientFactory.sendconversationsavedpopup(model, dt);
        }

        public void ShortList(ClientModel model)
        {
            dt = _ClientDel.shortlist(model);
            _ClientFactory.shortlist(model, dt);
        }

        public void skillautocomplete(CandidateModel model)
        {
            dt = _ClientDel.skillautocomplete(model);
            _ClientFactory.skillautocomplete(model, dt);
        }

        public void StateList(ClientModel model)
        {
            dt = _ClientDel.StateList(model);
            _ClientFactory.StateList(model, dt);
        }

        public void Applicant(CandidateModel model)
        {
            ds = _ClientDel.Applicant(model);
            _ClientFactory.Applicant(model, ds);
        }

        public void dashboard(ClientModel model)
        {
            ds = _ClientDel.dashboard(model);
            _ClientFactory.dashboard(model, ds);
        }

        public void viewCandidate(ClientModel model)
        {
            _ClientDel.viewCandidate(model);
        }

        public void SharedJobCount(JobsModel model)
        {
            dt = _ClientDel.SharedJobCount(model);
            _ClientFactory.SharedJobCount(model, dt);
        }

        public void Tagsautocomplete(CandidateModel model)
        {
            dt = _ClientDel.Tagsautocomplete(model);
            _ClientFactory.Tagsautocomplete(model, dt);
        }

        public void AddTags(JobsModel model)
        {
            dt = _ClientDel.AddTags(model);
            _ClientFactory.AddTags(model, dt);
        }

        public void deleteJobtags(JobsModel model)
        {
            dt = _ClientDel.deleteJobtags(model);
            _ClientFactory.AddTags(model, dt);
        }

        public void mycandidate(CandidateModel model)
        {
            dt = _ClientDel.mycandidate(model);
            _ClientFactory.mycandidate(model, dt);
        }

        public void clientNotesave(CandidateModel model)
        {
            _ClientDel.clientNotesave(model);
        }

        public void clientNotesDelete(CandidateModel model)
        {
            _ClientDel.clientNotesDelete(model);
        }

        public void Clientnotepopup(CandidateModel model)
        {
            dt = _ClientDel.Clientnotepopup(model);
            _ClientFactory.Clientnotepopup(model, dt);
        }

        public void conversation(Candidateconversationmodel model)
        {
            ds = _ClientDel.conversation(model);
            _ClientFactory.conversation(model, ds);
        }

        public void Candidateconversationsaved(Candidateconversationmodel model)
        {
            _ClientDel.Candidateconversationsaved(model);
        }

        public void messages(ClientModel model)
        {
            dt = _ClientDel.messages(model);
            _ClientFactory.messages(model, dt);
        }

        public void sendgeneralmessages(ClientModel model)
        {
            _ClientDel.sendgeneralmessages(model);
        }

        public void messagesdetails(ClientModel model)
        {
            ds = _ClientDel.messagesdetails(model);
            _ClientFactory.messagesdetails(model, ds);
        }

        public void savesendgeneralmessage(ClientModel model)
        {
            _ClientDel.savesendgeneralmessage(model);
        }
        public void ClientNameAutoComplete(CandidateModel model)
        {
            dt = _ClientDel.ClientNameAutoComplete(model);
            _ClientFactory.ClientNameAutoComplete(model, dt);
        }

        public void CandidateNameAutoComplete(CandidateModel model)
        {
            dt = _ClientDel.CandidateNameAutoComplete(model);
            _ClientFactory.CandidateNameAutoComplete(model, dt);
        }

        public void ClientCandidateNameAutoComplete(CandidateModel model)
        {
            dt = _ClientDel.ClientCandidateNameAutoComplete(model);
            _ClientFactory.ClientNameAutoComplete(model, dt);
        }

        public void Pipelinemessageslist(ClientModel model)
        {
            dt = _ClientDel.Pipelinemessageslist(model);
            _ClientFactory.Pipelinemessageslist(model, dt);
        }
        
        public void GetSubJobByJId(JobsModel model)
        {
            dt = _ClientDel.GetSubJobByJId(model);
            _ClientFactory.GetSubJobByJId(model, dt);
        }

        public void GetjobByCompanyIdId(JobsModel model)
        {
            dt = _ClientDel.GetjobByCompanyIdId(model);
            _ClientFactory.GetjobByCompanyIdId(model, dt);
        }



        public void ResendActivationEmail(ClientModel model)
        {
            dt = _ClientDel.ResendActivationEmail(model);
            _ClientFactory.ResendActivationEmail(model,dt);
        }

        public void getCandidateTitleList(CandidateModel model)
        {
            ds = _ClientDel.getCandidateTitleList(model);
            _ClientFactory.getCandidateTitleList(model, ds);

        }

        public void getFavoriteCandidateTitleList(CandidateModel model)
        {
            ds = _ClientDel.getFavoriteCandidateTitleList(model);
            _ClientFactory.getCandidateTitleList(model, ds);

        }


        public void jobtitleautocomplate(CandidateModel model)
        {
            dt = _ClientDel.jobtitleautocomplate(model);
            _ClientFactory.jobtitleautocomplate(model, dt);
        }
    }
}
