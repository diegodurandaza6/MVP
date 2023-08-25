using IntelDataBase.HelperMethods;
using MvpTelent.Controllers;
using MvpTelent.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Core.Candidate;
using Web.Core.Candidate.Impl;
using Web.Core.Group;
using Web.Core.Group.Impl;
using Web.Model.Admin;
using Web.Model.Candidate;
using Web.Model.Common;
using Web.Model.Group;
using Web.Model.Paypal;
using Web.SolrClient;
using Web.SolrClient.Helpers;
using Web.SolrJobs;

namespace MvpTelent.Areas.Admin.Controllers
{
    [CustomAuthorization(DoDatabaseAuthorization = true)]
    public class CandidateController : BaseController
    {

        ICandidate _objICandidate = new CandidateService();
        IGroup _objGroup = new GroupService();

        #region ActionResult
        /// <summary>
        /// group
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult group(GroupListModel model)
        {
            _objGroup.GetGrouplist(model);

            return View(model);
        }

       



        /// <summary>
        /// details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult details(string Id)
        {
            GroupViewModel model = new GroupViewModel();
            try
            {

                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(Id));
                _objGroup.details(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }



        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Candidates
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Candidates(CandidateModel model)
        {
            //_objICandidate.Candidates(model);
            return View(model);
        }
        public PartialViewResult LicensesCertificationspopup(CandidateModel model)
        {
            try
            {
                _objICandidate.LicensesCertificationspopup(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("LicensesCertificationspopup", model);
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
                _objICandidate.addupdatelicensescertification(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
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
                _objICandidate.LicensesCertificationsDelete(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Plan
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Plan(PlanModel model)
        {
            try
            {
                _objICandidate.Plan(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// Applicant
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Applicant(CandidateModel model)
        {
            try
            {
                //if(model.JIds != null)
                //{
                //    model.JobId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.JIds));
                //}
                if (model.Id == 0)
                {
                    model.Id = 1;
                }
                if (model.jobStatus == 0)
                {
                    model.jobStatus = 2;
                }
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.Applicant(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// CadidateList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CandidateList(CandidateModel model)
        {
            try
            { 
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                 
                _objICandidate.CadidateList(model);

                HttpCall _httpCall = new HttpCall();
                if (model.MileId > 0)
                {

                    //string key = ConfigurationManager.AppSettings["ZipCodeKey"].ToString();
                    //var str = _httpCall.HttpGet<List<ZipCodeViewModel>>(@"https://www.zipcodeapi.com/rest/" + key + "/radius.json/" + model.CityName + "/" + model.MileId + "/mile");
                    //var st = str.SelectMany(x => x.zip_code + ",");
                    //zipcode = new String(st.ToArray());
                    //zipcode = zipcode.Remove(zipcode.Length - 1);

                    _objICandidate.getallzipcodeinradius(model);
                    model.checkzipcode = 1;

                }
                else
                {
                    model.MileId = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                }


                SolrSearch objSolrSearch = new SolrSearch();
                var searchOption = new Web.SolrClient.Helpers.IndexedSearchOption();
                searchOption.StatusId = 1;
                searchOption.SearchType = 1;
                int TotalCount = 0;
                string msg = "";
                if (model.Email != null)
                {
                    searchOption.Email = model.Email.ToLower();
                }
                searchOption.Phone = model.Phone; 
                searchOption.ZipCode = model.Zipcode;
                searchOption.Title = model.Title;
                searchOption.Keyword = model.Keyword;
                if (model.Name != null)
                {
                    searchOption.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Name.Trim().ToLower());
                }

                if (model.Title != null)
                {
                    searchOption.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                    model.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                }
                if (model.MileId != 0)
                {
                    if (model.CityName != null)
                    {
                        searchOption.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.CityName.Trim().ToLower());
                    }
                } 

                model.CandiateList = objSolrSearch.ExecuteSearchAsSearchResult_Admin(searchOption, Convert.ToInt32(model.CurrentPageIndex), model.maxRows, out TotalCount, out msg);
              
                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
                 
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        } 

        /// <summary>
        /// generalmessages
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult submitedprofiledetail(Candidateconversationmodel model)
        {
            try
            {
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }

                model.ClientId = 1;
                model.AccountTypeId = 1; 
                _objICandidate.submitedprofiledetail(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// GetJobOnwerDetailById
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetJobOnwerDetailById(Candidateconversationmodel model)
        {

            try
            {
                
                _objICandidate.GetJobOnwerDetailById(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Clientlogoupdate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult submitedMessageprofile(Candidateconversationmodel model)
        {

            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.submitedMessageprofile(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        } 
        /// <summary>
        /// CandidateDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CandidateDetail(CandidateModel model)

        {
            try
            {
                if (model.TabId == 0)
                {
                    model.TabId = 1;
                }
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                _objICandidate.CDetail(model);
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\log\\log.txt"))
                {
                    writer.WriteLine(ex.Message);
                }
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// Detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        public ActionResult Detail(CandidateModel model)
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
                _objICandidate.candidatedetailbyId(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// CDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CDetail(CandidateModel model)
        {
            try
            {
                if (model.Ids != null)
                {

                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }

                _objICandidate.CDetail(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// CDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult detailedprofile(string Ids, string JIds)
        {
            CandidateModel model = new CandidateModel();
            try
            { 
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(Ids));
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.CandidateDetailsbyId(model);

                model.Ids = Ids;
                if (JIds != null)
                {
                    model.JIds = JIds;
                    model.JobId = Convert.ToInt64(EncryptDecrypt.Decrypt(JIds));  
                } 
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        } 

        /// <summary>
        /// CDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult confidentialprofile(string Ids)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(Ids));
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.CandidateDetailsbyId(model);
                model.Ids = Ids;
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        } 

        #endregion


        #region PartialViewResult

        /// <summary>
        /// GroupPopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult GroupPopup(GroupViewModel model)
        {
            try
            {
                _objGroup.GetGroupById(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("GroupPopup", model);
        }

        /// <summary>
        /// GroupMovePopup
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PartialViewResult GroupMovePopup(Int64 Id)
        {
            GroupListModel model = new GroupListModel();
            try
            {
                model.Id = Id;
                _objGroup.GetGrouplist(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return PartialView("GroupMovePopup", model);
        }

        /// <summary>
        /// CreateCandidatepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult CreateCandidatepopup(CandidateModel model)
        {
            try
            {

                _objICandidate.Candidates(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("CreateCandidatepopup", model);
        }

        /// <summary>
        /// candidateprofilepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult candidateprofilepopup(CandidateModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                _objICandidate.candidateprofilepopup(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("candidateprofilepopup", model);
        }

        /// <summary>
        /// PlanDetailpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult PlanDetailpopup(PlanModel model)
        {
            try
            {

                //_objICandidate.Plan(model);
                _objICandidate.PlanCreatepopup(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("PlanDetailpopup", model);
        }
        /// <summary>
        /// CandidatesharedJobpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult CandidatesharedJobpopup(CandidateModel model)
        {
            try
            {
                _objICandidate.CandidatesharedJobpopup(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return PartialView("CandidatesharedJobpopup", model);
        }

        /// <summary>
        /// getsharedjobbyclientid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns> 
        public JsonResult getsharedjobbyclientid(CandidateModel model)
        {
            try
            {
                _objICandidate.getsharedjobbyclientid(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// interviewStatusPopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult interviewStatusPopup(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.interviewStatusPopup(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("interviewStatusPopup", model);
        }

        /// <summary>
        /// PlanCreatepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult PlanCreatepopup(PlanModel model)
        {
            try
            {
                _objICandidate.PlanCreatepopup(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("PlanCreatepopup", model);
        }
        #endregion


        #region JsonResult


        /// <summary>
        /// CreateGroup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateGroup(GroupViewModel model)
        {
            try
            {
                model.CreatedBy = Convert.ToInt64(Session["Id"]);
                _objGroup.CreateGroup(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// removeingroup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult removeingroup(GroupViewModel model)
        {
            try
            {
                _objGroup.removeingroup(Convert.ToString(model.Id));
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ChnageGroupStatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ChnageGroupStatus(GroupViewModel model)
        {
            try
            {
                _objGroup.ChnageGroupStatus(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AddInGroup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AddInGroup(GroupViewModel model)
        {
            try
            {
                model.CreatedBy = Convert.ToInt64(Session["Id"]);
                _objGroup.AddInGroup(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// CreateCandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateCandidate(CandidateModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    Random random = new Random();
                    model.Password = Convert.ToString(random.Next(60000, 120000));
                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.CreateCandidate(model);

                if (model.StatusId == 2)
                {
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

                    // Create Candidate by admin
                    SearchDocumentNew SearchDocument = new SearchDocumentNew();
                    SearchDocument.id = Convert.ToString(model.Id);
                    SearchDocument.first_name = model.Name.Trim();
                    SearchDocument.last_name = model.LastName;
                    SearchDocument.full_name = model.Name + " " + model.LastName;
                    SearchDocument.email = model.Email;
                    SearchDocument.mobile = model.Phone;
                    SearchDocument.created_by = Convert.ToInt64(1);
                    SearchDocument.updated_by = Convert.ToInt64(1);
                    SearchDocument.updated_date = DateTime.Now;
                    SearchDocument.statusid = 1;
                    SearchDocument.current_job_title = model.Title;
                    SearchDocument.IndustryName = "";

                    SearchDocument.ProfileCheck_Id = 0;

                    SearchDocument.CityName = "";
                    SearchDocument.ZipCode = "";
                    SearchDocument.EducationlevelName = "";
                    SearchDocument.profile_image = "/FileUpload/candidatedefaultImage/No_image_available.PNG";
                    SolrIndex.IndexCandidate(SearchDocument, 1, true);
                }



            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            model.Ids = EncryptDecrypt.encrypt(Convert.ToString(model.Id));

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ApplicantDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ApplicantDelete(CandidateModel model)
        {
            model.UserId = Convert.ToInt32(Session["Id"]);
            _objICandidate.ApplicantDelete(model);

            return Json(1, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// CandidateDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CandidateDelete(CandidateModel model)
        {
            try
            {
                _objICandidate.CandidateDelete(model);

                Web.SolrClient.SolrIndex.DeleteCandidateIndex(model.Id);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Candidatetagvalue
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Candidatetagvalue(Tagsmodel model1)
        {
            try
            {
                model1.CreateBy = Convert.ToInt64(Session["Id"]);
                _objICandidate.Candidatetagvalue(model1);

                // (candidate Update by admin on solr profile)


                if (model1.tagtype_Id == 0)
                {
                    ICandidate _IobjCandidate = new CandidateService();
                    CandidateModel model = new CandidateModel();
                    model.Id = model1.CId;
                    _IobjCandidate.UpdateCandidateOnsolr(model);

                    if (model.Name != null)
                    {
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
                    }
                }



            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model1, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// AutoCompleteCandidatetags
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AutoCompleteCandidatetags(string prefix)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.AccountType = 1;
                model.CandidateTag = prefix;
                _objICandidate.AutoCompleteCandidatetags(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// AutoCompleteCandidatetags
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AutoCompleteCompanytags(string prefix)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.CandidateTag = prefix;
                model.AccountType = 2;
                _objICandidate.AutoCompleteCandidatetags(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.candidatetagvaluecollection, JsonRequestBehavior.AllowGet);
        }





        /// <summary>
        /// deletecandidatetag
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult deletecandidatetag(CandidateModel model)
        {

            try
            {
                _objICandidate.deletecandidatetag(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
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
        /// UpdateCandidate
        /// </summary>
        /// <param name="model1"></param>
        /// <returns></returns>
        public JsonResult UpdateCandidate(CandidateModel model1)
        {
            try
            {
                if (string.IsNullOrEmpty(model1.Zipcode) == false)
                {
                    var latlog = getlatlogbyZipCode(model1.Zipcode);

                    if (latlog != "")
                    {
                        string[] latloglist = latlog.Split(',');
                        model1.Latitude = latloglist[0];
                        model1.Longitude = latloglist[1];
                        _objICandidate.CheckAndInsertZipCode(model1);
                    } 
                }
                model1.CreateBy = Convert.ToInt64(Session["Id"]);
                _objICandidate.UpdateCandidate(model1);

                CandidateModel model = new CandidateModel();
                model.Id = model1.Id;
                _objICandidate.UpdateCandidateOnsolr(model);

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


            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Interviewstatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Interviewstatus(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.Interviewstatus(model);
            }
            catch (Exception ex)
            {

            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// CreatePlan
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CreatePlan(PlanModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                 
                string[] priceProductId = CreatePrice(Convert.ToInt64(model.Price),model.Name);
                model.StripePriceid = priceProductId[0];
                model.StripeProductId = priceProductId[1];
                _objICandidate.CreatePlan(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
        public string[] CreatePrice(long? price, string PlanName)
        { 
            long? Amount = price * 100;
           
            var Product_options = new ProductCreateOptions
            {
                Name = "Purchase "+ PlanName + " Plan",
               DefaultPriceData = new ProductDefaultPriceDataOptions
                {
                    UnitAmount = Amount,
                    Currency = "usd", 
                },
                Expand = new List<string> { "default_price" },
            };
            var Product_service = new ProductService();
            var product = Product_service.Create(Product_options);
            var ProductId = product.Id;

            var Price_options = new PriceCreateOptions
            {
                 
                Product = ProductId,
                UnitAmount = Amount,
                Currency = "usd",
                Recurring = new PriceRecurringOptions
                {
                    Interval = "month",
                    IntervalCount = 1,
                }
            };

            var Price_service = new PriceService();
            var Price = Price_service.Create(Price_options);


            String[] arr = new String[2];
            arr[0] = Price.Id;
            arr[1] = ProductId;
            return arr;

             
        }

        /// <summary>
        /// PlanDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult PlanDelete(PlanModel model)
        {
            try
            {

                _objICandidate.PlanDelete(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AddSharedJobcandidatebyId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AddSharedJobcandidatebyId(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.AddSharedJobcandidatebyId(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// SubmitCandidateProfile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SubmitCandidateProfile(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.SubmitCandidateProfile(model);

            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PlanActiveInactive(PlanModel model)
        {
            try
            {
                _objICandidate.PlanActiveInactive(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model);
        }

        #endregion



    }
}