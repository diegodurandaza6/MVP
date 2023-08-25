using MvpTelent.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
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
using Web.Core.Common;
using Web.Core.Common.Impl;
using Web.Core.Payment;
using Web.Core.Payment.Impl;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;
using Web.SolrJobs;
using Web.SolrJobs.Helpers; 
using Web.SolrClient.Helpers;
using SolrSearch = Web.SolrClient.SolrSearch;
using System.Data;

namespace MvpTelent.Controllers
{
    [CustomAuthorization(AccountTypes = new long[] { 2 })]
    public class ClientController : AuthController
    {
        ILogin _Ilogin = new LoginService();
        IClient _Iclient = new ClientService();
        ICandidate _IobjCandidate = new CandidateService();
        IAdmin _IobjAdmin = new AdminService();
        ICandidate _objICandidate = new CandidateService();
        IPayment _objPayment = new PaymentService();

        #region ActionResult
        /// <summary>
        /// Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Details(ClientModel model)
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

            }

            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(ClientModel model)
        {
            model.UserId = Convert.ToInt64(Session["Id"]);
            return View(model);
        }

        /// <summary>
        /// payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult payment(PaymentViewModel model)
        {
            model.UserId = Convert.ToInt64(Session["Id"]);
            _objPayment.GetPlanById(model);
            return View(model);
        }

        /// <summary>
        /// publicprofile
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult publicprofile(string Id)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(Id));
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Ilogin.CandidateDetailsbyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// ClientenquireyList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ClientenquireyList(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _Iclient.ClientenquireyList(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// myfavourite
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult myfavorite(CandidateModel model)
        {
            try
            {
                if (model.mile == 0)
                {
                    model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                }

                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                model.Id = Convert.ToInt64(Session["Id"]);
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _Iclient.myfavourite(model);

                 
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        public PartialViewResult myfavoritePartialView(CandidateModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                model.Id = Convert.ToInt64(Session["Id"]);
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _Iclient.myfavourite(model);
                 
                if (model.mile == 0)
                {
                    model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                }

                Web.SolrMyCandidate.SolrSearch objSolrSearch = new Web.SolrMyCandidate.SolrSearch();
                var searchOption = new Web.SolrMyCandidate.Helpers.IndexedSearchOption();
                searchOption.SearchType = 1;
                int TotalCount = 0;
                string msg = "";
                searchOption.ProfileCheckId = 1;
                searchOption.UserId = Convert.ToInt64(Session["CompanyId"]);
                if (model.Title != null)
                {
                    searchOption.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                }
                searchOption.Keyword = model.Keyword;
                if (model.location != null)
                {
                    searchOption.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.location.Trim().ToLower());
                }
                searchOption.Jobtype = model.JobTypeName;
                searchOption.Jobcatagory = model.JobCategoryName;
                searchOption.experienceIds = model.experienceIds;
                searchOption.educationlavel = model.educationlevel;
                searchOption.ZipCode = Convert.ToString(model.Zipcode);
                searchOption.Miles = model.mile;
                GetfavoriteCandidateList(model, objSolrSearch, searchOption, out TotalCount, out msg);
                 
                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("myfavoritePartialView", model);
        }
        private void GetfavoriteCandidateList(CandidateModel model, Web.SolrMyCandidate.SolrSearch objSolrSearch, Web.SolrMyCandidate.Helpers.IndexedSearchOption searchOption, out int TotalCount, out string msg)
        {
            var result = new List<Web.SolrMyCandidate.Helpers.SearchDocumentResultForView>();
            msg = null;
            TotalCount = 0;
            var pageindex = Convert.ToInt32(model.CurrentPageIndex);
            if (string.IsNullOrEmpty(model.Zipcode))
            {
                //DO AS BEFORE. USE PAGINATION ON SOLR

                model.MyCandiateList = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, pageindex, model.maxRows, out TotalCount, out msg);
                model.MyCandiateList = model.MyCandiateList.OrderByDescending(x => x.CurrentSalaryId).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();

            }
            else
            {

                var zips = GetNearByZipCodewithlatlong(model.mile, Convert.ToString(model.Zipcode));

                searchOption.ZipCode = string.Join(",", zips.Select(x => x.ZipCodeWithZero).ToList());

                var sessionKey = $"f=1;M={model.mile};C={model.location};Z={model.Zipcode};Ti={model.Title};Key={model.Keyword};" +
                    $"jt={model.JobTypeName};JC={model.JobCategoryName};Eid={model.experienceId};I={model.JobCategoryName};El={model.educationlevel};" +
                    $"GId={model.groupcandidateId};";
                if (Session[sessionKey] == null)
                {
                    var completeCandidateList = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg)
                        .Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();

                    var zip = FindZipCodewithlatlong(Convert.ToString(model.Zipcode));

                    completeCandidateList.ForEach(x => x.miles_range = Convert.ToDecimal(HaversineFormula.Distance(zip.lat, zip.log, Convert.ToDouble(x.Latitude), Convert.ToDouble(x.Longitude))));

                    Session[sessionKey] = completeCandidateList;
                }
                var candidates = Session[sessionKey] as List<Web.SolrMyCandidate.Helpers.SearchDocumentResultForView>;
                TotalCount = candidates.Count;

                model.MyCandiateList = candidates.OrderBy(x => x.miles_range).OrderBy(x => x.CurrentSalaryId).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();


            }


        }

        private IEnumerable<ZipCodeVIewModel> GetAllZipCodewithlatlong()
        {
            if (Session["usazctas"] == null)
            {
                Session["usazctas"] = _Ilogin.GetAllZipCodewithlatlong();
            }
            return Session["usazctas"] as IEnumerable<ZipCodeVIewModel>;
        }
        private ZipCodeVIewModel FindZipCodewithlatlong(string zip)
        {
            var Zipcodes = GetAllZipCodewithlatlong();
            return Zipcodes.FirstOrDefault(x => x.ZipCodeWithZero == zip);
        }
        private IEnumerable<ZipCodeVIewModel> GetNearByZipCodewithlatlong(long radius, string zipcode)
        {
            var Zipcodes = GetAllZipCodewithlatlong();
            var zip = Zipcodes.FirstOrDefault(x => x.ZipCodeWithZero == zipcode);

            var result = Zipcodes.Where(x => HaversineFormula.Distance(zip.lat, zip.log, x.lat, x.log) <= radius)
                .Select(x => new { Distance = HaversineFormula.Distance(zip.lat, zip.log, x.lat, x.log), Codes = x })
                .OrderBy(x => x.Distance)
                .Select(x => x.Codes);
            return result;
        }




        /// <summary>
        /// CompanyProfile
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CompanyProfile(ClientModel model)
        {

            model.UserId = Convert.ToInt64(Session["Id"]);

            model.CompanyId = Convert.ToInt64(Session["CompanyId"]);
            _Iclient.CompanyProfile(model);
            Session["Image"] = model.FilePath;
            return View(model);
        }



        /// <summary>
        /// Candidate Search
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Candidate(CandidateListModel model)
        {
            try
            {
                model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows); 
                _IobjCandidate.GetAllCandidateList(model); 
                if (Session["UsertypeId"] != null)
                {
                    model.accounttype = Convert.ToInt64(Session["UsertypeId"]);
                    model.Id = Convert.ToInt64(Session["Id"]);
                }
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);


               
                SolrSearch objSolrSearch = new SolrSearch();
                var searchOption = new Web.SolrClient.Helpers.IndexedSearchOption();
                searchOption.SearchType = 1;
                int TotalCount = 0;
                string msg = "";
                searchOption.ProfileCheckId = 1;

                GetCandidateList(model, objSolrSearch, searchOption, out TotalCount, out msg);

                string CandidateId = "";
                for (var i = 0; i < model.CandiateList.Count; i++)
                {
                    CandidateId = CandidateId += model.CandiateList[i].id + ",";
                }
                model.CandidateIds = CandidateId;
                DataTable dt = _IobjCandidate.getallFavoritescandidatelistByClient(model);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        foreach (var item in model.CandiateList.Where(w => w.id == dt.Rows[i]["CandidateId"].ToString()))
                        {
                            item.IsFavorites = 1;
                        }
                    }
                }
                if (model.Zip == null)
                {
                    if (model.salery == 2 || model.salery == 0)
                    {
                        model.CandiateList = model.CandiateList.OrderBy(x => x.current_job_title).OrderByDescending(X => X.CurrentSalaryId).ToList();
                        model.salery = 2;
                    }
                    else
                    {
                        model.CandiateList = model.CandiateList.OrderBy(x => x.current_job_title).OrderBy(X => X.CurrentSalaryId).ToList();
                    }
                }
                else
                {
                    model.CandiateList = model.CandiateList.OrderByDescending(x => x.CurrentSalaryId).OrderBy(x => x.miles_range).ToList();
                    model.salery = 2;
                }

                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
                 
                CandidateModel objmodel = new CandidateModel();
                objmodel.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                objmodel.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                objmodel.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                Web.SolrMyCandidate.SolrSearch objfavoriteSolrSearch = new Web.SolrMyCandidate.SolrSearch();
                var favoritesearchOption = new Web.SolrMyCandidate.Helpers.IndexedSearchOption();
                favoritesearchOption.SearchType = 1;
                favoritesearchOption.UserId = Convert.ToInt64(Session["CompanyId"]);
                int favoriteTotalCount = 0;

                favoritesearchOption.ProfileCheckId = 1;
                favoritesearchOption.UserId = Convert.ToInt64(Session["CompanyId"]);

                GetfavoriteCandidateList(objmodel, objfavoriteSolrSearch, favoritesearchOption, out favoriteTotalCount, out msg);

                model.favoriteTotalCount = favoriteTotalCount;




            }
            catch (Exception ex)
            {

            }
            return View(model);
        }
        private void GetCandidateList(CandidateListModel model, SolrSearch objSolrSearch, Web.SolrClient.Helpers.IndexedSearchOption searchOption, out int TotalCount, out string msg)
        {
            var result = new List<Web.SolrClient.Helpers.SearchDocumentResultForView>();
            msg = null;
            TotalCount = 0;
            var pageindex = Convert.ToInt32(model.CurrentPageIndex);
            if (string.IsNullOrEmpty(model.Zip))
            {
                //DO AS BEFORE. USE PAGINATION ON SOLR
                model.CandiateList = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 2000, out TotalCount, out msg); 
                model.CandiateList = model.CandiateList.OrderByDescending(x => x.CurrentSalaryId).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();
           
            }
            
        } 

        /// <summary>
        /// IdDecrypt
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        private string IdDecrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
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
                model.Id = Convert.ToInt64(Session["CompanyId"]);
                model.AccountTypeId = 2;

                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                _objICandidate.submitedprofile(model);
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
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                model.AccountTypeId = 2;

                _objICandidate.submitedprofiledetail(model);
            }
            catch (Exception ex)
            {
                _objICandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
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
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// enquireydetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult enquireydetails(ClientModel model)
        {
            try
            {
                // _Iclient.enquireydetails(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// applicant       
        /// /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult applicant(CandidateModel model)
        {
            try
            {
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
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _Iclient.Applicant(model);

               
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\log\\log.txt"))
                {
                    writer.WriteLine(ex.Message);
                }
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// ShortList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ShortList(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.ShortList(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// Jobs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Jobs(JobsModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                if (model.Ids != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                    model.SId = 0;
                    model.TId = 0;
                }
                else
                {
                    model.SId = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                    model.TId = model.SId;
                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.Jobs(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// JobList
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult JobList(JobsModel model)
        {
            try
            {
                if (model.JobStatusId == 0)
                {
                    model.JobStatusId = 2;
                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _Iclient.JobList(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// JobDetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult JobDetail(JobsModel model)
        {
            try
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                _Iclient.JobDetail(model);
                model.PageUrl = System.Configuration.ConfigurationManager.AppSettings["PageUrl"].ToString() + EncryptDecrypt.encrypt(model.Id.ToString());

            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\log\\log.txt"))
                {
                    writer.WriteLine(ex.Message);
                }
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>Quote
        /// Qdetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Qdetail()
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

        /// <summary>Quote
        /// detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult detail(CandidateModel model)
        {
            try
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                model.CompanyId = Convert.ToInt64(Session["CompanyId"]);
                model.JobId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.JIds));
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.candidatedetailbyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// interviewschedulelist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult interviewschedulelist(ClientModel model)
        {
            try
            {
                
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.ClientId = Convert.ToInt64(Session["CompanyId"]); 
                if (model.JIds != null)
                { model.JobId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.JIds));  }  
                string Todaydate = DateTime.Now.ToString("yyyy/MM/dd"); 
                DateTime startDate = Convert.ToDateTime(Todaydate);
                DateTime LastDayofWeek = startDate;
                DayOfWeek dw = startDate.DayOfWeek;
                switch (dw)
                {
                    case DayOfWeek.Monday:
                        LastDayofWeek = startDate.AddDays(6);
                         break;
                    case DayOfWeek.Tuesday:
                        LastDayofWeek = startDate.AddDays(5);
                         break;
                    case DayOfWeek.Wednesday:
                        LastDayofWeek = startDate.AddDays(4); 
                        break;
                    case DayOfWeek.Thursday:
                        LastDayofWeek = startDate.AddDays(3); 
                        break;
                    case DayOfWeek.Friday:
                        LastDayofWeek = startDate.AddDays(2); 
                        break;
                    case DayOfWeek.Saturday:
                        LastDayofWeek = startDate.AddDays(1); 
                        break;
                    case DayOfWeek.Sunday:
                        LastDayofWeek = startDate;
                        break;
                } 
                // month date
                DateTime now = DateTime.Now;
                var stqartDate = new DateTime(now.Year, now.Month, 1);
                var endDate = stqartDate.AddMonths(1).AddDays(-1); 
                if (model.TypeId == 1)
                {
                    model.fromdate = Todaydate;
                    model.todate = Todaydate;
                }
                else if (model.TypeId == 2 )

                {
                    model.fromdate = Todaydate;
                    model.todate = LastDayofWeek.ToString("yyyy/MM/dd");
                }
                else if (model.TypeId == 3 || model.TypeId == 0)
                {
                    model.fromdate = Todaydate;
                    model.todate = endDate.ToString("yyyy/MM/dd");
                    model.TypeId = 3;
                }
                else if (model.TypeId == 4)
                {
                    DateTime today = DateTime.Now;
                    var Date = new DateTime(today.Year, today.Month, 1);
                    model.fromdate = Todaydate;
                    model.todate = Date.AddMonths(1000).AddDays(-1).ToString("yyyy/MM/dd");
                    model.TypeId = 4;
                }

                // upcoming Interview List
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                // Completed Interview List paging
                model.pId = model.pId == null ? 1 : model.pId;
                model.CompletedmaxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.CompletedOffsetId = Convert.ToInt64((model.pId - 1) * model.maxRows);


                if (model.Id==0)
                { model.Id = 3; }
                _IobjCandidate.Clientinterviewscedulelist(model);
                  
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\log\\log.txt"))
                {
                    writer.WriteLine(ex.Message);
                }
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
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _IobjCandidate.paymenthistory(model);
                if (Convert.ToDateTime(DateTime.Now) < Convert.ToDateTime(model.ValidPlanDate))
                {
                    model.CheckDate = 1;
                }
                else
                {
                    model.CheckDate = 0;
                }

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// SharedJobCount
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult SharedJobCount(JobsModel model)
        {
            try
            {
                model.JobId = 17;
                _Iclient.SharedJobCount(model);
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
        /// <returns></returns>
        public ActionResult test()
        {
            return View();
        }


        /// <summary>
        /// calenderdemo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult calenderdemo(ClientModel model)
        {
            return View(model);
        }

        /// <summary>
        /// dashboard
        /// </summary>
        /// <returns></returns>
        public ActionResult dashboard()
        {
            ClientModel model = new ClientModel();
            model.UserId = Convert.ToInt64(Session["Id"]);
            model.ClientId = Convert.ToInt64(Session["CompanyId"]);
            _Iclient.dashboard(model);
            return View(model);
        }

        /// <summary>
        /// mycandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult mycandidate(CandidateModel model)
        {
            try
            {
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.mycandidate(model);

                SolrSearch objSolrSearch = new SolrSearch();
                var searchOption = new Web.SolrMyCandidate.Helpers.IndexedSearchOption();
                searchOption.SearchType = 1;
                int TotalCount = 0;
                string msg = "";
                searchOption.ProfileCheckId = 1;
                searchOption.Keyword = model.Keyword;
                searchOption.location = model.location;
                searchOption.Title = model.Title;

                // searchOption.InterviewSID  = model.InterviewSId;

                searchOption.CandidateType_Id = "1";
                searchOption.UserId = Convert.ToInt64(Session["Id"]);

                searchOption.location = model.location;

                // if (model.Keyword != null || model.location != null || model.Title != null)

                //model.MyCandiateList = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, Convert.ToInt32(model.CurrentPageIndex), model.maxRows, out TotalCount, out msg);

                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
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
                //if (model.JIds != null)
                //{
                //    model.jId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.JIds));
                //}
                model.UserId = Convert.ToInt64(Session["Id"]);

                if (model.CId != null)
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.CId));
                }
                _Iclient.conversation(model);
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
        public ActionResult messages(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _Iclient.messages(model);
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("C:\\inetpub\\wwwroot\\log\\log.txt"))
                {
                    writer.WriteLine(ex.Message);
                }
            }
            return View(model);
        }


        /// <summary>
        /// messagesdetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult messagesdetails(ClientModel model)
        {
            if (model.Ids != null)
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
            }
            model.UserId = Convert.ToInt64(Session["Id"]);
            _Iclient.messagesdetails(model);
            return View(model);
        }





        /// <summary>
        /// Pipelinemessageslist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Pipelinemessageslist(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _Iclient.Pipelinemessageslist(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return View(model);
        }

        #endregion


        #region JsonResult

        /// <summary>
        /// ClientSendenquery
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ClientSendenquery(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.ClientSendenquery(model);
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
                        string folderPath = Server.MapPath("~/FileUpload/Interviewrequest/") + model.UserId;
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
            return Json(model.Status, JsonRequestBehavior.AllowGet);
        }





        /// <summary>
        /// candidateshortlist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult candidateshortlist(ClientModel model)
        {
            try
            {
                _Iclient.candidateshortlist(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// favoritecandidate
        /// </summary>
        /// <param name="model1"></param>
        /// <returns></returns>
        public JsonResult favoritecandidate(ClientModel model1)
        {
            try
            { 
                model1.Ids = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss"));
                model1.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _Iclient.favoritecandidate(model1);
                CandidateModel model = new CandidateModel();

                model.Id = model1.Id;
                _IobjCandidate.UpdateCandidateOnsolr(model);

                if (model1.Status == 2)
                {
                    Web.SolrMyCandidate.SolrIndex.DeleteCandidateIndex(model1.Ids);
                }
                else
                { 
                    Web.SolrMyCandidate.Helpers.SearchDocumentNew SearchDocument = new Web.SolrMyCandidate.Helpers.SearchDocumentNew();
                    SearchDocument.id = model1.Ids;
                    SearchDocument.CandidateId = Convert.ToString(model.Id);

                    SearchDocument.created_by = Convert.ToInt64(model.Id);
                    SearchDocument.updated_by = Convert.ToInt64(model.Id);
                    SearchDocument.updated_date = DateTime.Now;
                    SearchDocument.ProfileCheck_Id = Convert.ToInt16(model.ProfileCheck_Id);

                    if (model.Title != null)
                    {
                        SearchDocument.current_job_title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                    }
                    if (model.location != null)
                    {
                        SearchDocument.Job_location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.location.Trim().ToLower());
                    }

                    SearchDocument.IndustryName = model.IndustryName;
                    if (model.Zipcode == " ")
                    {
                        SearchDocument.ZipCode = null;
                    }
                    else
                    { SearchDocument.ZipCode = model.Zipcode; }

                    if (model.Zipcode !=" ")
                    {
                        if (string.IsNullOrEmpty(model.Zipcode) == false)
                        {
                            var latlog = getlatlogbyZipCode(model.Zipcode);
                            if (latlog !="")
                            {
                                string[] latloglist = latlog.Split(',');
                                model.Latitude = latloglist[0];
                                model.Longitude = latloglist[1];
                                _IobjCandidate.CheckAndInsertZipCode(model);
                            }
                          
                        }
                        SearchDocument.Latitude = model.Latitude;
                        SearchDocument.Longitude = model.Longitude;
                    }  
                    SearchDocument.EducationlevelName = model.EducationlevelName;
                    SearchDocument.jobTypeId = Convert.ToString(model.JobTypeId);
                    SearchDocument.jobType = model.JobTypeName;
                    SearchDocument.profile_image = model.FileName;
                    SearchDocument.Description = Convert.ToString(model.description);
                    SearchDocument.DesiredTitle1 = model.DesiredTitle1;
                    SearchDocument.DesiredTitle2 = model.DesiredTitle2;
                    SearchDocument.Experience_Name = model.experienceName;
                    if (model.experience != null && model.experience.Trim() != "" && model.experience.Trim() != " ")
                    {
                        SearchDocument.experience = model.experience;
                    }
                    else
                    {
                        SearchDocument.experience = "0";
                    }

                    SearchDocument.statusid = 1;
                    SearchDocument.CandidateTypeId = 2;
                    SearchDocument.CurrentSalary = model.CurrentSalary;
                    SearchDocument.CurrentSalaryId = Convert.ToInt64(model.CurrentSalaryId);

                    SearchDocument.IndustryName = Convert.ToString(model.IndustryName);
                    SearchDocument.IndustryId = Convert.ToInt16(model.Industry);
                    SearchDocument.jobId = 0;
                    SearchDocument.ClientId = Convert.ToInt32(Session["CompanyId"]);
                    SearchDocument.Candidateskill = model.Candidateskill;
                    SearchDocument.Candidate_Tag = model.CandidateTag;
                    Web.SolrMyCandidate.SolrIndex.IndexCandidate(SearchDocument, 1, true);

                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model1, JsonRequestBehavior.AllowGet);
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
        public JsonResult AddTofavoritecandidate(ClientModel model1)
        {
            try
            {
                model1.Ids = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss"));
                model1.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _Iclient.AddTofavoritecandidate(model1);

                if (model1.Status == 0)
                {
                    CandidateModel model = new CandidateModel();
                    model.Id = model1.Id;
                    _IobjCandidate.UpdateCandidateOnsolr(model);


                    Web.SolrMyCandidate.Helpers.SearchDocumentNew SearchDocument = new Web.SolrMyCandidate.Helpers.SearchDocumentNew();
                    SearchDocument.id = model1.Ids;
                    SearchDocument.CandidateId = Convert.ToString(model.Id);

                    SearchDocument.created_by = Convert.ToInt64(model.Id);
                    SearchDocument.updated_by = Convert.ToInt64(model.Id);
                    SearchDocument.updated_date = DateTime.Now;
                    SearchDocument.ProfileCheck_Id = Convert.ToInt16(model.ProfileCheck_Id);

                    if (model.Title != null)
                    {
                        SearchDocument.current_job_title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                    }
                    if (model.location != null)
                    {
                        SearchDocument.Job_location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.location.Trim().ToLower());
                    }

                    SearchDocument.IndustryName = model.IndustryName;
                    if (model.Zipcode == " ")
                    {
                        SearchDocument.ZipCode = null;
                    }
                    else
                    { SearchDocument.ZipCode = model.Zipcode; }

                    if (model.Zipcode != " ")
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
                        SearchDocument.Latitude = model.Latitude;
                        SearchDocument.Longitude = model.Longitude;
                    }
                    SearchDocument.EducationlevelName = model.EducationlevelName;
                    SearchDocument.jobTypeId = Convert.ToString(model.JobTypeId);
                    SearchDocument.jobType = model.JobTypeName;
                    SearchDocument.profile_image = model.FileName;
                    SearchDocument.Description = Convert.ToString(model.description);
                    SearchDocument.DesiredTitle1 = model.DesiredTitle1;
                    SearchDocument.DesiredTitle2 = model.DesiredTitle2;
                    SearchDocument.Experience_Name = model.experienceName;
                    if (model.experience != null && model.experience.Trim() != "" && model.experience.Trim() != " ")
                    {
                        SearchDocument.experience = model.experience;
                    }
                    else
                    {
                        SearchDocument.experience = "0";
                    }

                    SearchDocument.statusid = 1;
                    SearchDocument.CandidateTypeId = 2;
                    SearchDocument.CurrentSalary = model.CurrentSalary;
                    SearchDocument.CurrentSalaryId = Convert.ToInt64(model.CurrentSalaryId);

                    SearchDocument.IndustryName = Convert.ToString(model.IndustryName);
                    SearchDocument.IndustryId = Convert.ToInt16(model.Industry);
                    SearchDocument.jobId = 0;
                    SearchDocument.ClientId = Convert.ToInt32(Session["CompanyId"]);
                    SearchDocument.Candidateskill = model.Candidateskill;
                    SearchDocument.Candidate_Tag = model.CandidateTag;
                    Web.SolrMyCandidate.SolrIndex.IndexCandidate(SearchDocument, 1, true);
                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model1, JsonRequestBehavior.AllowGet);

        }




        /// <summary>
        /// Clientlogoupdate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult Clientlogoupdate(ClientModel model)
        {

            try
            {
                _Iclient.Clientlogoupdate(model);
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
                    Session["Image"] = "/FileUpload/CandidateImage/" + Convert.ToInt32(model.Id) + "/" + model.clientLogo;

                }
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
        public JsonResult StateList(ClientModel model)
        {
            try
            {
                _Iclient.StateList(model);
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.StateCollection, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// ClientProfileupdate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ClientProfileupdate(ClientModel model)
        {
            try
            {
                _Iclient.ClientProfileupdate(model);

                Session["Name"] = Convert.ToString(model.Name) + " " + Convert.ToString(model.LastName);
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

                    Session["Image"] = "/FileUpload/CandidateImage/" + Convert.ToInt32(model.Id) + "/" + model.clientLogo;

                }
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// sendconversationsaved
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult sendconversationsaved(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.Name = Convert.ToString(Session["Name"]);
                _Iclient.sendconversationsaved(model);

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
        /// skillautocomplete
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult skillautocomplete(string prefix)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.Name = prefix;
                _Iclient.skillautocomplete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json((new string(model.SkillCollection.SelectMany(x => x.skill + ",").ToArray())).Split(','), JsonRequestBehavior.AllowGet);
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
        /// CreateJobs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult CreateJobs(JobsModel model)
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
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                model.accounttype = Convert.ToInt64(Session["UsertypeId"]);

                _Iclient.CreateJobs(model);


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
                    jobdocument.MinimumSalary = model.MinSalary;
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
        /// ClientUpdateInterviewschedule
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ClientUpdateInterviewschedule(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _IobjAdmin.UpdateInterviewschedule(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ClientInterviewstatuschange
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ClientInterviewstatuschange(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _objICandidate.Interviewstatus(model);
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
                _IobjCandidate.InterViewdelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ClientUpdatesharejobsstatus
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ClientUpdatesharejobsstatus(JobsModel model)
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
        /// getinterviewschedulelist
        /// </summary>
        /// <returns></returns>
        public JsonResult getinterviewschedulelist()
        {
            ClientModel model = new ClientModel();
            try
            {
                model.CreatedBy = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.getinterviewschedulelist(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model.interviewListCollection, JsonRequestBehavior.AllowGet);
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
                _IobjCandidate.getallunreadmessage(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// InterviewSchedulecalenderlist
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult InterviewSchedulecalenderlist(string Id)
        {
            ClientModel model = new ClientModel();
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.InterviewSchedulecalenderlist(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddUpdateCompany(ClientModel model)
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
        public PartialViewResult updatecompanypopup(ClientModel model)
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
            return PartialView("updatecompanypopup", model);
        }

        /// <summary>
        /// DeleteClientContact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult DeleteClientContact(ClientModel model)
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
        /// AddClientContact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult AddCompanyContact(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.Password = Convert.ToString(new Random().Next(1111, 9999));
                if (model.Id == 0)
                {
                    model.CompanyuserTypeid = 1;
                }

                model.LoginAccess = 1;
                _IobjAdmin.AddClientContact(model);

                if (Convert.ToInt64(Session["Id"]) == model.Id)
                {
                    Session["Name"] = model.Name + " " + model.LastName;

                }

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));

            }
            return Json(model.Status, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ClientContact
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult CompanyContact(ClientModel model)
        {
            _IobjAdmin.ClientContact(model);
            return PartialView("CompanyContact", model);
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
                _Iclient.sendgeneralmessages(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// savesendgeneralmessage
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult savesendgeneralmessage(ClientModel model)
        {
            try
            {
                model.Name = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
                _Iclient.savesendgeneralmessage(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// clientNotesave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult clientNotesave(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.clientNotesave(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// clientNotesDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult clientNotesDelete(CandidateModel model)
        {
            try
            {

                _Iclient.clientNotesDelete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region PartialViewResult
        /// <summary>
        /// sendconversationsavedpopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult sendconversationsavedpopup(ClientModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.sendconversationsavedpopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView(model);
        }

        /// <summary>
        /// ClientInterviewSchedulepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult ClientInterviewSchedulepopup(ClientModel model)
        {
            try
            {
                //model.ClientId = Convert.ToInt64(Session["Id"]);
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                _IobjAdmin.InterviewSchedulepopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("ClientInterviewSchedulepopup", model);
        }

        /// <summary>
        /// ClientinterviewStatusPopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult ClientinterviewStatusPopup(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.CompanyId = Convert.ToInt64(Session["CompanyId"]);
                _objICandidate.interviewStatusPopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("ClientinterviewStatusPopup", model);
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
        /// clientsharjobIdziprecuiter
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult clientsharjobIdziprecuiter(JobsModel model)
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
            return PartialView("clientsharjobIdziprecuiter", model);
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

        /// <summary>
        /// Clientnotepopup
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Clientnotepopup(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);

                _Iclient.Clientnotepopup(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("Clientnotepopup", model);
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
        #endregion


    }
}