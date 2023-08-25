using System.Collections.Generic;
using System.Data;
using Web.Dal.Common;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;

namespace Web.Core.Common.Impl
{
    public class LoginService : ILogin
    {
        LoginFactory _objFactory = new LoginFactory();
        LoginDel _objDel = new LoginDel();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public void CandidateLogin(LoginModel model)
        {
            ds = _objDel.CandidateLogin(model);
            _objFactory.CandidateLogin(model, ds);
        }

        public void ChangePasswordEmail(LoginModel model)
        {
            _objDel.ChangePasswordEmail(model);
        }
        public void ClientsendqueryDelete(ClientModel model)
        {
            _objDel.ClientsendqueryDelete(model);
        }
        public void emailread(string ids)
        {
            _objDel.emailread(ids);
        }
        public void CreateCandidate(LoginModel model)
        {
            dt = _objDel.CreateCandidate(model);
            _objFactory.CreateCandidate(model, dt);
        }
        public void unsubscribe(LoginModel model)
        {
            ds = _objDel.unsubscribe(model);
            _objFactory.unsubscribe(model, ds);
        }
        public void ForgotPasswordEmail(LoginModel model)
        {
            ds = _objDel.ForgotPasswordEmail(model);
            _objFactory.ForgotPassword(model, ds);
        }

        public void updateforgotPassword(LoginModel model)
        {
            _objDel.updateforgotPassword(model);
        }

        public void unsubscribeClick(LoginModel model)
        {
            _objDel.unsubscribeClick(model);
        } 
        public void CreateContactUs(ContactUs model)
        {
            _objDel.CreateContactUs(model);
            _objFactory.CreateContactUs(model);
        }

        public void confirmation(LoginModel model)
        {
            _objDel.confirmation(model);
        }

        public void CandidateDetailsbyId(CandidateModel model)
        {
            ds = _objDel.CandidateDetailsbyId(model);
            _objFactory.CandidateDetailsbyId(model, ds);
        }

        public void ClientSendenquery(ClientModel model)
        {
            _objDel.ClientSendenquery(model);
        }

        public void job(JobsModel model)
        {
            ds = _objDel.job(model);
            _objFactory.job(model, ds);
        }

        public void GetHomeIndex(JobsModel model)
        {
            ds = _objDel.GetHomeIndex(model);
            _objFactory.GetHomeIndex(model, ds);
        }
        public void AppliedJob(JobsModel model)
        {
            ds = _objDel.AppliedJob(model);
            _objFactory.AppliedJob(model, ds);
        }

        public void JobSave(JobsModel model)
        {
            _objDel.JobSave(model);
        }

        public void CandidateJobapplyLogin(JobsModel model)
        {
            dt = _objDel.CandidateJobapplyLogin(model);
            _objFactory.CandidateJobapplyLogin(model, dt);
        }

        public void creategustcandidate(JobsModel model)
        {
            ds = _objDel.creategustcandidate(model);
            _objFactory.creategustcandidate(model, ds);
        }

        public void Jobsautocomplete(JobsModel model)
        {
            dt = _objDel.Jobsautocomplete(model);
            _objFactory.Jobsautocomplete(model, dt);
        }

        public void plan(PlanModel model)
        {
            dt = _objDel.plan(model);
            _objFactory.plan(model, dt);
        }

        public void plandetails(PlanModel model)
        {
            dt = _objDel.plandetails(model);
            _objFactory.plandetails(model, dt);
        }

        public void GetLocation(LoginModel model)
        {
            dt = _objDel.GetLocation(model);
            _objFactory.GetLocation(dt, model);
        }
        public void Campaignread(string campiganId, string contactId)
        {
            _objDel.Campaignread(campiganId, contactId);
        }

        public void NewletterCreate(LoginModel model)
        {
            _objDel.NewletterCreate(model);
        }

        public void savejobalert(jobalertviewmodel model)
        {
            _objDel.savejobalert(model);
        }

        public void alertunsubscribe(string alertid, string alerttypeId)
        {
            _objDel.alertunsubscribe(alertid, alerttypeId);
        }

        public void ZipRecruiter()
        {
            ds = _objDel.ZipRecruiter();
            _objFactory.ZipRecruiter(ds);
        }

        public void getemailbyId(JobsModel model)
        {
            dt = _objDel.getemailbyId(model);
        }

        public void sendemail(JobsModel model)
        {
            _objDel.sendemail(model);
            _objFactory.sendemail(model);
        } 

        public IEnumerable<MainMenu> GetAllMenuSubmenu()
        {
            ds = _objDel.GetAllMenuSubmenu();
            return _objFactory.GetAllMenuSubmenu(ds);
        }

        public int CheckPermission(string area, string Controller, string Action, int RoleId)
        {
            return _objDel.CheckPermission(area, Controller, Action, RoleId);
        }

        public void getIds(JobsModel model)
        {
            _objDel.getIds(model);
        }

        public void requestmoreinfo(JobsModel model1)
        {
            ds = _objDel.requestmoreinfo(model1);
            _objFactory.AppliedJob(model1, ds);
        }

        public void MakeFreePayment(PaymentViewModel model)
        {
            _objDel.MakeFreePayment(model);
        }


        public IEnumerable<ZipCodeVIewModel> GetAllZipCodewithlatlong()
        {
            dt = _objDel.GetAllZipCodewithlatlong();
            return  _objFactory.GetAllZipCodewithlatlong(dt);
        }

        public string getzipcodeforzipcodesizedecrease(string zip)
        {
           return  _objDel.getzipcodeforzipcodesizedecrease(zip); 
        }
    }
}
