using System.Collections.Generic;
using System.Data;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;

namespace Web.Core.Common
{
    public interface ILogin
    {
        void CandidateLogin(LoginModel model);
        void ForgotPasswordEmail(LoginModel model);
        void ChangePasswordEmail(LoginModel model);
        void updateforgotPassword(LoginModel model);

        void emailread(string ids);

        void CreateCandidate(LoginModel model);
        void unsubscribe(LoginModel model);
        void unsubscribeClick(LoginModel model);
        void CreateContactUs(ContactUs model);
        void confirmation(LoginModel model);
        void CandidateDetailsbyId(CandidateModel model);
        void ClientsendqueryDelete(ClientModel model);
        void ClientSendenquery(ClientModel model);
        void GetHomeIndex(JobsModel model);
        void job(JobsModel model);
        void AppliedJob(JobsModel model);
        void JobSave(JobsModel model);
        void CandidateJobapplyLogin(JobsModel model);
        void creategustcandidate(JobsModel model);
        void Jobsautocomplete(JobsModel model);
        void plan(PlanModel model);
        void plandetails(PlanModel model);
        void GetLocation(LoginModel model);
        void Campaignread(string campiganId, string contactId);
        void NewletterCreate(LoginModel model);
        void savejobalert(jobalertviewmodel model);
        void alertunsubscribe(string alertid, string alerttypeId);
        void ZipRecruiter();
        void getemailbyId(JobsModel model);
        void sendemail(JobsModel model);


        IEnumerable<MainMenu> GetAllMenuSubmenu();


        int CheckPermission(string area, string Controller, string Action, int RoleId);
        void getIds(JobsModel model);
        void requestmoreinfo(JobsModel model1);
        void MakeFreePayment(PaymentViewModel model);

        IEnumerable<ZipCodeVIewModel> GetAllZipCodewithlatlong();
        string getzipcodeforzipcodesizedecrease(string zip);
    }
}
