using IntelDataBase.HelperMethods;
using MvpTelent.Controllers;
using MvpTelent.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Core.Admin;
using Web.Core.Admin.Impl;
using Web.Core.Candidate;
using Web.Core.Candidate.Impl;
using Web.Core.Client;
using Web.Core.Client.Impl;
using Web.Model.Admin;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;
using Web.SolrClient;
using Web.SolrClient.Helpers;
using Web.SolrJobs;
using Web.SolrJobs.Helpers;

namespace MvpTelent.Areas.Admin.Controllers
{
    [CustomAuthorization(DoDatabaseAuthorization = true)]
    public class AdminController : BaseController
    {
        IAdmin _IobjAdmin = new AdminService();
        IClient _Iclient = new ClientService();
        ICandidate _IobjCandidate = new CandidateService();
        string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
        string FromEmailPassword = System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"];
        string smtphost = System.Configuration.ConfigurationManager.AppSettings["smtphost"];
        string smtpPort = System.Configuration.ConfigurationManager.AppSettings["smtpPort"];
        bool EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]);
        bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);

        #region JsonResult

        /// <summary>
        /// unsubscribecontect
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult unsubscribecontect(EmailTempleteViewModel model)
        {
            model.UserId = Convert.ToInt32(Session["Id"]);
            _IobjAdmin.unsubscribecontect(model); 
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// GetEmailTemplateById
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetEmailTemplateById(EmailTempleteViewModel model)
        {
            try
            {
                _IobjAdmin.GetEmailTemplateById(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// emailsend
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult emailsend(EmailTempleteViewModel model)
        {
            string[] emails = model.EmailId.Split(',');
            foreach (string email in emails)
            {
                if (email != "")
                { 
                    model.ContactId = Convert.ToInt64(email);
                    _IobjAdmin.emailsendDetailsById(model);
                    MailMessage mailMsg = new MailMessage();
                    try
                    {
                        string EmailbodyUrl = System.Configuration.ConfigurationManager.AppSettings["EmailbodyUrl"];
                        model.UserId = Convert.ToInt64(Session["Id"]);
                        _IobjAdmin.inseremaildetail(model);
                        string Encryptid = Encrypt(Convert.ToString(model.email_id));
                        mailMsg.Body = "{Body} <br/>" + "<img  src='" + EmailbodyUrl + "/read?ids={Encryptid}' height='0' width='0'/>";
                        string UnsubscribeLink = "<a href='" + EmailbodyUrl + "/unsubscribe?ids=@Id'>Unsubscribe</a>";

                        mailMsg.IsBodyHtml = true;
                        mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market");
                        mailMsg.To.Add(model.Email);
                        //mailMsg.CC.Add("nick@mail.ishoresoftware.com");
                        mailMsg.Subject = model.Subject;
                        string groupurl = "";
                        if (model.GroupId > 0)
                        {
                            groupurl = EmailbodyUrl + "/candidatelist?gids=" + Encrypt(Convert.ToString(model.GroupId));
                          
                        }
                        mailMsg.Body = mailMsg.Body.Replace("{Body}", model.Description);
                        mailMsg.Body = mailMsg.Body.Replace("{Encryptid}", Encryptid);
                        mailMsg.Body = mailMsg.Body.Replace("@name", model.Name);
                        mailMsg.Body = mailMsg.Body.Replace("@unsubscribe", UnsubscribeLink.Replace("@Id", Encryptid));
                        mailMsg.Body = mailMsg.Body.Replace("@groupurl", groupurl);
                        mailMsg.IsBodyHtml = true;
                        //var htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/html");
                        //mailMsg.AlternateViews.Add(htmlView);
                        string bodytext = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title>My Proposal</title><meta http-equiv='Content-Type' content='text/html;charset=ISO-8859-1'></head><body>@body</body></html>";
                        mailMsg.Body = bodytext.Replace("@body", mailMsg.Body);

                        AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/plain");
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/html");

                        plainView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        htmlView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                        mailMsg.AlternateViews.Add(plainView);
                        mailMsg.AlternateViews.Add(htmlView);

                        mailMsg.SubjectEncoding = System.Text.Encoding.UTF8;
                        mailMsg.BodyEncoding = System.Text.Encoding.UTF8;

                        mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
                        mailMsg.Sender = new MailAddress(FromEmail);

                        SmtpClient smtp = new SmtpClient(smtphost, Convert.ToInt32(smtpPort));
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Host = smtphost;
                        smtp.EnableSsl = EnableSsl;
                        smtp.UseDefaultCredentials = UseDefaultCredentials;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
                        smtp.Send(mailMsg);

                        model.Description = mailMsg.Body;
                        _IobjAdmin.UpdatedEmaildetailById(model);

                        model.result = "1";
                    }
                    catch (Exception ex)
                    {
                        model.result = ex.Message;
                        _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                    }
                }
            }
            return Json(model.result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// enquerydelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult enquerydelete(EnquiresViewModel model)
        {
            model.UserId = Convert.ToInt32(Session["Id"]);
            _IobjAdmin.enquerydelete(model);

            return Json(1, JsonRequestBehavior.AllowGet);
        } 

        /// <summary>
        /// StateList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult StateList(ClientModel model)
        {
            try
            {
                _IobjAdmin.StateList(model);
            }
            catch (Exception ex)
            { 
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.StateCollection, JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult getcontactbycompanyId(ClientModel model)
        {
            try
            {
                _IobjAdmin.getcontactbycompanyId(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.StateCollection, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// CityList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult CityList(ClientModel model)
        {
            try
            {
                _IobjAdmin.CityList(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.CityCollection, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// getTagBytypeId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult getTagBytypeId(CampaignModel model)
        {
            try
            {
                _IobjAdmin.getTagBytypeId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// getpage
        /// </summary>
        /// <returns></returns>
        public JsonResult getpage()
        {
            RoleListModel model = new RoleListModel();
            try
            {

                _IobjAdmin.getpage(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.Collection, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// CreateClient
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateClient(ClientModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        HttpPostedFileBase file = files[0];
                        string fname;
                        fname = file.FileName;
                        string folderPath = Server.MapPath("~/FileUpload/CompanyImage/") + model.Id;
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        fname = Path.Combine(folderPath, fname);
                        file.SaveAs(fname);
                    }

                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.AddUpdateCompany(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// DeleteEmailTemplate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult DeleteEmailTemplate(EmailTempleteViewModel model)
        {
            _IobjAdmin.DeleteEmailTemplate(model);
            return Json(model, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// AddUpdateEmailTemplate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddUpdateEmailTemplate(EmailTempleteViewModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.AddUpdateEmailTemplate(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// updateprofile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult updateprofile(ProfileViewModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.updateprofile(model);
                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    string[] myArray = new string[files.Count];
                    for (int i = 0; i < files.Count; i++)
                    {
                        myArray[i] = files[i].FileName.ToString();
                    }
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {

                            fname = file.FileName;
                        }
                        string folderPath = Server.MapPath("~/FileUpload/CandidateImage/") + model.UserId;
                        Directory.CreateDirectory(folderPath);
                        fname = Path.Combine(folderPath, fname);
                        file.SaveAs(fname);
                    }
                    Session["Image"] = "/FileUpload/CandidateImage/" + Convert.ToInt32(model.UserId) + "/" + model.FileName;

                }
                Session["Name"] = model.Name + model.LastName;
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AddClientContact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AddClientContact(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.Password = Convert.ToString(new Random().Next(1111, 9999));
                model.CompanyuserTypeid = 2;
                _IobjAdmin.AddClientContact(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCompany(ClientModel model)
        {
            model.UserId = Convert.ToInt32(Session["Id"]);
            model.Password = Convert.ToString(new Random().Next(1111, 9999));
            model.CompanyuserTypeid = 2;
            _IobjAdmin.CreateCompany(model);
            return Json(model.Status, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ChanageFollowUpStatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ChanageFollowUpStatus(EmailTempleteViewModel model)
        {
            model.UserId = Convert.ToInt32(Session["Id"]);
            _IobjAdmin.ChanageFollowUpStatus(model);
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// changePipelinestatusConfirm
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult changePipelinestatusConfirm(EmailTempleteViewModel model)
        {
            model.UserId = Convert.ToInt32(Session["Id"]);
            _IobjAdmin.changePipelinestatusConfirm(model);

            return Json(1, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// DeleteClientContact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Admin_DeleteCompanyContact(ClientModel model)
        {
            try
            {
                _IobjAdmin.Admin_DeleteCompanyContact(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// DeleteClientContact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult DeleteCompanyContact(ClientModel model)
        {
            try
            {
                _IobjAdmin.DeleteCompanyContact(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// CreatecompanyToDo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreatecompanyToDo(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.CreatecompanyToDo(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// companytodounactive
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult companytodounactive(ClientModel model)
        {
            try
            {
                _IobjAdmin.companytodounactive(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// companytodoactive
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult companytodoactive(ClientModel model)
        {
            try
            {
                _IobjAdmin.companytodoactive(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// GetCompanyIdByEmail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetCompanyIdByEmail(ClientModel model)
        
        {
            try
            {
                _IobjAdmin.GetCompanyIdByEmail(model);
            }
            catch (Exception ex)
            {
                model.Ids = "0";
            }
            return Json(model.Ids, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// SaveNotes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveNotes(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.SaveNotes(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// NOtesDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult NOtesDelete(ClientModel model)
        {
            try
            {
                _IobjAdmin.NOtesDelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// pipelinestatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult pipelinestatus(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.pipelinestatus(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));

            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// replyenquire
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult replyenquire(EnquiresViewModel model)
        {
            try
            {
                // post 
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.replyenquire(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));

            }
            return Json(model, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// cityautocomplete
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult cityautocomplete(string prefix)
        {
            CandidateModel obj = new CandidateModel();
            try
            {
                obj.Id = Convert.ToInt64(prefix);
                _IobjCandidate.CityList(obj);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json((new string(obj.CityCollection.SelectMany(x => x.Name + ",").ToArray())).Split(','), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// sendClientconversationsaved
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult sendClientconversationsaved(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.Name = Convert.ToString(Session["Name"]);
                _Iclient.sendClientconversationsaved(model);

                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    string[] myArray = new string[files.Count];
                    for (int i = 0; i < files.Count; i++)
                    {
                        myArray[i] = files[i].FileName.ToString();
                    }
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string folderPath = Server.MapPath("~/FileUpload/Conversation/") + model.RowsId;
                        Directory.CreateDirectory(folderPath);
                        fname = Path.Combine(folderPath, fname);
                        file.SaveAs(fname);
                    }
                }

            }
          catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        

        /// <summary>
        /// AdminPostJobs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AdminPostJobs(JobsModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.zipcode) == false)
                {
                    CandidateModel model1 = new CandidateModel();
                    model1.Zipcode = model.zipcode;
                    var latlog = getlatlogbyZipCode(model.zipcode);
                    if (latlog !="")
                    {
                        string[] latloglist = latlog.Split(',');
                        model.Latitude = latloglist[0];
                        model.Longitude = latloglist[1];
                        _IobjCandidate.CheckAndInsertZipCode(model1);
                    }
                  
                }

                model.UserId = Convert.ToInt64(Session["Id"]); 
                 model.accounttype = 1; 
                _Iclient.Admin_CreateJobs(model); 
                if (model.JobStatusId == 2)
                {

                    SearchJobNew jobdocument = new SearchJobNew();
                    jobdocument.Id = Convert.ToInt64(model.Id);
                    jobdocument.ids = EncryptDecrypt.encrypt(Convert.ToString(model.Id));
                    if (model.jobtitle != null)
                    {
                        jobdocument.jobtitle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.jobtitle.Trim().ToLower());
                    }
                    jobdocument.jobtypeid = Convert.ToInt64(model.JobTypeId);
                    jobdocument.CategoryId = model.JobCategoryId; 
                    if (model.JobCategoryId > 0)
                    {
                        jobdocument.CategoryName = model.JobCategoryName;
                    }
                    else
                    { jobdocument.CategoryName = ""; }

                    if (model.SubCategoryId > 0)
                    {
                        jobdocument.SubCategoryName = model.SubCategoryName;
                    }
                    else
                    { jobdocument.SubCategoryName = ""; }


                    jobdocument.Designation = model.Designation;
                    jobdocument.JobStatusName = model.JobStatusName;
                    jobdocument.JobType = model.JobTypeName;
                    jobdocument.Description = model.JobDescription;
                    jobdocument.jobstatusid = model.JobStatusId;
                    //jobdocument.CountryName = model.CountyName;
                    jobdocument.zip_code = model.zipcode;
                    jobdocument.Latitude = model.Latitude;
                    jobdocument.Longitude = model.Longitude;
                    //jobdocument.StateName = model.StateName;
                    jobdocument.jobstatusid = model.JobStatusId;
                    jobdocument.statusid = 1;
                    jobdocument.created_by = model.UserId;
                    jobdocument.updated_by = model.UserId;
                    jobdocument.created_date = model.CreDate;
                    jobdocument.updated_date = DateTime.Now;
                    //jobdocument.StateId = model.StateId;
                    //jobdocument.CityName = model.City;
                    jobdocument.ImagePath = model.Image;
                    jobdocument.location = model.location;

                    jobdocument.Tags = model.Tags;


                    // For display
                    jobdocument.MinimumSalary =  model.MinSalary;
                    jobdocument.MaximumSalary = model.MaxSalary;


                    // for search
                    jobdocument.MinSalary = salery(model.MinSalary);
                    jobdocument.MaxSalary = salery(model.MaxSalary);



                    SolrJobsIndex.IndexJob(jobdocument, 1, true);
                   

                }
                else
                {
                    SolrJobsIndex.DeleteCandidateIndex(model.Id);
                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public string getlatlogbyZipCode(string zipcode)
        {
            string storelocation = "";
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + zipcode + "&key=" + ConfigurationManager.AppSettings["locationKey"].ToString();
            url = url.Replace(" ", "+");
            string content = fileGetContents(url);
            JObject results = JObject.Parse(content);
            var data = JsonConvert.DeserializeObject<dynamic>(content);
            foreach (var item in data.results)
            {
                var lat = (decimal)(item.geometry.location.lat);
                var longi = (decimal)(item.geometry.location.lng);
                storelocation = lat + "," + longi;
            }
            return storelocation;
        }

        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);
                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }



        public string salery(string salery)
        {
            salery = salery.Replace(",", String.Empty);



            var Newsalary = salery.Substring(salery.Length - 3);
            if (Newsalary == ".00")
            {
                salery = salery.Remove(salery.Length - 3);
            }
            salery = salery.Replace(".", String.Empty);
            return salery;
        }
         

        /// <summary>
        /// Admincreateeducationcandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Admincreateeducationcandidate(CandidateModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.createeducationcandidate(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Admincreateworkexperiencecandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateInput(false)]

        public JsonResult Admincreateworkexperiencecandidate(CandidateModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.createworkexperiencecandidate(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AdminSkillAddUpdate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminSkillAddUpdate(CandidateModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                if (model.skill.Length != 0)
                {
                    _IobjCandidate.SkillAddUpdate(model);

                     
                    model.Id = model.CandidateId;
                    _IobjCandidate.UpdateCandidateOnsolr(model);

                    // (candidate Update by admin on solr profile)
                    SearchDocumentNew SearchDocument = new SearchDocumentNew();
                    SearchDocument.id = Convert.ToString(model.Id);
                    SearchDocument.first_name = model.Name;
                    SearchDocument.last_name = model.LastName;
                    SearchDocument.full_name = model.Name.Trim() + " " + model.LastName;
                    SearchDocument.email = model.Email;

                    if (model.Phone != null && model.Phone.Trim() != "")
                    {
                        SearchDocument.mobile = model.Phone;
                    } 
                    SearchDocument.created_by = Convert.ToInt64(model.Id);
                    SearchDocument.updated_by = Convert.ToInt64(model.Id);
                    SearchDocument.updated_date = DateTime.Now;
                    SearchDocument.ProfileCheck_Id = Convert.ToInt16(model.ProfileCheck_Id);
                    if (model.Title != null)
                    {
                        SearchDocument.current_job_title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                    }
                    SearchDocument.IndustryName = model.IndustryName;
                    SearchDocument.ZipCode = model.Zipcode;
                    SearchDocument.Latitude = model.Latitude;
                    SearchDocument.Longitude = model.Longitude;
                    SearchDocument.EducationlevelName = model.EducationlevelName;
                    SearchDocument.jobTypeId = Convert.ToString(model.JobTypeId);
                    SearchDocument.jobType = model.JobTypeName;
                    SearchDocument.profile_image = model.FileName;
                    if (model.location != null && model.location != "")
                    {
                        SearchDocument.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.location.Trim().ToLower());
                    }
                    SearchDocument.Description = Convert.ToString(model.description);
                    SearchDocument.DesiredTitle1 = model.DesiredTitle1;
                    SearchDocument.DesiredTitle2 = model.DesiredTitle2;
                    SearchDocument.Experience_Name = model.experienceName;
                    if (model.experience != null && model.experience.Trim() != "")
                    {
                        if (Convert.ToInt32(model.experience) > 0)
                        {
                            SearchDocument.experience = model.experience;
                        }
                        else
                        {
                            SearchDocument.experience = "0";
                        }
                    }
                    SearchDocument.statusid = 1;
                    SearchDocument.CurrentSalary = model.CurrentSalary;

                    SearchDocument.CurrentSalaryId = Convert.ToInt64(model.CurrentSalaryId);

                    SearchDocument.IndustryName = Convert.ToString(model.IndustryName);
                    SearchDocument.IndustryId = Convert.ToInt16(model.Industry);
                    SearchDocument.Candidateskill = model.Candidateskill;
                    SearchDocument.CandidateTag = model.CandidateTag;
                    //string folderPath1 = Server.MapPath("~/FileUpload/CandidateResume/") + model.Id + "/" + model.Resumefile;

                    //if (Directory.Exists(Server.MapPath("~/FileUpload/CandidateResume/") + model.Id + "//"))
                    //{
                    //    SearchDocument.Resume_Content = SolrIndex.GetTxtFromFile(folderPath1);
                    //}
                    SolrIndex.IndexCandidate(SearchDocument, 1, true);

                }

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AdminCandidateportfoliosave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminCandidateportfoliosave(CandidateModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.Candidateportfoliosave(model);
                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;
                    string[] myArray = new string[files.Count];
                    for (int i = 0; i < files.Count; i++)
                    {
                        myArray[i] = files[i].FileName.ToString();
                    }
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string folderPath = Server.MapPath("~/FileUpload/PortfolioImage/") + model.CandidateId;
                        Directory.CreateDirectory(folderPath);
                        fname = Path.Combine(folderPath, fname);
                        file.SaveAs(fname);
                    }

                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Admincreateawardscandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Admincreateawardscandidate(CandidateModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.createawardscandidate(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AdminCandididaterefencessave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminCandididaterefencessave(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Candididaterefencessave(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AdminCandidateEducationDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminCandidateEducationDelete(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CandidateEducationDelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AdminCandidateworkexperienceDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminCandidateworkexperienceDelete(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CandidateworkexperienceDelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Admindeleteskill
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Admindeleteskill(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Deleteskill(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AdminCandidateportfolioDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminCandidateportfolioDelete(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CandidateportfolioDelete(model);
                var filepath = Server.MapPath("~/FileUpload/PortfolioImage/") + model.CandidateId + '\\' + model.FileName;

                if (System.IO.File.Exists(filepath))
                {
                    System.IO.File.Delete(filepath);
                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AdminCandidateawardsDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminCandidateawardsDelete(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CandidateawardsDelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AdmincandidaterefrenceDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdmincandidaterefrenceDelete(CandidateModel model)
        {
            try
            {
                _IobjCandidate.candidaterefrenceDelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// UpdateInterviewschedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateInterviewschedule(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.UpdateInterviewschedule(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// InterViewdelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult InterViewdelete(ClientModel model)
        {
            try
            {
                _IobjAdmin.InterViewdelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Createassignpay
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Createassignpay(ClientModel model)
        {

            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.Createassignpay(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Createuploadresumesave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Createuploadresumesave(JobsModel model)
        {
            model.Password = "1234";
            _IobjAdmin.Createuploadresumesave(model);
            if (Request.Files.Count > 0)
            {
                if (model.StatusId == 1)
                {
                    HttpFileCollectionBase files = Request.Files;
                    string[] myArray = new string[files.Count];
                    for (int i = 0; i < files.Count; i++)
                    {
                        myArray[i] = files[i].FileName.ToString();
                    }
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string folderPath = Server.MapPath("~/FileUpload/CandidateResume/") + model.UserId;
                        Directory.CreateDirectory(folderPath);
                        fname = Path.Combine(folderPath, fname);
                        file.SaveAs(fname);
                    }
                }
            }
            // Create Candidate by admin (candidate submit by admin)
            SearchDocumentNew SearchDocument = new SearchDocumentNew();
            SearchDocument.id = Convert.ToString(model.UserId);
            SearchDocument.first_name = model.Name.Trim() + " ";
            SearchDocument.last_name = model.LastName;
            SearchDocument.full_name = model.Name + " " + model.LastName;
            SearchDocument.email = model.Email;
            SearchDocument.mobile = model.Phone;
            SearchDocument.created_by = Convert.ToInt64(1);
            SearchDocument.updated_by = Convert.ToInt64(1);
            SearchDocument.updated_date = DateTime.Now;
            SearchDocument.ProfileCheck_Id = 0;
            SearchDocument.statusid = 1;
            SearchDocument.IndustryName = "";
             
            SearchDocument.profile_image = "/FileUpload/candidatedefaultImage/No_image_available.PNG";
            SolrIndex.IndexCandidate(SearchDocument, 1, true);
            return Json(model, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// Updateemailsend
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Updateemailsend(EmailTempleteViewModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.Updateemailsend(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AddUpdateCampaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddUpdateCampaign(CampaignModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.AddUpdateCampaign(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// AddUpdateRole
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUpdateRole(RoleViewModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.AddUpdateRole(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// DeleteCampaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult DeleteCampaign(CampaignModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.DeleteCampaign(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// DeleteNewletter
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteNewletter(EnquiresViewModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.DeleteNewletter(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// alertunactiveJobbyId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult alertunactiveJobbyId(Alertmodel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.alertunactiveJobbyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Updatesharejobsstatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Updatesharejobsstatus(JobsModel model)
        {
            try
            {
                if (model.Ids != null)
                {
                    model.JobId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                _IobjAdmin.Updatesharejobsstatus(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// sendAdmingeneralmessages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult sendAdmingeneralmessages(ClientModel model)
        {
            try
            {
                model.fromId = Convert.ToInt64(Session["Id"]);
                model.Name = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
                _IobjAdmin.sendAdmingeneralmessages(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AdminUsermanage
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AdminUsermanage(UserManagmentmodel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);

                _IobjAdmin.AdminUsermanage(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// deleteUsers
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult deleteUsers(UserManagmentmodel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);

                _IobjAdmin.deleteUsers(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// pipelinemessagesendbyadmin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult pipelinemessagesendbyadmin(Candidateconversationmodel model)
        {
            try
            {
                model.Name = Convert.ToString(Session["FirstName"]) + ' ' + Convert.ToString(Session["LastName"]);
                _IobjAdmin.pipelinemessagesendbyadmin(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// generalmessages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult submitedprofile(Candidateconversationmodel model)
        {
            try
            {
                model.Id = Convert.ToInt64(Session["Id"]);
                model.AccountTypeId = 1;

                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                _IobjCandidate.submitedprofile(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// AdminNotification
        /// </summary>
        /// <returns></returns>
        public JsonResult AdminNotification()
        {
            ClientModel model = new ClientModel();
            try
            {
                model.CreatedBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.AdminNotification(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// savesendgeneralmessagebyadmin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult savesendgeneralmessagebyadmin(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.Name = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
                _IobjAdmin.savesendgeneralmessagebyadmin(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AutoCompleteClient
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AutoCompleteClient(string prefix)
        {
            ClientModel model = new ClientModel();
            try
            {
                model.ClientName = prefix;
                _IobjAdmin.AutoCompleteClient(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.clientlistcollection, JsonRequestBehavior.AllowGet);
        }

        #endregion 

        #region PartialViewResult

        /// <summary>
        /// emailpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult emailpopup(EmailTempleteViewModel model)
        {
            try
            {
                _IobjAdmin.emailpopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("emailpopup", model);
        }


        /// <summary>
        /// emaildetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult emaildetails(EmailTempleteViewModel model)
        {
            try
            {
                _IobjAdmin.emailpopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("emaildetails", model);
        }


        /// <summary>
        /// GetEmailTempleteById
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult GetEmailTempleteById(EmailTempleteViewModel model)
        {
            try
            {
                _IobjAdmin.GetEmailTempleteById(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("GetEmailTempleteById", model);
        }
         

        /// <summary>
        /// addnewrole
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult addnewrole(RoleViewModel model)
        {
            try
            {
                _IobjAdmin.addnewrole(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("addnewrole", model);
        }


        /// <summary>
        /// ClientContact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult ClientContact(ClientModel model)
        {
            _IobjAdmin.ClientContact(model);
            return PartialView("ClientContact", model);
        }

        /// <summary>
        /// replypopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult replypopup(EnquiresViewModel model)
        {
            // _IobjAdmin.getmessagebyId(model);
            return PartialView("replypopup", model);
        }


        /// <summary>
        /// Createclientpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Company_popup(ClientModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                _IobjAdmin.GetCompanyDetailById(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("Company_popup", model);
        }

        /// <summary>
        /// Createclientpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Createclientpopup(ClientModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                _IobjAdmin.GetCompanyDetailById(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("Createclientpopup", model);
        }


        /// <summary>
        /// MeetingActiveTabActiveTab
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult MeetingActiveTabActiveTab(Dashboardmodel model)
        {
            try
            {

                _IobjAdmin.MeetingActiveTab(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("MeetingActiveTabActiveTab", model);
        }

        /// <summary>
        /// AddCompanyToDoPopUp
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AddCompanyToDoPopUp(ClientModel model)
        {
            try
            {
                _IobjAdmin.AddCompanyToDoPopUp(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AddCompanyToDoPopUp", model);
        }


        /// <summary>
        /// InterviewSchedulepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult InterviewSchedulepopup(ClientModel model)
        {
            try
            {
                _IobjAdmin.InterviewSchedulepopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("InterviewSchedulepopup", model);
        }


        /// <summary>
        /// Interviewdetailpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Interviewdetailpopup(ClientModel model)
        {
            try
            {
                _IobjAdmin.InterviewSchedulepopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("Interviewdetailpopup", model);
        }

        /// <summary>
        /// ResumeBulkUploadPopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult ResumeBulkUploadPopup(JobsModel model)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("ResumeBulkUploadPopup", model);
        }


        /// <summary>
        /// AdminCandidateEducationpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AdminCandidateEducationpopup(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.CandidateEducationpopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AdminCandidateEducationpopup", model);
        }


        /// <summary>
        /// AdminCandidateworkexperiencepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AdminCandidateworkexperiencepopup(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.Candidateworkexperiencepopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AdminCandidateworkexperiencepopup", model);
        }


        /// <summary>
        /// AdminAddUpdateSkillsPopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AdminAddUpdateSkillsPopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.AddUpdateSkillsPopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AdminAddUpdateSkillsPopup", model);
        }


        /// <summary>
        /// AdminCandidateportfoliopopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AdminCandidateportfoliopopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Candidateportfoliopopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AdminCandidateportfoliopopup", model);
        }


        /// <summary>
        /// AdminCandidateAwardspopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AdminCandidateAwardspopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CandidateAwardspopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AdminCandidateAwardspopup", model);
        }


        /// <summary>
        /// AdminCandidaterefrencespopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AdminCandidaterefrencespopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Candidaterefrencespopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AdminCandidaterefrencespopup", model);
        }

        /// <summary>
        /// emailEditpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult emailEditpopup(EmailTempleteViewModel model)
        {

            try
            {
                _IobjAdmin.emailEditpopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return PartialView("emailEditpopup", model);
        }

        /// <summary>
        /// NewCampaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult NewCampaign(CampaignModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.NewCampaign(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("NewCampaign", model);
        }

        /// <summary>
        /// sharjobIdziprecuiter
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult sharjobIdziprecuiter(JobsModel model)
        {
            try
            {
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                _IobjAdmin.sharjobIdziprecuiter(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("sharjobIdziprecuiter", model);
        }

        /// <summary>
        /// messagesadmin_popup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult messagesadmin_popup(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("messagesadmin_popup", model);

        }
        #endregion
         

        #region ActionResult

        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        /// <summary>
        /// Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(Dashboardmodel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);

                _IobjAdmin.Dashboarddetail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        public ActionResult interviewsrequest()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View();
        }
        /// <summary>
        /// details
        /// </summary>
        /// <param name=" "></param>
        /// <returns></returns>
        public ActionResult Payment(PlansListModel model)
        { 
            try
            {
                _IobjCandidate.getAllPaymentHistory(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }
        /// <summary>
        /// paymenthistory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult paymenthistory(string Id ,string pid,string tid)
        {
            PlansListModel model = new PlansListModel();
            try
            { 
                model.UserId = Convert.ToInt64(EncryptDecrypt.Decrypt(Id));
                model.subscriptionId = pid;


                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _IobjCandidate.paymenthistory(model); 
                if (Convert.ToDateTime(DateTime.Now) < Convert.ToDateTime(model.ValidPlanDate))
                {
                    model.CheckDate = 1;
                }else
                {
                    model.CheckDate = 0;
                }
                model.tId = Convert.ToInt32(tid);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            model.pId = pid;
            return View(model);
        } 
        /// <summary>
        /// payment history
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult PaymentDetail(string Id)
        {
             
            return View();
        }



        public ActionResult candidaterequest(ClientModel model)
        {
            try
            {


                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.ClientSendenquery(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// test
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult test(Dashboardmodel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);

                _IobjAdmin.Dashboarddetail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// candidateprofile
        /// </summary>
        /// <returns></returns>
        public ActionResult candidateprofile()
        {
            return View();
        }

        /// <summary>
        /// setting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult setting(LoginModel model)
        {
            model.UserId = Convert.ToInt64(Session["Id"]);
            return View(model);
        }


        /// <summary>
        /// Client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Client(ClientModel model)
        {
            //_IobjAdmin.Client(model);
            return View(model);
        }


        /// <summary>
        /// ClientList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ClientList(ClientModel model)
        {
            try
            {
                _IobjAdmin.ClientList(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return View(model);
        }


        /// <summary>
        /// Company
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Company(ClientModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                 
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                var zipcode = "";
                HttpCall _httpCall = new HttpCall();
                if (model.Zip != null)
                {
                    if (model.MileId > 0)
                    {
                        //string key = ConfigurationManager.AppSettings["ZipCodeKey"].ToString();
                        //var str = _httpCall.HttpGet<List<ZipCodeViewModel>>(@"https://www.zipcodeapi.com/rest/" + key + "/radius.json/" + model.Zip + "/" + model.MileId + "/mile");
                        //var st = str.SelectMany(x => x.zip_code + ",");
                        //zipcode = new String(st.ToArray());
                        //zipcode = zipcode.Remove(zipcode.Length - 1);
                        CandidateModel model1 = new CandidateModel();
                        model1.CityName = model.Zip;
                        model1.MileId = model.MileId;
                        _IobjCandidate.getallzipcodeinradius(model1);

                        model.ZipCode = model1.Zipcode;
                    }
                    else
                    {
                        model.ZipCode = model.Zip;
                    }
                    
                    _IobjAdmin.ClientList(model);
                    model.checkzipcode = 1;
                }
                else
                {
                    _IobjAdmin.ClientList(model);
                    model.Zip = model.Location;
                }

                 
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return View(model);
        }


        /// <summary>
        /// ClientDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ClientDelete(ClientModel model)
        {
            try
            {
                _IobjAdmin.ClientDelete(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Clientdetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Clientdetails(ClientModel model)
        {
            model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
            _IobjAdmin.ClientProfileById(model);
            return View(model);
        }


        /// <summary>
        /// clientdetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult clientdetail(ClientModel model)
        {
            try
            {
                if (model.tid == 0)
                {
                    model.tid = 1;
                }
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                _IobjAdmin.clientdetail(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// email
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult email(EmailTempleteViewModel model)
        {
            _IobjAdmin.email(model);
            return View(model);
        }


        /// <summary>
        /// Rolelist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Rolelist(RoleListModel model)
        {
            _IobjAdmin.Role(model);
            return View(model);
        }


        /// <summary>
        /// Role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Role(RoleListModel model)
        {
            _IobjAdmin.Role(model);
            return View(model);
        }


        /// <summary>
        /// enquires
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult enquires(EnquiresViewModel model)
        { 
            model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
            model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
            model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
            model.typeId = 2;

            _IobjAdmin.enquires(model);
            return View(model);
        }



        /// <summary>
        /// pipeline
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult pipeline(ClientModel model)
        {
            if (model.Id == 0)
            {
                model.Id = 1;
            }

            _IobjAdmin.pipeline(model);
            return View(model);
        }

        


        /// <summary>
        /// profile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult profile(ProfileViewModel model)
        {
            model.locationKey = ConfigurationManager.AppSettings["locationKey"].ToString();
            model.UserId = Convert.ToInt64(Session["Id"]);
            _IobjAdmin.profile(model);
            return View(model);
        }

        /// <summary>
        /// shortlist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult shortlist(ClientModel model)
        {
            try
            {
                _IobjAdmin.shortlist(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return View(model);
        }

        /// <summary>
        /// ClientSendenquery
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ClientSendenquery(ClientModel model)
        {
            try
            {


                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.ClientSendenquery(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }



        public ActionResult interviewsrequestbycandidates(ClientModel model)
        {
            try
            {


                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.interviewsrequestbycandidates(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        public ActionResult interviewsrequestbycandidatesdetail(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                _Iclient.interviewsrequestbycandidatesdetail(model);
                
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// Clientchatdetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Clientchatdetail(ClientModel model)
        {
            try
            {
                model.AccountTypeId = Convert.ToInt64(Session["UsertypeId"]);
                model.UserId = Convert.ToInt64(Session["Id"]);
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                _Iclient.enquireydetails(model);
                model.Url = System.Configuration.ConfigurationManager.AppSettings["Url"].ToString() + model.cids;
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// EnquiresDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult EnquiresDetail(EnquiresViewModel model)
        {
            try
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                _IobjAdmin.getmessagebyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// PostJobs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult PostJobs(JobsModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                if (model.JIds != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.JIds));
                }

                if (model.Id == 0)
                {
                    model.SId = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    model.TId = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                }
                else
                {
                    model.SId = 0;
                    model.TId = 0;
                }


                _Iclient.Jobs(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// JobLists
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult JobLists(JobsModel model)
        {
            try
            {
                if (model.JobStatusId == 0)
                {
                    model.JobStatusId = 2;
                }
                model.UserId = Convert.ToInt64(Session["Id"]);

                model.accounttype = Convert.ToInt64(Session["UsertypeId"]);

                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                _Iclient.JobList(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// JobDetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult JobDetails(JobsModel model)
        {
            try
            {
                model.interviewStatus = model.Ids;
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                _Iclient.JobDetail(model);
                model.interviewStatus = model.Ids;
                
                model.PageUrl = System.Configuration.ConfigurationManager.AppSettings["PageUrl"].ToString() + EncryptDecrypt.encrypt(model.Id.ToString());
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// InterviewSceduleList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult InterviewSceduleList(ClientModel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.InterviewSceduleList(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// Assign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Assign(ClientModel model)
        {
            try
            {
                _IobjAdmin.getassignByEmail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// AssignList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult AssignList(ClientModel model)
        {
            try
            {

                _IobjAdmin.AssignList(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// sharedJob
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult sharedJob(JobsModel model)
        {
            try
            {
                if(model.Ids != null)
                {
                    model.ClientId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                model.pageno = model.pageno == null ? 1 : model.pageno;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.pageno - 1) * model.maxRows);


                _IobjAdmin.sharedJob(model);
                if (model.Ids != null)
                {
                    model.Ids =EncryptDecrypt.encrypt(Convert.ToString(model.ClientId));
                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));

            }
            return View(model);
        }


        /// <summary>
        /// sharedJobDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult sharedJobDetail(JobsModel model)
        {
            try
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));

                _Iclient.JobDetail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// SubmissionProfile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult SubmissionProfile(JobsModel model)
        {
            try
            {
                if (model.PipeLineId == 0)
                {
                    model.PipeLineId = 1;
                }
                if (model.JobStatusId == 0)
                {
                    model.JobStatusId = 2;
                }

                _IobjAdmin.SubmissionProfile(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// ClientDetailbyId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ClientDetailbyId(ClientModel model)
        {
            try
            {
                _Iclient.CompanyProfile(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// Campaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Campaign(CampaignModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.Campaign(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// addcampaign
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult addcampaign(CampaignModel model)
        {
            model.CreateBy = Convert.ToInt64(Session["Id"]);
            _IobjAdmin.NewCampaign(model);
            return View(model);
        }

        /// <summary>
        /// campaignhistory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult campaignhistory(CampaignModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.campaignhistory(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// NewLetter
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult NewLetter(EnquiresViewModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.NewLetter(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return View(model);
        }

        /// <summary>
        /// Alert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Alert(Alertmodel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.Alert(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// Users
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Users(UserManagmentmodel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                _IobjAdmin.Users(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// UserList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult UserList(UserManagmentmodel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);

                _IobjAdmin.UserList(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// messages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult messages(Candidateconversationmodel model)
        {


            try
            {

                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _IobjAdmin.messages(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return View(model);
        }



        /// <summary>
        /// messagesdetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult messagesdetail(Candidateconversationmodel model)
        {

            try
            {
                model.Name = Convert.ToString(Session["FirstName"]) + ' ' + Convert.ToString(Session["LastName"]);
                model.UserId = Convert.ToInt64(Session["Id"]);
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }

                _IobjAdmin.messagesdetail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// generalmessages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult generalmessages(ClientModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                model.ClientId = model.Id;

                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _IobjAdmin.GeneralMessages(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// generalmessagesdetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult generalmessagesdetails(ClientModel model)
        {
            try
            {
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjAdmin.generalmessagesdetails(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        public JsonResult GetSubJobByJId(JobsModel model)
        {
            try
            {
                _Iclient.GetSubJobByJId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.SubCategoryCollection, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetjobByCompanyIdId(JobsModel model)
        {
            try
            {
                _Iclient.GetjobByCompanyIdId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.SubCategoryCollection, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ResendActivationEmail(ClientModel model)
        {
            try
            {
                _Iclient.ResendActivationEmail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model);
        }
        public JsonResult ActivationEmailToContact(ClientModel model)
        {
            try
            {
                _IobjAdmin.ActivationEmailToContact(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model);
        }
        #endregion
         
    }
}