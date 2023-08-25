using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using Web.Dal.Candidate;
using Web.Model.Admin;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;

namespace Web.Core.Candidate.Impl
{
    public class CandidateService : ICandidate
    {
        CandidateFactory _ObjCandidateFactory = new CandidateFactory();
        CandiateDel _objcandidateDel = new CandiateDel();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();



        public void CadidateList(CandidateModel model)
        {
            ds = _objcandidateDel.CadidateList(model);
            _ObjCandidateFactory.CadidateList(model, ds);
        }

        public void CandidateawardsDelete(CandidateModel model)
        {
            _objcandidateDel.CandidateawardsDelete(model);
        }
        public void Deleteskill(CandidateModel model)
        {
            _objcandidateDel.Deleteskill(model);
        }
        public void CandidateAwardspopup(CandidateModel model)
        {
            ds = _objcandidateDel.CandidateAwardspopup(model);
            _ObjCandidateFactory.CandidateAwardspopup(model, ds);
        }

        public void CandidateDelete(CandidateModel model)
        {
            dt = _objcandidateDel.CandidateDelete(model);
            _ObjCandidateFactory.CandidateDelete(model, dt);
        }

        public void CandidateDetail(CandidateModel model)
        {
            dt = _objcandidateDel.CandidateDetail(model);
            _ObjCandidateFactory.CandidateDetail(model, dt);
        }

        public void CandidateEducationDelete(CandidateModel model)
        {
            _objcandidateDel.CandidateEducationDelete(model);
        }

        public void CandidateEducationpopup(CandidateModel model)
        {
            ds = _objcandidateDel.CandidateEducationpopup(model);
            _ObjCandidateFactory.CandidateEducationpopup(model, ds);
        }

        public void Candidateportfoliosave(CandidateModel model)
        {
            _objcandidateDel.Candidateportfoliosave(model);
        }

        public void Candidates(CandidateModel model)
        {
            dt = _objcandidateDel.Candidates(model);
            _ObjCandidateFactory.Candidates(model, dt);
        }

        public void CandidateworkexperienceDelete(CandidateModel model)
        {
            _objcandidateDel.CandidateworkexperienceDelete(model);
        }

        public void Candidateworkexperiencepopup(CandidateModel model)
        {
            ds = _objcandidateDel.Candidateworkexperiencepopup(model);
            _ObjCandidateFactory.Candidateworkexperiencepopup(model, ds);
        }

        public void CityList(CandidateModel model)
        {
            dt = _objcandidateDel.CityList(model);
            _ObjCandidateFactory.CityList(model, dt);
        }

        public void createawardscandidate(CandidateModel model)
        {
            _objcandidateDel.createawardscandidate(model);
        }

        public void CreateCandidate(CandidateModel model)
        {
            dt = _objcandidateDel.CreateCandidate(model);
            _ObjCandidateFactory.CreateCandidate(model, dt);

        }
        public void ResumeImageUpload(CandidateModel model)
        {
            dt = _objcandidateDel.ResumeImageUpload(model);
            _ObjCandidateFactory.ResumeImageUpload(model, dt);


        }
        public void ProfileImageUpload(CandidateModel model)
        {
            dt = _objcandidateDel.ProfileImageUpload(model);
            _ObjCandidateFactory.ProfileImageUpload(model, dt);

        }
        public void createeducationcandidate(CandidateModel model)
        {
            _objcandidateDel.createeducationcandidate(model);
        }


        public void addupdatelicensescertification(CandidateModel model)
        {
            _objcandidateDel.addupdatelicensescertification(model);
        }

        public void createworkexperiencecandidate(CandidateModel model)
        {
            _objcandidateDel.createworkexperiencecandidate(model);
        }
        public void SkillAddUpdate(CandidateModel model)
        {
            _objcandidateDel.SkillAddUpdate(model);
        }
        public void candidatedetailbyId(CandidateModel model)
        {
            ds = _objcandidateDel.candidatedetailbyId(model);
            _ObjCandidateFactory.candidatedetailbyId(model, ds);
        }

        public void StateList(CandidateModel model)
        {
            dt = _objcandidateDel.StateList(model);
            _ObjCandidateFactory.StateList(model, dt);
        }

        public void UpdateCandidate(CandidateModel model)
        {
            dt = _objcandidateDel.UpdateCandidate(model);
            _ObjCandidateFactory.UpdateCandidate(model, dt);
        }

        public void candidateprofilepopup(CandidateModel model)
        {
            ds = _objcandidateDel.candidateprofilepopup(model);
            _ObjCandidateFactory.candidateprofilepopup(model, ds);
        }
        public void AddUpdateSkillsPopup(CandidateModel model)
        {
            ds = _objcandidateDel.AddUpdateSkillsPopup(model);
            _ObjCandidateFactory.AddUpdateSkillsPopup(model, ds);
        }

        public void CandidateResumeUpload(CandidateModel model)
        {
            _objcandidateDel.CandidateResumeUpload(model);
        }

        public void UploadVideo(CandidateModel model)
        {
            _objcandidateDel.UploadVideo(model);
        }


        public void CandidateportfolioDelete(CandidateModel model)
        {
            dt = _objcandidateDel.CandidateportfolioDelete(model);
            _ObjCandidateFactory.CandidateportfolioDelete(model, dt);
        }
        public void CandidateVediopopu(CandidateModel model)
        {
            ds = _objcandidateDel.CandidateVediopopu(model);
            _ObjCandidateFactory.CandidateVediopopu(model, ds);

        }
        //Hone module//////////////////////////////////////////////////////////////////
        public void GetAllCandidateList(CandidateListModel model)
        {
            ds = _objcandidateDel.GetAllCandidateList(model);
            _ObjCandidateFactory.GetAllCandidateList(model, ds);
        }

        public void Candidateportfoliopopup(CandidateModel model)
        {
            ds = _objcandidateDel.Candidateportfoliopopup(model);
            _ObjCandidateFactory.Candidateportfoliopopup(model, ds);
        }

        public void Candididaterefencessave(CandidateModel model)
        {
            _objcandidateDel.Candididaterefencessave(model);
        }

        public void Candidaterefrencespopup(CandidateModel model)
        {
            dt = _objcandidateDel.Candidaterefrencespopup(model);
            _ObjCandidateFactory.Candidaterefrencespopup(model, dt);
        }



        public void LicensesCertificationspopup(CandidateModel model)
        {
            ds = _objcandidateDel.LicensesCertificationspopup(model);
            _ObjCandidateFactory.LicensesCertificationspopup(model, ds);
        }


        public void candidaterefrenceDelete(CandidateModel model)
        {
            _objcandidateDel.candidaterefrenceDelete(model);
        }

        public void Candidateskillsvaluesave(CandidateModel model)
        {
            _objcandidateDel.Candidateskillsvaluesave(model);
        }

        public void AutoCompleteSkills(CandidateModel model)
        {
            dt = _objcandidateDel.AutoCompleteSkills(model);
            _ObjCandidateFactory.AutoCompleteSkills(model, dt);
        }

        public void Dashboard(CandidateModel model)
        {
            ds = _objcandidateDel.Dashboard(model);
            _ObjCandidateFactory.Dashboard(model, ds);
        }


        public void MyappliedJob(JobsModel model)
        {
            dt = _objcandidateDel.MyappliedJob(model);
            _ObjCandidateFactory.MyappliedJob(model, dt);
        }

        public void JobAppliedDeletebyId(JobsModel model)
        {
            _objcandidateDel.JobAppliedDeletebyId(model);
        }

        public void MySavedJobList(JobsModel model)
        {
            dt = _objcandidateDel.MySavedJobList(model);
            _ObjCandidateFactory.MySavedJobList(model, dt);
        }

        public void JobSavedDeletebyId(JobsModel model)
        {
            _objcandidateDel.JobSavedDeletebyId(model);
        }

        public void Applicant(CandidateModel model)
        {
            ds = _objcandidateDel.Applicant(model);
            _ObjCandidateFactory.Applicant(model, ds);
        }

        public void ApplicantDelete(CandidateModel model)
        {
            _objcandidateDel.ApplicantDelete(model);
        }

        public void Interviewstatus(CandidateModel model)
        {
            _objcandidateDel.Interviewstatus(model);
        }

        public void interviewStatusPopup(CandidateModel model)
        {
            ds = _objcandidateDel.interviewStatusPopup(model);
            _ObjCandidateFactory.interviewStatusPopup(model, ds);
        }

        public void interviewscedulelist(ClientModel model)
        {
            ds = _objcandidateDel.interviewscedulelist(model);
            _ObjCandidateFactory.interviewscedulelist(model, ds);
        }

        public void Interviewdetailpopup(ClientModel model)
        {
            ds = _objcandidateDel.InterviewSchedulepopup(model);
            _ObjCandidateFactory.InterviewSchedulepopup(model, ds);
        }

        public void InterViewdelete(ClientModel model)
        {
            _objcandidateDel.InterViewdelete(model);
        }

        public void CDetail(CandidateModel model)
        {
            ds = _objcandidateDel.CDetail(model);
            _ObjCandidateFactory.CDetail(model, ds);
        }

        public void PlanCreatepopup(PlanModel model)
        {

            ds = _objcandidateDel.PlanCreatepopup(model);
            _ObjCandidateFactory.PlanCreatepopup(model, ds);
        }





        public void CreatePlan(PlanModel model)
        { 
            _objcandidateDel.CreatePlan(model);
        }

        public void Plan(PlanModel model)
        {
            ds = _objcandidateDel.Plan(model);
            _ObjCandidateFactory.Plan(model, ds);
        }

        public void PlanDelete(PlanModel model)
        {
            _objcandidateDel.PlanDelete(model);
        }

        public void SaveTransaction(PlansViewModel model)
        {
            _objcandidateDel.SaveTransaction(model);
        }

        public void Candidatedefaultimage(CandidateModel model)
        {
            dt = _objcandidateDel.Candidatedefaultimage(model);
            _ObjCandidateFactory.Candidatedefaultimage(model, dt);
        }

        public void paymenthistory(PlansListModel model)
        {
            ds = _objcandidateDel.paymenthistory(model);
            _ObjCandidateFactory.paymenthistory(model, ds);
        }

        public void CandidatesharedJobpopup(CandidateModel model)
        {
            ds = _objcandidateDel.CandidatesharedJobpopup(model);
            _ObjCandidateFactory.CandidatesharedJobpopup(model, ds);
        }
         
        public void AddSharedJobcandidatebyId(CandidateModel model)
        {
            _objcandidateDel.AddSharedJobcandidatebyId(model);
        }
        public void SubmitCandidateProfile(CandidateModel model)
        {
            _objcandidateDel.SubmitCandidateProfile(model);
        }

        
       
        public void Clientinterviewscedulelist(ClientModel model)
        {
            ds = _objcandidateDel.Clientinterviewscedulelist(model);
            _ObjCandidateFactory.interviewscedulelist(model, ds);
        }

        public void getsharedjobbyclientid(CandidateModel model)
        {
            dt = _objcandidateDel.getsharedjobbyclientid(model);
            _ObjCandidateFactory.getsharedjobbyclientid(model, dt);
        }

        public void Candidatetagvalue(Tagsmodel model)
        {
            ds = _objcandidateDel.Candidatetagvalue(model);
            _ObjCandidateFactory.Candidatetagvalue(model, ds);
        }

        public void AutoCompleteCandidatetags(CandidateModel model)
        {
            dt = _objcandidateDel.AutoCompleteCandidatetags(model);
            _ObjCandidateFactory.AutoCompleteCandidatetags(model, dt);
        }

        public void deletecandidatetag(CandidateModel model)
        {
            _objcandidateDel.deletecandidatetag(model);
        }
        public void InterviewSchedulecalenderlist(ClientModel model)
        {
            dt = _objcandidateDel.InterviewSchedulecalenderlist(model);
            _ObjCandidateFactory.InterviewSchedulecalenderlist(model, dt);
        }

        public void getinterviewschedulelist(ClientModel model)
        {
            dt = _objcandidateDel.getinterviewschedulelist(model);
            _ObjCandidateFactory.getinterviewschedulelist(model, dt);
        }

        public void interviewlistbycandidate(ClientModel model)
        {
            dt = _objcandidateDel.interviewlistbycandidate(model);
            _ObjCandidateFactory.getinterviewschedulelist(model, dt);
        }

        public void getallunreadmessage(ClientModel model)
        {
            ds = _objcandidateDel.getallunreadmessage(model);
            _ObjCandidateFactory.getallunreadmessage(model, ds);
        }

        public void messageslist(Candidateconversationmodel model)
        {
            ds = _objcandidateDel.messageslist(model);
            _ObjCandidateFactory.messageslist(model, ds);
        }

        public void conversation(Candidateconversationmodel model)
        {
            ds = _objcandidateDel.conversation(model);
            _ObjCandidateFactory.conversation(model, ds);
        }

        public void Candidateconversationsaved(Candidateconversationmodel model)
        {
            _objcandidateDel.Candidateconversationsaved(model);
        }

        public void generalmessagelist(Candidateconversationmodel model)
        {
            ds = _objcandidateDel.generalmessagelist(model);
            _ObjCandidateFactory.generalmessagelist(model, ds);
        }

        public void generalmessagedetail(Candidateconversationmodel model)
        {
            ds = _objcandidateDel.generalmessagedetail(model);
            _ObjCandidateFactory.generalmessagedetail(model, ds);
        }

        public void generalmessageconversationsaved(Candidateconversationmodel model)
        {
            _objcandidateDel.generalmessageconversationsaved(model);
        }

        public void sendgeneralmessages(ClientModel model)
        {
            _objcandidateDel.sendgeneralmessages(model);
        }

        public void CandidateNnotification(ClientModel model)
        {
            ds = _objcandidateDel.CandidateNnotification(model);
            _ObjCandidateFactory.CandidateNnotification(model, ds);
        }

        public void AdminNotification(ClientModel model)
        {
            ds = _objcandidateDel.AdminNotification(model);
            _ObjCandidateFactory.AdminNotification(model, ds);
        }

        public void UpdateCandidateOnsolr(CandidateModel model)
        {
            ds = _objcandidateDel.UpdateCandidateOnsolr(model);
            _ObjCandidateFactory.UpdateCandidateOnsolr(model, ds);
        }

        public void Error(long id, string error)
        {
            _objcandidateDel.Error(id,error);
        }

        public void CandidateDetailsbyId(CandidateModel model)
        {
            ds = _objcandidateDel.CandidateDetailsbyId(model);
            _ObjCandidateFactory.CandidateDetailsbyId(model, ds);
        }

        public void LicensesCertificationsDelete(CandidateModel model)
        {
            _objcandidateDel.LicensesCertificationsDelete(model);
        }

        public void PlanActiveInactive(PlanModel model)
        {
            _objcandidateDel.PlanActiveInactive(model);
        }

        public void submitedprofile(Candidateconversationmodel model)
        {
            ds = _objcandidateDel.submitedprofile(model);
            _ObjCandidateFactory.submitedprofile(model, ds);
        }

        public void submitedprofiledetail(Candidateconversationmodel model)
        {
            ds = _objcandidateDel.submitedprofiledetail(model);
            _ObjCandidateFactory.submitedprofiledetail(model, ds);
        }
        public void submitedMessageprofile(Candidateconversationmodel model)
        {
            _objcandidateDel.submitedMessageprofile(model);
        }

        public void getallzipcodeinradius(CandidateModel model)
        {
            ds = _objcandidateDel.getallzipcodeinradius(model);
            _ObjCandidateFactory.getallzipcodeinradius(model, ds);
        }

        public void getAllPaymentHistory(PlansListModel model)
        {
            ds = _objcandidateDel.getAllPaymentHistory(model);
            _ObjCandidateFactory.getAllPaymentHistory(model, ds);
        }

        public void refundpayment(CandidateModel obj)
        {
            ds = _objcandidateDel.refundpayment(obj);

            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                var Subject = "Your payment has been refunded";

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "SubscriptionStopRefund.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{Name}", dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["LastName"].ToString());
                body = body.Replace("{planname}", ds.Tables[1].Rows[0]["PlanName"].ToString());
                sendEmail(Subject, body, dt.Rows[0]["Email"].ToString());
            }

        }


        public void stoppayment(CandidateModel obj)
        {
            ds = _objcandidateDel.stoppayment(obj);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
               string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                var Subject = "Your subscription has been canceled .";  

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "SubscriptionStop.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{Name}", dt.Rows[0]["Name"].ToString()+" "+dt.Rows[0]["LastName"].ToString());
                body = body.Replace("{planname}", ds.Tables[1].Rows[0]["PlanName"].ToString());
                sendEmail(Subject, body, dt.Rows[0]["Email"].ToString());
            }
        }

        private void sendEmail(string Subject, string MsgBody, string ToMailAddress)
        {
            string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
            string AdminCCEmail = System.Configuration.ConfigurationManager.AppSettings["AdminCCEmail"];
            string FromEmailName = System.Configuration.ConfigurationManager.AppSettings["FromEmailName"];
            string FromEmailPassword = System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"];
            string smtphost = System.Configuration.ConfigurationManager.AppSettings["smtphost"];
            Int32 smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);
            bool EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]);
            bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);
            var plainView = AlternateView.CreateAlternateViewFromString(MsgBody, null, "text/plain");
            var htmlView = AlternateView.CreateAlternateViewFromString(MsgBody, null, "text/html");
            MailMessage mailMsg = new MailMessage();
            mailMsg.IsBodyHtml = true;
            mailMsg.From = new MailAddress(FromEmail, FromEmailName);
            mailMsg.CC.Add(AdminCCEmail);
            mailMsg.To.Add(ToMailAddress);
            mailMsg.Subject = Subject;
            mailMsg.Body = MsgBody;
            mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
            mailMsg.Sender = new MailAddress(FromEmail);
            mailMsg.AlternateViews.Add(plainView);
            mailMsg.AlternateViews.Add(htmlView);
            SmtpClient smtp = new SmtpClient(smtphost, Convert.ToInt32(smtpPort));
            smtp.EnableSsl = EnableSsl;
            smtp.UseDefaultCredentials = UseDefaultCredentials;
            mailMsg.IsBodyHtml = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
            smtp.Host = smtphost;
            smtp.Send(mailMsg);
        }

        public void Renewpayment(CandidateModel obj)
        {
            ds = _objcandidateDel.Renewpayment(obj);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                var Subject = "Your subscription Renew successfully.";

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "SubscriptionRenew.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{Name}", dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["LastName"].ToString());
                body = body.Replace("{planname}", ds.Tables[1].Rows[0]["PlanName"].ToString());
                sendEmail(Subject, body, dt.Rows[0]["Email"].ToString());
            }
        }

        public void GetJobOnwerDetailById(Candidateconversationmodel model)
        {
            _objcandidateDel.GetJobOnwerDetailById(model);
        }

        public DataTable CoreUpdate()
        {
            return dt = _objcandidateDel.CoreUpdate();
        }

        public void CheckAndInsertZipCode(CandidateModel model)
        {
            _objcandidateDel.CheckAndInsertZipCode(model);
        }

        public DataTable getallFavoritescandidatelistByClient(CandidateListModel model)
        {
            return dt = _objcandidateDel.getallFavoritescandidatelistByClient(model);
        }
    }
}

