
using System.Data;
using Web.Dal.Admin;
using Web.Model.Admin;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Core.Admin.Impl
{
    public class AdminService : IAdmin
    {
        AdminFactory _objAFactory = new AdminFactory();
        AdminDel _objADel = new AdminDel();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public void unsubscribecontect(EmailTempleteViewModel model)
        {
            _objADel.unsubscribecontect(model);
        }

        public void emailpopup(EmailTempleteViewModel model)
        {
            ds = _objADel.emailpopup(model);
            _objAFactory.emailpopup(model, ds);
        }
        public void CityList(ClientModel model)
        {
            dt = _objADel.CityList(model);
            _objAFactory.CityList(model, dt);
        }

        public void GetCompanyDetailById(ClientModel model)
        {
            ds = _objADel.GetCompanyDetailById(model);
            _objAFactory.GetCompanyDetailById(model, ds);

        }

        public void ClientDelete(ClientModel model)
        {
            _objADel.ClientDelete(model);
        }

        public void clientdetail(ClientModel model)
        {
            ds = _objADel.clientdetail(model);
            _objAFactory.clientdetail(model, ds);
        }

        public void ClientList(ClientModel model)
        {
            ds = _objADel.ClientList(model);
            _objAFactory.ClientList(model, ds);
        }

        public void AddUpdateCompany(ClientModel model)
        {
            _objADel.AddUpdateCompany(model);

        }

        public void StateList(ClientModel model)
        {
            dt = _objADel.StateList(model);
            _objAFactory.StateList(model, dt);
        }


        public void getcontactbycompanyId(ClientModel model)
        {
            dt = _objADel.getcontactbycompanyId(model);
            _objAFactory.getcontactbycompanyId(model, dt);
        }



        public void email(EmailTempleteViewModel model)
        {
            dt = _objADel.email(model);
            _objAFactory.email(model, dt);
        }
        public void DeleteEmailTemplate(EmailTempleteViewModel model)
        {
            _objADel.DeleteEmailTemplate(model);
        }
        public void AddUpdateEmailTemplate(EmailTempleteViewModel model)
        {
            _objADel.AddUpdateEmailTemplate(model);
        }
        public void GetEmailTempleteById(EmailTempleteViewModel model)
        {
            dt = _objADel.GetEmailTempleteById(model);
            _objAFactory.GetEmailTempleteById(model, dt);
        }

        public void enquires(EnquiresViewModel model)
        {
            ds = _objADel.enquires(model);
            _objAFactory.enquires(model, ds);
        }

        public void profile(ProfileViewModel model)
        {
            ds = _objADel.profile(model);
            _objAFactory.profile(model, ds);
        }

        public void updateprofile(ProfileViewModel model)
        {
            _objADel.updateprofile(model);
        }

        public void AddClientContact(ClientModel model)
        {
            dt = _objADel.AddClientContact(model);
            _objAFactory.AddClientContact(model, dt);
        }

        public void ClientContact(ClientModel model)
        {
            dt = _objADel.ClientContact(model);
            _objAFactory.ClientContact(model, dt);
        }
        public void DeleteCompanyContact(ClientModel model)
        {
            _objADel.DeleteCompanyContact(model);
        }
        public void Admin_DeleteCompanyContact(ClientModel model)
        {
            _objADel.Admin_DeleteCompanyContact(model);
        }
        public void getmessagebyId(EnquiresViewModel model)
        {
            dt = _objADel.getmessagebyId(model);
            _objAFactory.getmessagebyId(model, dt);
        }

        public void replyenquire(EnquiresViewModel model)
        {
            dt = _objADel.replyenquire(model);
            _objAFactory.replyenquire(model, dt);

        }

        public void GetEmailTemplateById(EmailTempleteViewModel model)
        {
            dt = _objADel.GetEmailTemplateById(model);
            _objAFactory.GetEmailTemplateById(model, dt);
        }

        public void emailsendDetailsById(EmailTempleteViewModel model)
        {
            dt = _objADel.emailsendDetailsById(model);
            _objAFactory.emailsendDetailsById(model, dt);
        }

        public void inseremaildetail(EmailTempleteViewModel model)
        {
            _objADel.inseremaildetail(model);
        }

        public void ChanageFollowUpStatus(EmailTempleteViewModel model)
        {
            _objADel.ChanageFollowUpStatus(model);
        }

        public void changePipelinestatusConfirm(EmailTempleteViewModel model)
        {
            _objADel.changePipelinestatusConfirm(model);
        }

        public void enquerydelete(EnquiresViewModel model)
        {
            _objADel.enquerydelete(model);
        }

        public void pipeline(ClientModel model)
        {

            ds = _objADel.pipeline(model);
            _objAFactory.pipeline(model, ds);
        }
        public void Dashboarddetail(Dashboardmodel model)
        {
            ds = _objADel.Dashboarddetail(model);
            _objAFactory.Dashboarddetail(model, ds);
        }
        public void SaveNotes(ClientModel model)
        {
            _objADel.SaveNotes(model);
        }

        public void NOtesDelete(ClientModel model)
        {
            _objADel.NOtesDelete(model);
        }

        public void MeetingActiveTab(Dashboardmodel model)
        {

            dt = _objADel.MeetingActiveTab(model);

            _objAFactory.MeetingActiveTab(model, dt);
        }

        public void AddCompanyToDoPopUp(ClientModel model)
        {
            ds = _objADel.AddCompanyToDoPopUp(model);
            _objAFactory.AddCompanyToDoPopUp(model, ds);
        }

        public void CreatecompanyToDo(ClientModel model)
        {
            _objADel.CreatecompanyToDo(model);
        }

        public void companytodounactive(ClientModel model)
        {
            _objADel.companytodounactive(model);
        }
        public void companytodoactive(ClientModel model)
        {
            _objADel.companytodoactive(model);
        }

        public void pipelinestatus(ClientModel model)
        {
            _objADel.pipelinestatus(model);
        }
        public void GetCompanyIdByEmail(ClientModel model)
        {
            dt = _objADel.GetCompanyIdByEmail(model);
            _objAFactory.GetCompanyIdByEmail(model, dt);
        }

        public void ClientSendenquery(ClientModel model)
        {
            dt = _objADel.ClientSendenquery(model);
            _objAFactory.ClientSendenquery(model, dt);
        }



        public void interviewsrequestbycandidates(ClientModel model)
        {
            dt = _objADel.interviewsrequestbycandidates(model);
            _objAFactory.interviewsrequestbycandidates(model, dt);
        }



        public void shortlist(ClientModel model)
        {
            dt = _objADel.shortlist(model);
            _objAFactory.shortlist(model, dt);
        }

        public void UpdateInterviewschedule(ClientModel model)
        {
            ds = _objADel.UpdateInterviewschedule(model);
            _objAFactory.UpdateInterviewschedule(model, ds);
        }

        public void InterviewSceduleList(ClientModel model)
        {
            ds = _objADel.InterviewSceduleList(model);
            _objAFactory.InterviewSceduleList(model, ds);
        }

        public void InterViewdelete(ClientModel model)
        {
            _objADel.InterViewdelete(model);
        }

        public void InterviewSchedulepopup(ClientModel model)
        {
            ds = _objADel.InterviewSchedulepopup(model);
            _objAFactory.InterviewSchedulepopup(model, ds);
        }

        public void getassignByEmail(ClientModel model)
        {
            dt = _objADel.getassignByEmail(model);
            _objAFactory.getassignByEmail(model, dt);
        }

        public void Createassignpay(ClientModel model)
        {
            _objADel.Createassignpay(model);
        }

        public void AssignList(ClientModel model)
        {
            dt = _objADel.AssignList(model);
            //_objAFactory.getassignByEmail(model, dt);
        }

        public void sharedJob(JobsModel model)
        {
            ds = _objADel.sharedJob(model);
            _objAFactory.sharedJob(model, ds);
        }

        public void Createuploadresumesave(JobsModel model)
        {
            ds = _objADel.Createuploadresumesave(model);
            _objAFactory.Createuploadresumesave(model, ds);
        }

        public void SubmissionProfile(JobsModel model)
        {
            ds = _objADel.SubmissionProfile(model);
            _objAFactory.SubmissionProfile(model, ds);
        }

        public void UpdatedEmaildetailById(EmailTempleteViewModel model)
        {
            _objADel.UpdatedEmaildetailById(model);
        }

        public void emailEditpopup(EmailTempleteViewModel model)
        {
            dt = _objADel.emailEditpopup(model);
            _objAFactory.emailEditpopup(model, dt);
        }

        public void Updateemailsend(EmailTempleteViewModel model)
        {
            _objADel.Updateemailsend(model);
        }

        public void NewCampaign(CampaignModel model)
        {
            ds = _objADel.NewCampaign(model);
            _objAFactory.NewCampaign(model, ds);
        }

        public void AddUpdateCampaign(CampaignModel model)
        {
            _objADel.AddUpdateCampaign(model);
        }

        public void Campaign(CampaignModel model)
        {
            ds = _objADel.Campaign(model);
            _objAFactory.Campaign(model, ds);
        }

        public void DeleteCampaign(CampaignModel model)
        {
            _objADel.DeleteCampaign(model);
        }

        public void campaignhistory(CampaignModel model)
        {
            ds = _objADel.campaignhistory(model);
            _objAFactory.campaignhistory(model, ds);
        }

        public void NewLetter(EnquiresViewModel model)
        {
            dt = _objADel.NewLetter(model);
            _objAFactory.NewLetter(model, dt);
        }

        public void DeleteNewletter(EnquiresViewModel model)
        {
            _objADel.DeleteNewletter(model);
        }

        public void getTagBytypeId(CampaignModel model)
        {
            dt = _objADel.getTagBytypeId(model);
            _objAFactory.getTagBytype566Id(model, dt);
        }

        public void Alert(Alertmodel model)
        {
            ds = _objADel.Alert(model);
            _objAFactory.Alert(model, ds);
        }

        public void alertunactiveJobbyId(Alertmodel model)
        {
            _objADel.alertunactiveJobbyId(model);
        }

        public void Updatesharejobsstatus(JobsModel model)
        {
            _objADel.Updatesharejobsstatus(model);
        }

        public void sharjobIdziprecuiter(JobsModel model)
        {
            dt = _objADel.sharjobIdziprecuiter(model);
            _objAFactory.sharjobIdziprecuiter(model, dt);
        }

        public void Users(UserManagmentmodel model)
        {
            ds = _objADel.Users(model);
            _objAFactory.Users(model, ds);
        }

        public void AdminUsermanage(UserManagmentmodel model)
        {
            dt = _objADel.AdminUsermanage(model);
            _objAFactory.AdminUsermanage(model, dt);
        }

        public void UserList(UserManagmentmodel model)
        {
            dt = _objADel.UserList(model);
            _objAFactory.UserList(model, dt);
        }


        public void deleteUsers(UserManagmentmodel model)
        {
            _objADel.deleteUsers(model);
        }
        public void Role(RoleListModel model)
        {
            dt = _objADel.Role(model);
            _objAFactory.Role(model, dt);
        }

        public void addnewrole(RoleViewModel model)
        {
            ds = _objADel.addnewrole(model);
            _objAFactory.addnewrole(model, ds);
        }

        public void getpage(RoleListModel model)
        {
            dt = _objADel.getpage(model);
            _objAFactory.getpage(model, dt);
        }

        public void AddUpdateRole(RoleViewModel model)
        {
            _objADel.AddUpdateRole(model);

        }

        public void messages(Candidateconversationmodel model)
        {
            ds = _objADel.messages(model);
            _objAFactory.messages(model, ds);
        }

        public void messagesdetail(Candidateconversationmodel model)
        {
            ds = _objADel.messagesdetail(model);
            _objAFactory.messagesdetail(model, ds);
        }

        public void GeneralMessages(ClientModel model)
        {
            ds = _objADel.GeneralMessages(model);
            _objAFactory.GeneralMessages(model, ds);
        }

        public void generalmessagesdetails(ClientModel model)
        {
            ds = _objADel.generalmessagesdetails(model);
            _objAFactory.generalmessagesdetails(model, ds);
        }

        public void savesendgeneralmessagebyadmin(ClientModel model)
        {
            _objADel.savesendgeneralmessagebyadmin(model);
        }


        public void AutoCompleteClient(ClientModel model)
        {
            dt = _objADel.AutoCompleteClient(model);
            _objAFactory.AutoCompleteClient(model, dt);
        }
        public void sendAdmingeneralmessages(ClientModel model)
        {
            _objADel.sendAdmingeneralmessages(model);

        }

        public void pipelinemessagesendbyadmin(Candidateconversationmodel model)
        {
            _objADel.pipelinemessagesendbyadmin(model);
        }

        public void ClientProfileById(ClientModel model)
        {
            dt = _objADel.ClientProfileById(model);
            _objAFactory.ClientProfileById(model, dt);
        }

        public void CreateCompany(ClientModel model)
        {
          dt=     _objADel.CreateCompany(model);
            _objAFactory.CreateCompany(model, dt);

        }
        public void ActivationEmailToContact(ClientModel model)
        {
            dt = _objADel.ActivationEmailToContact(model);
            _objAFactory.ActivationEmailToContact(model, dt);
        }
    }
}
