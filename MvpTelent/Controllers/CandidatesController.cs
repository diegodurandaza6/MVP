
using MvpTelent.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Core.Candidate;
using Web.Core.Candidate.Impl;
using Web.Core.Common;
using Web.Core.Common.Impl;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;
using Web.SolrClient;
using Web.SolrClient.Helpers;

namespace MvpTelent.Controllers
{

    [CustomAuthorization(AccountTypes = new long[] { 3 })]
    public class CandidatesController : AuthController
    {

        ICandidate _IobjCandidate = new CandidateService();
        ILogin _Ilogin = new LoginService();


        #region ActionResult

        /// <summary>
        /// Dashboard
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            CandidateModel model = new CandidateModel();
            model.UserId = Convert.ToInt64(Session["Id"]);
            _IobjCandidate.Dashboard(model);
            return View(model);
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                //  _IobjCandidate.candidatedetailbyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// profile
        /// </summary>
        /// <returns></returns>
        public ActionResult profile()
        {
            return View();
        }

        /// <summary>
        /// Setting
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Setting(CandidateModel model)
        {
            model.UserId = Convert.ToInt64(Session["Id"]);
            return View(model);
        }


        /// <summary>
        /// myprofile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult myprofile(CandidateModel model)
        {
            try
            {
                if (model.TabId == 0)
                {
                    model.TabId = 1;
                }
                model.Id = Convert.ToInt64(Session["Id"]);
                //_IobjCandidate.candidatedetailbyId(model);
                _IobjCandidate.CDetail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// confidentialprofile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult confidentialprofile(CandidateModel model)
        {
            try
            {
                model.Id = Convert.ToInt64(Session["Id"]);
                //_IobjCandidate.candidatedetailbyId(model);
                _IobjCandidate.CDetail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// MyappliedJob
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult MyappliedJob(JobsModel model)
        {
            try
            {
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.MyappliedJob(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// MySavedJobList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult MySavedJobList(JobsModel model)
        {
            try
            {
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.MySavedJobList(model);
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
        public ActionResult paymenthistory(PlansListModel model)
        {
            try
            {
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.paymenthistory(model);
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
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.messageslist(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }
        /// <summary>
        /// conversation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult conversation(Candidateconversationmodel model)
        {
            try
            {
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }

                if (model.JIds != null)
                {
                    model.JobId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.JIds));
                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.conversation(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// generalmessagelist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult generalmessagelist(Candidateconversationmodel model)
        {
            try
            {
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.generalmessagelist(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// generalmessagedetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult generalmessagedetail(Candidateconversationmodel model)
        {
            try
            {
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.generalmessagedetail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }
        #endregion 

        #region PartialViewResult

        /// <summary>
        /// CandidateVedio
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult CandidateVedio(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CandidateVediopopu(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("CandidateVedio", model);
        }

        /// <summary>
        /// AddUpdateSkillsPopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AddUpdateSkillsPopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.AddUpdateSkillsPopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AddUpdateSkillsPopup", model);
        }

        /// <summary>
        /// UpdateCandidateprofilepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult UpdateCandidateprofilepopup(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);

                model.Name = Convert.ToString(Session["Name"]);
                model.Phone = Convert.ToString(Session["Phone"]);
                model.Title = Convert.ToString(Session["Title"]);
                model.Email = Convert.ToString(Session["Email"]);
                //_IobjCandidate.UpdateCandidateprofilepopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("UpdateCandidateprofilepopup", model);
        }

        /// <summary>
        /// CandidateEducationpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult CandidateEducationpopup(CandidateModel model)
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
            return PartialView("CandidateEducationpopup", model);
        }




        /// <summary>
        /// Candidateworkexperiencepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Candidateworkexperiencepopup(CandidateModel model)
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
            return PartialView("Candidateworkexperiencepopup", model);
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
                _IobjCandidate.Interviewdetailpopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("Interviewdetailpopup", model);
        }

        /// <summary>
        /// CandidateAwardspopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult CandidateAwardspopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CandidateAwardspopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("CandidateAwardspopup", model);
        }

        /// <summary>
        /// Candidateportfoliopopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Candidateportfoliopopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Candidateportfoliopopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("Candidateportfoliopopup", model);
        }


        /// <summary>
        /// candidateprofile_popup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult candidateprofile_popup(CandidateModel model)
        {
            try
            {

                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";

                _IobjCandidate.candidateprofilepopup(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("candidateprofile_popup", model);
        }
        /// <summary>
        /// Candidaterefrencespopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Candidaterefrencespopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Candidaterefrencespopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("Candidaterefrencespopup", model);
        }


        /// <summary>
        /// Candidaterefrencespopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult LicensesCertificationspopup(CandidateModel model)
        {
            try
            {
                _IobjCandidate.LicensesCertificationspopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("LicensesCertificationspopup", model);
        }



        /// <summary>
        /// sendgeneralmessagespopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult sendgeneralmessagespopup(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("sendgeneralmessagespopup", model);
        }
        #endregion



        #region JsonResult


        /// <summary>
        /// UploadVideo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UploadVideo(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.UploadVideo(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// UpdateCandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateCandidate(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);

                _IobjCandidate.UpdateCandidateOnsolr(model);

                SearchDocumentNew SearchDocument = new SearchDocumentNew();
                SearchDocument.id = Convert.ToString(model.Id);

                SearchDocument.first_name = model.Name.Trim() + " ";
                SearchDocument.last_name = model.LastName;
                SearchDocument.full_name = model.Name + " " + model.LastName;
                SearchDocument.email = model.Email;
                SearchDocument.mobile = model.Phone;
                SearchDocument.created_by = Convert.ToInt64(model.Id);
                SearchDocument.updated_by = Convert.ToInt64(model.Id);
                SearchDocument.updated_date = DateTime.Now;
                SearchDocument.statusid = 1;
                SearchDocument.ProfileCheck_Id = Convert.ToInt16(model.ProfileCheck_Id);
                SearchDocument.current_job_title = model.Title.ToLower();
                SearchDocument.IndustryName = model.IndustryName;
                SearchDocument.ZipCode = model.Zipcode;

                SearchDocument.Latitude = model.Latitude;
                SearchDocument.Longitude = model.Longitude;

                SearchDocument.EducationlevelName = model.EducationlevelName;
                SearchDocument.jobTypeId = Convert.ToString(model.JobTypeId);
                SearchDocument.jobType = model.JobType;
                SearchDocument.profile_image = model.FileName;
                SearchDocument.location = model.location.ToLower();
                SearchDocument.Description = Convert.ToString(model.description);

                SearchDocument.Candidateskill = model.Candidateskill;
                SearchDocument.CandidateTag = model.CandidateTag;
                if (model.DesiredTitle1 != null && model.DesiredTitle1 != "")
                {
                    SearchDocument.DesiredTitle1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.DesiredTitle1.Trim().ToLower());
                }
                if (model.DesiredTitle2 != null && model.DesiredTitle2 != "")
                {
                    SearchDocument.DesiredTitle2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.DesiredTitle2.Trim().ToLower());
                }


                //string folderPath1 = Server.MapPath("~/FileUpload/CandidateResume/") + model.Id + "/" + model.Resumefile;
                //if (Directory.Exists(folderPath1))
                //{

                //    string ext = System.IO.Path.GetExtension(folderPath1).ToLower();
                //     SearchDocument.Resume_Content = SolrIndex.GetTxtFromFile(folderPath1);
                //}
                SolrIndex.IndexCandidate(SearchDocument, 1, true);


            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// createeducationcandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult createeducationcandidate(CandidateModel model)
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
        /// createeducationcandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult addupdatelicensescertification(CandidateModel model)
        {
            try
            {
                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.addupdatelicensescertification(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// StateList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult StateList(CandidateModel model)
        {
            try
            {
                _IobjCandidate.StateList(model);
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
        public JsonResult CityList(CandidateModel model)
        {
            try
            {
                _IobjCandidate.CityList(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.CityCollection, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// CandidateEducationDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CandidateEducationDelete(CandidateModel model)
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
        /// CandidateEducationDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult LicensesCertificationsDelete(CandidateModel model)
        {
            try
            {
                _IobjCandidate.LicensesCertificationsDelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// createworkexperiencecandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult createworkexperiencecandidate(CandidateModel model)
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
        /// interviewlistbycandidate
        /// </summary>
        /// <returns></returns>
        public JsonResult interviewlistbycandidate()
        {
            ClientModel model = new ClientModel();
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.interviewlistbycandidate(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model.interviewListCollection, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// CandidateworkexperienceDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CandidateworkexperienceDelete(CandidateModel model)
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
        /// createawardscandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult createawardscandidate(CandidateModel model)
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
        /// SkillAddUpdate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SkillAddUpdate(CandidateModel model1)
        {
            try
            {
                model1.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.SkillAddUpdate(model1);


                CandidateModel model = new CandidateModel();
                model.Id = model1.CandidateId;
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
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model1, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// CandidateawardsDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CandidateawardsDelete(CandidateModel model)
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
        /// Deleteskill
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Deleteskill(CandidateModel model)
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
        /// Candidateportfoliosave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Candidateportfoliosave(CandidateModel model)
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
        /// CandidateResumeUpload
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CandidateResumeUpload(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.CandidateResumeUpload(model);
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
                        string folderPath = Server.MapPath("~/FileUpload/CandidateResume/") + model.Id;
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
        /// CandidateportfolioDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CandidateportfolioDelete(CandidateModel model)
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





        /// <summary>
        /// Update_Candidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Update_Candidate(CandidateModel model)
        { 
            try
            { 
                if (string.IsNullOrEmpty(model.Zipcode) == false)
                {
                    var latlog = getlatlogbyZipCode(model.Zipcode);
                    if (latlog != "")
                    {
                        string[] latloglist = latlog.Split(',');
                        model.Latitude = latloglist[0];
                        model.Longitude = latloglist[1];
                        _IobjCandidate.CheckAndInsertZipCode(model);
                    }
                   
                } 

                model.CreateBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.UpdateCandidate(model);


                // (candidate Update by self on solr profile)
                model.Id = model.CreateBy;
                _IobjCandidate.UpdateCandidateOnsolr(model);
               
                Session["Name"] = model.Name.Trim() + " " + model.LastName;

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

                if (model.Longitude == " ")
                {
                    SearchDocument.Latitude = "";
                    SearchDocument.Longitude = "";
                }
                else
                {
                    SearchDocument.Latitude = model.Latitude;
                    SearchDocument.Longitude = model.Longitude;
                }
                 
                 
                SearchDocument.EducationlevelName = model.EducationlevelName;
                SearchDocument.jobTypeId = Convert.ToString(model.JobTypeId);
                SearchDocument.jobType = model.JobTypeName;
                SearchDocument.profile_image = model.FileName;
                if (model.location != null && model.location != "")
                {
                    SearchDocument.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.location.Trim().ToLower());
                }
                SearchDocument.Description = Convert.ToString(model.description);
                if (model.DesiredTitle1 != null && model.DesiredTitle1 != "")
                {
                    SearchDocument.DesiredTitle1 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.DesiredTitle1.Trim().ToLower());
                }
                if (model.DesiredTitle2 != null && model.DesiredTitle2 != "")
                {
                    SearchDocument.DesiredTitle2 = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.DesiredTitle2.Trim().ToLower());
                }
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
                
                SolrIndex.IndexCandidate(SearchDocument, 1, true);

                //Web.SolrMyCandidate.SolrIndex.UpdatefavouriteCandidate(SearchDocument.current_job_title,SearchDocument.location, model.Id, true);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));

            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ProfileImage_Upload
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ProfileImage_Upload(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.ProfileImageUpload(model);
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
                        string folderPath = Server.MapPath("~/FileUpload/CandidateImage/") + model.Id;
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
        /// Resume_Upload
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Resume_Upload(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.ResumeImageUpload(model);
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
                        string folderPath = Server.MapPath("~/FileUpload/CandidateResume/") + model.Id;
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
        /// Candididaterefencessave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Candididaterefencessave(CandidateModel model)
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
        /// candidaterefrenceDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult candidaterefrenceDelete(CandidateModel model)
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
        /// Candidateskillsvaluesave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Candidateskillsvaluesave(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Candidateskillsvaluesave(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AutoCompleteSkills
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AutoCompleteSkills(/*string prefix*/   CandidateModel model)
        {

            try
            {

                _IobjCandidate.AutoCompleteSkills(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.SkillCollection, JsonRequestBehavior.AllowGet);
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
        /// JobAppliedDeletebyId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult JobAppliedDeletebyId(JobsModel model)
        {
            try
            {
                _IobjCandidate.JobAppliedDeletebyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// JobSavedDeletebyId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult JobSavedDeletebyId(JobsModel model)
        {

            try
            {
                _IobjCandidate.JobSavedDeletebyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Candidateconversationsaved
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Candidateconversationsaved(Candidateconversationmodel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.Name = Convert.ToString(Session["FirstName"]) + ' ' + Convert.ToString(Session["LastName"]);
                _IobjCandidate.Candidateconversationsaved(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// generalmessageconversationsaved
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult generalmessageconversationsaved(Candidateconversationmodel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.Name = Convert.ToString(Session["FirstName"]) + ' ' + Convert.ToString(Session["LastName"]);
                _IobjCandidate.generalmessageconversationsaved(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// sendgeneralmessages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult sendgeneralmessages(ClientModel model)
        {
            try
            {
                model.fromId = Convert.ToInt64(Session["Id"]);
                model.Email = Session["Email"].ToString();
                model.Name = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
                _IobjCandidate.sendgeneralmessages(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// getallunreadmessage
        /// </summary>
        /// <returns></returns>
        public JsonResult getallunreadmessage()
        {
            ClientModel model = new ClientModel();
            try
            {
                model.CreatedBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.CandidateNnotification(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion




























    }
}
