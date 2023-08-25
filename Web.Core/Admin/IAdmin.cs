using Web.Model.Admin;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Core.Admin
{
    public interface IAdmin
    {
        void unsubscribecontect(EmailTempleteViewModel model);
        void GetCompanyDetailById(ClientModel model);
        void StateList(ClientModel model);

        void getcontactbycompanyId(ClientModel model);

        void CityList(ClientModel model);
        void AddUpdateCompany(ClientModel model);
        void ClientList(ClientModel model);

        void clientdetail(ClientModel model);
        void ClientDelete(ClientModel model);


        void email(EmailTempleteViewModel model);
        void GetEmailTempleteById(EmailTempleteViewModel model);
        void emailpopup(EmailTempleteViewModel model);
        void AddUpdateEmailTemplate(EmailTempleteViewModel model);
        void DeleteEmailTemplate(EmailTempleteViewModel model);
        void enquires(EnquiresViewModel model);
        void profile(ProfileViewModel model);
        void updateprofile(ProfileViewModel model);
        void GetEmailTemplateById(EmailTempleteViewModel model);
        void AddClientContact(ClientModel model);
        void ClientContact(ClientModel model);
        void DeleteCompanyContact(ClientModel model);

        void getmessagebyId(EnquiresViewModel model);
        void replyenquire(EnquiresViewModel model);
        void emailsendDetailsById(EmailTempleteViewModel model);
        void inseremaildetail(EmailTempleteViewModel model);
        void ChanageFollowUpStatus(EmailTempleteViewModel model);
        void changePipelinestatusConfirm(EmailTempleteViewModel model);
        void enquerydelete(EnquiresViewModel model);


        void pipeline(ClientModel model);
        void Dashboarddetail(Dashboardmodel model);

        void SaveNotes(ClientModel model);

        void NOtesDelete(ClientModel model);
        void MeetingActiveTab(Dashboardmodel model);
        void AddCompanyToDoPopUp(ClientModel model);
        void CreatecompanyToDo(ClientModel model);
        void companytodounactive(ClientModel model);
        void companytodoactive(ClientModel model);
        void pipelinestatus(ClientModel model);
        void GetCompanyIdByEmail(ClientModel model);
        void ClientSendenquery(ClientModel model);
        void interviewsrequestbycandidates(ClientModel model);
        void shortlist(ClientModel model);
        void UpdateInterviewschedule(ClientModel model);
        void InterviewSceduleList(ClientModel model);
        void InterViewdelete(ClientModel model);
        void InterviewSchedulepopup(ClientModel model);
        void getassignByEmail(ClientModel model);
        void Createassignpay(ClientModel model);
        void AssignList(ClientModel model);
        void sharedJob(JobsModel model);
        void Createuploadresumesave(JobsModel model);
        void SubmissionProfile(JobsModel model);
        void UpdatedEmaildetailById(EmailTempleteViewModel model);
        void emailEditpopup(EmailTempleteViewModel model);
        void Updateemailsend(EmailTempleteViewModel model);
        void NewCampaign(CampaignModel model);
        void AddUpdateCampaign(CampaignModel model);
        void Campaign(CampaignModel model);
        void DeleteCampaign(CampaignModel model);
        void campaignhistory(CampaignModel model);
        void NewLetter(EnquiresViewModel model);
        void DeleteNewletter(EnquiresViewModel model);
        void getTagBytypeId(CampaignModel model);
        void Alert(Alertmodel model);
        void alertunactiveJobbyId(Alertmodel model);
        void Updatesharejobsstatus(JobsModel model);
        void sharjobIdziprecuiter(JobsModel model);
        void Users(UserManagmentmodel model);
        void AdminUsermanage(UserManagmentmodel model);
        void UserList(UserManagmentmodel model);

        void deleteUsers(UserManagmentmodel model);

        void Role(RoleListModel model);
        void addnewrole(RoleViewModel model);
        void getpage(RoleListModel model);
        void AddUpdateRole(RoleViewModel model);
        void messages(Candidateconversationmodel model);
        void messagesdetail(Candidateconversationmodel model);
        void GeneralMessages(ClientModel model);
        void generalmessagesdetails(ClientModel model);
        void savesendgeneralmessagebyadmin(ClientModel model);

        void AutoCompleteClient(ClientModel model);

        void sendAdmingeneralmessages(ClientModel model);
        void pipelinemessagesendbyadmin(Candidateconversationmodel model);
        void ClientProfileById(ClientModel model);
        void CreateCompany(ClientModel model);
        void Admin_DeleteCompanyContact(ClientModel model);
        void ActivationEmailToContact(ClientModel model);
    }
}
