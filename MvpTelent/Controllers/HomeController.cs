using IntelDataBase.HelperMethods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
using Web.SolrClient;
using Web.SolrClient.Helpers;
using Web.SolrJobs;
using Web.SolrJobsClient;
using Stripe;
using Stripe.Checkout;
using Newtonsoft.Json.Linq;

namespace MvpTelent.Controllers
{
    public class HomeController : BaseController
    {
        ILogin _Ilogin = new LoginService();
        ICandidate _IobjCandidate = new CandidateService();
        IClient _Iclient = new ClientService();
        IPayment _objPayment = new PaymentService();


        #region ActionResult

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(JobsModel model)
        {

            try
            {
                if (Session["UsertypeId"] != null)
                {
                    model.accounttype = Convert.ToInt64(Session["UsertypeId"]);
                    model.Id = Convert.ToInt64(Session["Id"]);
                }
                _Ilogin.GetHomeIndex(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult payment(PaymentViewModel model)
        {
            if (model.pid != "0")
            {
                model.PlanId = Convert.ToInt64(EncryptDecrypt.Decrypt(model.pid));
            }

            if (Convert.ToInt64(Session["Id"]) > 0)
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.UserAccountType = Convert.ToInt64(Session["UsertypeId"]);
                _objPayment.GetPlanById(model);
                Session["CurrentPaln_Id"] = model.PlanId;
            }
            else
            {
                return RedirectToAction("Plan", "Home");
            }
            return View(model);
        }


        /// <summary>
        /// jobdetail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult jobdetail(JobsModel model)
        {
            try
            {
                if (model.Ids != null && model.Ids != "" && model.Ids != " ")
                {
                    model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(model.Ids));
                }
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.JobDetailById(model);
                var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri)
                {
                    Path = Url.Action("jobdetail", "Home"),
                    Query = null,
                };
                model.PageUrl = urlBuilder + "?Id=" + model.Id.ToString(); // EncryptDecrypt.encrypt(model.Id.ToString());
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// partnership
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult partnership(JobsModel model)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        public Decimal DistanceBetween2zip(string origin, string destination)
        {
            string key = "AIzaSyAz8lf6UZeLBkP5w6o3sYFJvJ9ZZ06IJSY";
            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=" + key;
            url = url.Replace(" ", "+");
            string content = fileGetContents(url);
            JObject result = JObject.Parse(content);
            string result1 = result.SelectToken("routes[0].legs[0].distance.text").ToString();
            result1 = result1.Replace(" mi", "");
            return Convert.ToDecimal(result1);

        }

        static double toRadians(double angleIn10thofaDegree)
        {
            return (angleIn10thofaDegree * Math.PI) / 180;
        }
        public double DistanceTo(double lat1, double lat2, double lon1, double lon2)
        {
            var radiusOfEarth = 6371;
            var lattitudeDifference = lat2 - lat1;
            var dLat = (lattitudeDifference) * Math.PI / 180;
            var longitudeDifference = lon2 - lon1;
            var dLon = (longitudeDifference) * Math.PI / 180;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = radiusOfEarth * c;

            var distanceInMiles = 0.62137119 * distance;


            //string m =  String.Format("{0:0.00}", rr);
            return Convert.ToDouble(distanceInMiles);

        }


        /// <summary>
        /// candidatelist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult candidatelist(CandidateListModel model)
        {


            try
            {
                model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _IobjCandidate.GetAllCandidateList(model);

                if (model.gids != null)
                {
                    model.gid = Convert.ToInt64(IdDecrypt(model.gids));
                }
                if (Session["UsertypeId"] != null)
                {
                    model.accounttype = Convert.ToInt64(Session["UsertypeId"]);
                    model.Id = Convert.ToInt64(Session["Id"]);
                }


                if (model.mile == 0)
                {
                    model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                }
                CandidateModel model1 = new CandidateModel();
                model1.CityName = model.Zip;
                model1.MileId = model.mile;
                model1.Title = model.Title;
                model1.gid = model.gid;
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                SolrSearch objSolrSearch = new SolrSearch();
                var searchOption = new Web.SolrClient.Helpers.IndexedSearchOption();
                searchOption.SearchType = 1;
                int TotalCount = 0;
                string msg = "";
                searchOption.ProfileCheckId = 1;
                searchOption.CityName = model.City;
                if (model.Title != null)
                {
                    model.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                }
                if (model.Keyword != null)
                {
                    model.Keyword = model.Keyword.Trim();
                }
                searchOption.Keyword = model.Keyword;
                searchOption.Title = model.Title;

                searchOption.Jobtype = model.Jobtype;
                searchOption.Jobcatagory = model.Jobcatagory;
                searchOption.experienceId = model.experienceId;
                searchOption.educationlavel = model.educationlavel;
                searchOption.IndustryId = model.IndustryId;
                if (model.educationlavel != null)
                {
                    model.educationlavel = model.educationlavel.Trim();
                }
                if (model.City != null)
                {
                    searchOption.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.City.Trim().ToLower());
                }
                if (model.groupcandidateId != null)
                {
                    searchOption.groupcandidateId = model.groupcandidateId;
                }

                GetCandidateList(model, objSolrSearch, searchOption, out TotalCount, out msg);


                if (model.Zip == null)
                {
                    if (model.salery == 2 || model.salery == 0)
                    {
                        model.CandiateList = model.CandiateList.OrderByDescending(x => x.CurrentSalaryId).ToList();
                    }
                    else
                    {
                        model.CandiateList = model.CandiateList.OrderBy(x => x.CurrentSalaryId).ToList();
                    }
                }
                else
                {
                    model.CandiateList = model.CandiateList.OrderByDescending(x => x.CurrentSalaryId).OrderBy(x => x.miles_range).ToList();
                }

                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
            catch (Exception ex)
            {

            }
            return View(model);
        }



        /// <summary>
        /// GetSearchCandidates
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult GetSearchCandidates(CandidateListModel model)
        {
            try
            {
                var zipcode = "";
                if (Convert.ToInt32(model.gids) > 0)
                {
                    model.gid = Convert.ToInt64(model.gids);
                }

                if (model.mile == 0)
                {
                    model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                }
                CandidateModel model1 = new CandidateModel();
                model1.CityName = model.Zip;
                model1.MileId = model.mile;
                model1.Title = model.Title;
                model1.gid = model.gid;
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                SolrSearch objSolrSearch = new SolrSearch();
                var searchOption = new Web.SolrClient.Helpers.IndexedSearchOption();
                searchOption.SearchType = 1;
                int TotalCount = 0;
                string msg = "";
                searchOption.ProfileCheckId = 1;
                searchOption.CityName = model.City;
                if (model.Title != null)
                {
                    model.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                }
                if (model.Keyword != null)
                {
                    model.Keyword = model.Keyword.Trim();
                }
                searchOption.Keyword = model.Keyword;
                searchOption.Title = model.Title;

                searchOption.Jobtype = model.Jobtype;
                searchOption.Jobcatagory = model.Jobcatagory;
                searchOption.experienceIds = model.experienceIds;
                searchOption.educationlavel = model.educationlavel;
                searchOption.IndustryId = model.IndustryId;
                if (model.educationlavel != null)
                {
                    model.educationlavel = model.educationlavel.Trim();
                }
                if (model.City != null)
                {
                    searchOption.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.City.Trim().ToLower());
                }
                if (model.groupcandidateId != null)
                {
                    searchOption.groupcandidateId = model.groupcandidateId;
                }

                GetCandidateList(model, objSolrSearch, searchOption, out TotalCount, out msg);


                if (model.salery == 2)
                {
                    model.CandiateList = model.CandiateList.OrderByDescending(x => x.CurrentSalaryId).ToList();
                }
                else if (model.salery == 1)
                {
                    model.CandiateList = model.CandiateList.OrderBy(x => x.CurrentSalaryId).ToList();
                }
                //else
                //{
                //    if (model.Zip != null)
                //    {
                //        model.CandiateList = model.CandiateList.OrderBy(x => x.miles_range).ToList();
                //    }
                //}
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView(model);
        }




        /// <summary>
        /// GetSearchCandidates
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult CandidateSearchByClient(CandidateListModel model)
        {
            try
            {
                if (model.mile == 0)
                {
                    model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                }
                CandidateModel model1 = new CandidateModel();
                model1.CityName = model.City;
                model1.MileId = model.mile;
                model1.Title = model.Title;
                model1.gid = model.gid;
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);

                SolrSearch objSolrSearch = new SolrSearch();
                var searchOption = new Web.SolrClient.Helpers.IndexedSearchOption();
                searchOption.SearchType = 1;
                int TotalCount = 0;
                string msg = "";
                searchOption.ProfileCheckId = 1;
                searchOption.CityName = model.City;
                if (model.Title != null)
                {
                    model.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Title.Trim().ToLower());
                }
                if (model.Keyword != null)
                {
                    model.Keyword = model.Keyword.Trim();
                }
                searchOption.Keyword = model.Keyword;
                searchOption.Title = model.Title;

                searchOption.Jobtype = model.Jobtype;
                searchOption.Jobcatagory = model.Jobcatagory;
                searchOption.experienceIds = model.experienceIds;
                searchOption.Zip = model.Zip;


                searchOption.IndustryId = model.IndustryId;
                if (model.educationlavel != null)
                {
                    searchOption.educationlavel = model.educationlavel.Trim();
                }
                if (model.City != null)
                {
                    searchOption.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.City.Trim().ToLower());
                    if (searchOption.location == model.Zip )
                    {
                        searchOption.location = null;
                    }

                }
                if (model.groupcandidateId != null)
                {
                    searchOption.groupcandidateId = model.groupcandidateId;
                }

                GetCandidateList(model, objSolrSearch, searchOption, out TotalCount, out msg);
                if (model.CandiateList != null)
                {
                    string CandidateId = "";
                    for (var i = 0; i < model.CandiateList.Count; i++)
                    {
                        CandidateId = CandidateId += model.CandiateList[i].id + ",";
                    }
                    model.CandidateIds = CandidateId;
                    model.ClientId = Convert.ToInt64(Session["CompanyId"]);
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
                }
                
                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView(model);
        }

        private void GetCandidateList(CandidateListModel model, SolrSearch objSolrSearch, IndexedSearchOption searchOption, out int TotalCount, out string msg)
        {
            var result = new List<SearchDocumentResultForView>();
            msg = null;
            TotalCount = 0;
            var pageindex = Convert.ToInt32(model.CurrentPageIndex);
            if (string.IsNullOrEmpty(model.Zip))
            {
                //DO AS BEFORE. USE PAGINATION ON SOLR
                model.CandiateList = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 2000, out TotalCount, out msg);

                if (model.salery == 2 || model.salery == 0)
                {
                    model.CandiateList = model.CandiateList.OrderBy(x => x.current_job_title).OrderByDescending(X => X.CurrentSalaryId).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();
                    model.salery = 2;
                }
                else
                {
                    model.CandiateList = model.CandiateList.OrderBy(x => x.current_job_title).OrderBy(X => X.CurrentSalaryId).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();
                }
            }
            else
            {
                //DO PAGINATION ON SESSION
                // var zips = GetNearByZipCodewithlatlong(model.mile, model.Zip);
                int rangeStart = 0;
                int looopvalue = 0;


                if (model.mile == 25 || model.mile <= 25)
                {
                    rangeStart = 0;
                    looopvalue = 1;
                }
                else if (model.mile == 50)
                {
                    rangeStart = 26;
                    looopvalue = 2;
                }
                else if (model.mile == 75)
                {
                    rangeStart = 51;
                    looopvalue = 3;
                }
                else if (model.mile == 100)
                {
                    rangeStart = 76;
                    looopvalue = 4;
                } 
                List<SearchDocumentResultForView> newList1 = new List<SearchDocumentResultForView>();

                List<SearchDocumentResultForView> newList1_1 = new List<SearchDocumentResultForView>();


                List<SearchDocumentResultForView> newList2 = new List<SearchDocumentResultForView>();
                List<SearchDocumentResultForView> newList2_2 = new List<SearchDocumentResultForView>();

                List<SearchDocumentResultForView> newList3 = new List<SearchDocumentResultForView>();
                List<SearchDocumentResultForView> newList3_3 = new List<SearchDocumentResultForView>();



                List<SearchDocumentResultForView> newList4 = new List<SearchDocumentResultForView>();
                List<SearchDocumentResultForView> newList4_4 = new List<SearchDocumentResultForView>();

                var sessionKey = $"M={model.mile};C={model.City};Z={model.Zip};Ti={model.Title};Key={model.Keyword};" +
                    $"jt={model.Jobtype};JC={model.Jobcatagory};Eid={model.experienceIds};I={model.IndustryId};El={model.educationlavel};" +
                    $"GId={model.groupcandidateId};";
                if (Session[sessionKey] == null)
                { 
                    for (int i = 0; i < looopvalue; i++)
                    {
                        if (i == 0)
                        {

                            var zips = GetNearByZipCodewithlatlong(0, 10, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips.Select(x => x.ZipCodeWithZero).ToList());
                            newList1 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();

                            var zips1 = GetNearByZipCodewithlatlong(15, 25, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips1.Select(x => x.ZipCodeWithZero).ToList());
                            newList1_1 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();
                            newList1.AddRange(newList1_1);

                        }
                        else if (i == 1)
                        {
                            var zips2 = GetNearByZipCodewithlatlong(26, 35, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips2.Select(x => x.ZipCodeWithZero).ToList());
                            newList2 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();


                            var zips = GetNearByZipCodewithlatlong(35, 50, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips.Select(x => x.ZipCodeWithZero).ToList());
                            newList2_2 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();

                            newList2.AddRange(newList2_2);
                        }
                        else if (i == 2)
                        {
                            var zips = GetNearByZipCodewithlatlong(51, 65, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips.Select(x => x.ZipCodeWithZero).ToList());
                            newList3 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();


                            var zips3 = GetNearByZipCodewithlatlong(65, 75, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips3.Select(x => x.ZipCodeWithZero).ToList());
                            newList3_3 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();

                            newList3.AddRange(newList3_3);

                        }
                        else
                        {
                            var zips4 = GetNearByZipCodewithlatlong(76, 85, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips4.Select(x => x.ZipCodeWithZero).ToList());
                            newList4 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();
                           
                            var zips = GetNearByZipCodewithlatlong(85, 100, model.Zip);
                            searchOption.ZipCode = string.Join(",", zips.Select(x => x.ZipCodeWithZero).ToList());
                            newList4_4 = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.ZipCode) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();
                            newList4.AddRange(newList4_4);
                        }
                    }
                    newList3.AddRange(newList4);
                    newList2.AddRange(newList3);
                    newList1.AddRange(newList2); 

                    var zip = FindZipCodewithlatlong(model.Zip);
                    if (newList1.Count > 0)
                    {
                        newList1.ForEach(x => x.miles_range = Convert.ToDecimal(HaversineFormula.Distance(zip.lat, zip.log, Convert.ToDouble(x.Latitude), Convert.ToDouble(x.Longitude))));
                        Session[sessionKey] = newList1; 
                    } 
                }
                if (Session[sessionKey] != null)
                {
                    var candidates = Session[sessionKey] as List<SearchDocumentResultForView>;
                    TotalCount = candidates.Count;
                    if (model.salery == 1)
                    {
                        model.CandiateList = candidates.OrderBy(x => x.miles_range).OrderBy(x => x.CurrentSalaryId).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();
                    }
                    else
                    {
                        model.CandiateList = candidates.OrderBy(x => x.miles_range).OrderByDescending(x => x.CurrentSalaryId).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();
                    }
                }
              
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
        private IEnumerable<ZipCodeVIewModel> GetNearByZipCodewithlatlong(long rangeStart, long rangeEnd, string zipcode)
        {
            var Zipcodes = GetAllZipCodewithlatlong();
            var zip = Zipcodes.FirstOrDefault(x => x.ZipCodeWithZero == zipcode);

            var result = Zipcodes.Where(x => rangeStart <= HaversineFormula.Distance(zip.lat, zip.log, x.lat, x.log) && HaversineFormula.Distance(zip.lat, zip.log, x.lat, x.log) <= rangeEnd)

                .Select(x => new { Distance = HaversineFormula.Distance(zip.lat, zip.log, x.lat, x.log), Codes = x })
                .OrderBy(x => x.Distance)
                .Select(x => x.Codes);
            return result;
        }


        public ActionResult termsofuse()
        {
            return View();
        }

        /// <summary>
        /// plan
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult plan(PlanModel model)
        {
            try
            {
                if (Session["UsertypeId"] != null)
                {
                    model.UsertypeId = Convert.ToInt64(Session["UsertypeId"]);
                }
                _Ilogin.plan(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// contact
        /// </summary>
        /// <returns></returns>
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult howitworks()
        {
            return View();
        }

        /// <summary>
        /// faq
        /// </summary>
        /// <returns></returns>
        public ActionResult faq()
        {
            return View();
        }

        /// <summary>
        /// terms
        /// </summary>
        /// <returns></returns>
        public ActionResult termscondition()
        {
            return View();
        }
        /// <summary>
        /// details
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult details(string Id, CandidateModel model)
        {
            try
            {
                model.Id = Convert.ToInt64(EncryptDecrypt.Decrypt(Id));
                model.UserId = Convert.ToInt64(Session["Id"]);
                model.ClientId = Convert.ToInt64(Session["CompanyId"]);
                model.AccountType = Convert.ToInt64(Session["UsertypeId"]);
                _Ilogin.CandidateDetailsbyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult login(LoginModel model)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                model.Email = Convert.ToString(reqCookies["LoginEmail"]);
                model.Password = Convert.ToString(reqCookies["Password"]);
                model.KeepLogIn = Convert.ToInt64(reqCookies["KeepLogIn"]);
            }
            return View(model);
        }

        /// <summary>
        /// LogoutAndRedirectToLogin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LogoutAndRedirectToLogin()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction(nameof(login));
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult ForgotPassword(LoginModel model)
        {
            return View(model);
        }

        /// <summary>
        /// ForgotPasswordbyId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult ForgotPasswordbyId(string Id)
        {
            LoginModel model = new LoginModel();
            model.UserId = Convert.ToInt64(EncryptDecrypt.Decrypt(Id));
            return View(model);
        }

        /// <summary>
        /// read
        /// </summary>
        /// <param name="ids"></param>
        public void read(string ids)
        {
            if (ids != null)
            {
                _Ilogin.emailread(IdDecrypt(ids));
            }
        }


        /// <summary>
        /// Campaignread
        /// </summary>
        /// <param name="ids"></param>
        public void Campaignread(string ids)
        {
            if (ids != null)
            {
                string[] campigan = ids.Split('_');
                _Ilogin.Campaignread(campigan[0], campigan[1]);
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
        /// unsubscribe
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult unsubscribe(string ids)
        {
            LoginModel model = new LoginModel();
            if (ids != null)
            {
                model.ids = IdDecrypt(ids);
            }


            _Ilogin.unsubscribe(model);
            return View(model);
        }


        /// <summary>
        /// SignUp
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult SignUp(LoginModel model)
        {
            return View(model);
        }

        /// <summary>
        /// about
        /// </summary>
        /// <returns></returns>
        public ActionResult about()
        {

            //Web.SolrClient.SolrIndex.DeleteCandidateIndex(0);

            return View();
        }

        /// <summary>
        /// updatepassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult updatepassword(LoginModel model)
        {
            model.UserId = Convert.ToInt32(IdDecrypt(model.ids));
            return View(model);
        }


        /// <summary>
        /// confirmation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult confirmation(LoginModel model)
        {
            model.UserId = Convert.ToInt32(IdDecrypt(model.ids));
            _Ilogin.confirmation(model);
            return View(model);
        }

        /// <summary>
        /// alertunsubscribe
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult alertunsubscribe(string Id)
        {
            if (Id != null)
            {

                string[] ids = Id.Split('_');

                string alertid = EncryptDecrypt.Decrypt(ids[0]);
                _Ilogin.alertunsubscribe(alertid, ids[1]);
            }
            return View();
        }


        /// <summary>
        /// candidatedeatils
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult candidatedeatils(ClientModel model)
        {
            return View(model);
        }


        /// <summary>
        /// joblist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult joblist(JobsModel model)
        {
            try
            {


            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// maintenance
        /// </summary>
        /// <returns></returns>
        public ActionResult maintenance()
        {

            return View();
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
        /// PublicprofileUrl
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult PublicprofileUrl(CandidateModel model)
        {
            try
            {

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
        /// JobApply
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult JobApply(JobsModel model)
        {
            return PartialView("JobApply", model);
        }
        /// <summary>
        /// PlanLogin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult PlanLogin(JobsModel model)
        {
            return PartialView("PlanLogin", model);
        }


        /// <summary>
        /// deleteJobskill
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult deleteJobskill(JobsModel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.deleteskill(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("deleteJobskill", model);
        }

        /// <summary>
        /// deleteJobtags
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult deleteJobtags(JobsModel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);
                _Iclient.deleteJobtags(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView(model);
        }

        /// <summary>
        /// AddSkills
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AddSkills(JobsModel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);
                if (model.KeySkills.Trim().Length > 0)
                {
                    _Iclient.AddSkills(model);
                }

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AddSkills", model);
        }

        /// <summary>
        /// AddTags
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult AddTags(JobsModel model)
        {
            try
            {

                model.UserId = Convert.ToInt64(Session["Id"]);
                if (model.Tags.Trim().Length > 0)
                {
                    _Iclient.AddTags(model);
                }

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("AddTags", model);
        }


        /// <summary>
        /// Candidatedefaultimage
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Candidatedefaultimage(CandidateModel model)
        {
            try
            {
                _IobjCandidate.Candidatedefaultimage(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView(model);
        }


        /// <summary>
        /// candidatesendemail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult candidatesendemail(JobsModel model)
        {
            try
            {

                _Ilogin.getemailbyId(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("candidatesendemail", model);
        }

        /// <summary>
        /// gestcndidatelogin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult gestcndidatelogin(JobsModel model)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("gestcndidatelogin", model);
        }


        /// <summary>
        /// jobalertPopUp
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult jobalertPopUp(jobalertviewmodel model)
        {
            return PartialView("jobalertPopUp", model);
        }

        /// <summary>
        /// plandetails
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult plandetails(PlanModel model)
        {
            try
            {
                _Ilogin.plandetails(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return PartialView("plandetails", model);
        }


        /// <summary>
        /// Howitwork
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PartialViewResult Howitwork(LoginModel model)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return PartialView("Howitwork", model);
        }
        #endregion


        #region JsonResult

        /// <summary>
        /// ResumeUpload
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResumeUpload(CandidateModel model)
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

                model.Id = model.CreateBy;
                _IobjCandidate.UpdateCandidateOnsolr(model);

                // (candidate Update by self on solr profile)
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
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ProfileImageUpload
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ProfileImageUpload(CandidateModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _IobjCandidate.ProfileImageUpload(model);
                if (Session["UsertypeId"].ToString() != "1")
                {
                    Session["Image"] = model.FileName;
                }

                model.Id = model.CreateBy;
                _IobjCandidate.UpdateCandidateOnsolr(model);

                // (candidate Update by self on solr profile)
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
                model.description = ex.Message;
            }
            return Json(model.description, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// stoppayment
        /// </summary>
        /// <returns></returns>
        public JsonResult stoppayment(CandidateModel obj)
        {
            try
            {
                StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["Secretkey"].ToString();

                var Pauseoptions = new SubscriptionUpdateOptions
                {
                    PauseCollection = new SubscriptionPauseCollectionOptions
                    {
                        Behavior = "mark_uncollectible",
                    },
                };
                var Pauseservice = new SubscriptionService();
                var resultresponse = Pauseservice.Update(obj.p_Id, Pauseoptions);


                //var service = new SubscriptionService();
                //var cancelOptions = new SubscriptionCancelOptions
                //{
                //    InvoiceNow = false,
                //    Prorate = false,
                //};
                //Subscription subscription = service.Cancel(obj.p_Id, cancelOptions);
                //var resultresponse = subscription;


                if (resultresponse.Status == "active")
                {
                    obj.Id = Convert.ToInt64(Session["Id"]);
                    _IobjCandidate.stoppayment(obj);
                }
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                return Json(2, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// stoppayment
        /// </summary>
        /// <returns></returns>
        public JsonResult refundpayment(CandidateModel obj)
        {
            try
            {
                StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["Secretkey"].ToString();
                var service = new SubscriptionService();
                var subscritpion = service.Get(obj.p_Id);

                var invoice = new InvoiceService().Get(subscritpion.LatestInvoiceId);

                var upcominginvoice = new InvoiceService().Upcoming(new UpcomingInvoiceOptions
                {
                    Subscription = subscritpion.Id,
                    Customer = subscritpion.CustomerId,
                    SubscriptionProrationDate = DateTime.Now,
                    SubscriptionItems = new List<InvoiceSubscriptionItemOptions>
                    {
                        new InvoiceSubscriptionItemOptions
                        {
                            Id = subscritpion.Items.Data[0].Id,
                            Plan = subscritpion.Items.Data[0].Plan.Id,
                            Quantity =0
                        }
                    }
                });

                long prorated_amount = 0;

                foreach (var item in upcominginvoice.Lines.Data)
                {
                    if (item.Type == "invoiceitem")
                    {
                        prorated_amount = (item.Amount < 0) ? Math.Abs(item.Amount) : 0;
                    }
                }
                var chargeId = invoice.ChargeId;
                new RefundService().Create(new RefundCreateOptions
                {
                    Charge = chargeId,
                    Amount = prorated_amount,
                });




                //new SubscriptionService().Cancel(subscritpion.Id);

                var Cancelservice = new SubscriptionService();
                var result = Cancelservice.Cancel(subscritpion.Id);

                if (result.Status == "canceled")
                {
                    obj.Id = Convert.ToInt32(Session["Id"]);
                    _IobjCandidate.refundpayment(obj);
                }
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                return Json(2, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// stoppayment
        /// </summary>
        /// <returns>Renewpayment</returns>
        public JsonResult Renewpayment(CandidateModel obj)
        {
            try
            {
                StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["Secretkey"].ToString();

                var options = new SubscriptionUpdateOptions();
                options.AddExtraParam("pause_collection", "");
                var service = new SubscriptionService();
                var resultresponse = service.Update(obj.p_Id, options);

                if (resultresponse.Status == "active")
                {
                    obj.Id = Convert.ToInt64(Session["Id"]);
                    _IobjCandidate.Renewpayment(obj);
                }
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                return Json(2, JsonRequestBehavior.AllowGet);
            }

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
        /// JobDetailDeletebyId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult JobDetailDeletebyId(JobsModel model)
        {
            try
            {
                _Iclient.JobDetailDeletebyId(model);

                SolrJobsIndex.DeleteCandidateIndex(model.Id);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// getIds
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult getIds(JobsModel model)
        {
            try
            {
                _Ilogin.getIds(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.jobIds, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ApplicantDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ApplicantDelete(CandidateModel model)
        {
            model.UserId = Convert.ToInt32(Session["Id"]);
            _IobjCandidate.ApplicantDelete(model);

            return Json(1, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// ClientsendqueryDelete
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ClientsendqueryDelete(ClientModel model)
        {
            try
            {
                _Ilogin.ClientsendqueryDelete(model);
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
        /// <summary>
        /// ClientCandidateNameAutoComplete
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ClientCandidateNameAutoComplete()
        {
            CandidateModel model = new CandidateModel();
            try
            {
                _Iclient.ClientCandidateNameAutoComplete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.CityCollection.Select(x => new { id = x.Id, label = x.Name }));
        }


        /// <summary>
        /// ClientNameAutoComplete
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ClientNameAutoComplete()
        {
            CandidateModel model = new CandidateModel();
            try
            {
                _Iclient.ClientNameAutoComplete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.CityCollection.Select(x => new { id = x.Id, label = x.Name }));

        }


        /// <summary>
        /// AutoCompleteCandidatetags
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getCandidateTitleList(string prefix)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.Title = prefix;
                _Iclient.getCandidateTitleList(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AutoCompleteCandidatetags
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getFavoriteCandidateTitleList(string prefix)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.Title = prefix;
                model.UserId = Convert.ToInt64(Session["CompanyId"]);
                _Iclient.getFavoriteCandidateTitleList(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AutoCompleteCandidatetags
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult jobtitleautocomplate(string prefix)
        {
            CandidateModel model = new CandidateModel();
            try
            {
                model.Title = prefix;
                _Iclient.jobtitleautocomplate(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
         

        /// <summary>
        /// CandidateNameAutoComplete
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CandidateNameAutoComplete()
        {
            CandidateModel model = new CandidateModel();
            try
            {
                _Iclient.CandidateNameAutoComplete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.candidatelistcollection.Select(x => new { id = x.Id, label = x.Name }));
        }

        /// <summary>
        /// Tagsautocomplete
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Tagsautocomplete(string prefix)
        {

            CandidateModel model = new CandidateModel();
            try
            {
                model.Name = prefix;
                _Iclient.Tagsautocomplete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json((new string(model.tagscollection.SelectMany(x => x.tags + ",").ToArray())).Split(','), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// CandidateLogin
        /// </summary>
        /// <param name="model"></param>w
        /// <returns></returns>
        public JsonResult CandidateLogin(LoginModel model)
        {
            try
            {
                _Ilogin.CandidateLogin(model);
                if (model.Status == 1)
                {
                    Session["Id"] = model.Id;
                    Session["Email"] = model.Email;
                    Session["UsertypeId"] = model.UsertypeId;
                    Session["RoleId"] = model.RoleId;
                    Session["CompanyId"] = model.CompanyId;
                    Session["UsertypeName"] = model.UsertypeName;
                    Session["Name"] = model.Name;
                    Session["FirstName"] = model.FirstName;
                    Session["LastName"] = model.LastName;
                    Session["Phone"] = model.Phone;
                    Session["Title"] = model.Title;
                    Session["Image"] = model.Image;
                    //Session["FileName"] = model.FileName;
                    //Session["CompanyImage"] = model.FilePath;
                    //  FormsAuthentication.SetAuthCookie(model.UsertypeName.ToString(), false);
                    if (model.KeepLogIn == 1)
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["LoginEmail"] = model.Email;
                        userInfo["Password"] = model.Password;
                        userInfo["KeepLogIn"] = model.KeepLogIn.ToString();
                        Response.Cookies.Add(userInfo);
                    }
                    else
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["LoginEmail"] = "";
                        userInfo["Password"] = "";
                        userInfo["KeepLogIn"] = model.KeepLogIn.ToString();
                        Response.Cookies.Add(userInfo);
                    }


                    var userData = JsonConvert.SerializeObject(model);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddHours(1), model.KeepLogIn == 1, userData);
                    var value = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, value));

                    var models = _Ilogin.GetAllMenuSubmenu();
                    Session["Menus"] = models;

                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// viewCandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult viewCandidate(ClientModel model)
        {
            try
            {
                _Iclient.viewCandidate(model);
                model.Url = System.Configuration.ConfigurationManager.AppSettings["Url"].ToString() + model.Ids;
                if (Session["UsertypeId"].ToString() == "2")
                {
                    DateTime TodayDate = System.DateTime.Now;
                    TimeSpan t = TodayDate.Subtract(Convert.ToDateTime(model.CreatedDate));
                    Int64 days = Convert.ToInt64(t.TotalDays);
                    if (days > Convert.ToInt64(System.Configuration.ConfigurationManager.AppSettings["days"]))
                    {
                        model.result = 1;
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
        /// ForgotPasswordEmail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ForgotPasswordEmail(LoginModel model)
        {
            try
            {
                _Ilogin.ForgotPasswordEmail(model);
                model.Status = 1;
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                model.msg = ex.Message;
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// GetId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetId(LoginModel model)
        {
            string _Id = EncryptDecrypt.encrypt(Convert.ToString(model.Id));
            return Json(_Id, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ChangePasswordEmail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ChangePasswordEmail(LoginModel model)
        {
            try
            {
                _Ilogin.ChangePasswordEmail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// updateforgotPassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult updateforgotPassword(LoginModel model)
        {
            try
            {
                _Ilogin.updateforgotPassword(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// CreateCandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateCandidate(LoginModel model1)
        {
            try
            {
                if (model1.AccountType == 2)
                {
                    model1.CompanyuserTypeid = 1;
                }
                model1.UserId = Convert.ToInt64(Session["Id"]);
                _Ilogin.CreateCandidate(model1);
                if (model1.AccountType == 3)
                {
                    if (model1.Id > 0)
                    {
                        CandidateModel model = new CandidateModel();
                        model.Id = model1.Id;
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
                        SearchDocument.ProfileCheck_Id = 0;
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
                        SearchDocument.profile_image = "/FileUpload/candidatedefaultImage/No_image_available.PNG";
                        SolrIndex.IndexCandidate(SearchDocument, 1, true);
                    }
                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                model1.msg = ex.Message;
            }
            return Json(model1, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// unsubscribeClick
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult unsubscribeClick(LoginModel model)
        {
            try
            {

                _Ilogin.unsubscribeClick(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// CreateContactUs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CreateContactUs(ContactUs model)
        {
            try
            {
                model.AdminEmail = Convert.ToString(Session["Email"]);
                _Ilogin.CreateContactUs(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }

            //return Json(model, JsonRequestBehavior.AllowGet);
            return Json(model);
        }

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
                _Ilogin.ClientSendenquery(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.Status, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// CreateCandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MakeFreePayment(PaymentViewModel model)
        {
            try
            {
                model.UserId = Convert.ToInt64(Session["Id"]);
                _Ilogin.MakeFreePayment(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        #region Payment BY Cart Stripe

        [HttpPost]
        public ActionResult StripePayment(string amount)
        {
            StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["Secretkey"].ToString();
            PaymentViewModel model = new PaymentViewModel();
            try
            {
                if (Convert.ToInt64(Session["CurrentPaln_Id"]) > 0)
                {
                    model.PlanId = Convert.ToInt64(Session["CurrentPaln_Id"]);
                    model.UserId = Convert.ToInt64(Session["UserId"]);
                    _objPayment.GetPlanById(model);
                }
                var domain = ConfigurationManager.AppSettings["SuccessUrl"].ToString();
                var CusId = "";
                if (model.CusId == null)
                {
                    var Cusservice = new CustomerService();
                    var customer = Cusservice.Create(new CustomerCreateOptions()
                    {
                        Name = Session["Name"].ToString(),
                        Email = Session["Email"].ToString(),
                    });
                    CusId = customer.Id;

                }
                var options = new SessionCreateOptions
                {
                    Customer = CusId,
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            Price = model.StripePriceid,
                            Quantity = 1,

                        },
                    },

                    Metadata = new Dictionary<string, string>(),

                    Mode = "subscription",
                    SuccessUrl = domain + "/Success?session_id={CHECKOUT_SESSION_ID}",
                    CancelUrl = domain + "/error?session_id={CHECKOUT_SESSION_ID}",
                    PaymentMethodCollection = "always",
                    SubscriptionData = new SessionSubscriptionDataOptions
                    {
                    }
                };
                options.Metadata.Add("CurrentPaln_Id", Convert.ToString(model.PlanId));
                options.Metadata.Add("CurrentUserId", Convert.ToString(Session["Id"]));

                var service = new SessionService();
                Session session = service.Create(options);
                var Id = session.Id;
                Response.Headers.Add("Location", session.Url);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return new HttpStatusCodeResult(303);
        }

        #endregion
        /// <summary>
        /// Payment success
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult success(string session_id)
        {
            PaymentViewModel model = new PaymentViewModel();
            StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["Secretkey"].ToString();
            try
            {
                if (session_id != null)
                {
                    var service = new SessionService();
                    Session session = service.Get(session_id);
                    var subs = new SubscriptionService().Get(session.SubscriptionId);

                    session.Metadata.TryGetValue("CurrentPaln_Id", out string CurrentPaln_Id);
                    session.Metadata.TryGetValue("CurrentUserId", out string CurrentUserId);

                    Session["Id"] = CurrentUserId;
                    if (CurrentPaln_Id != null && CurrentUserId != null)
                    {
                        model.PlanId = Convert.ToInt64(CurrentPaln_Id);
                        model.UserId = Convert.ToInt64(CurrentUserId);
                        model.result = 1;
                        model.TransactionId = null;
                        model.StatusId = 1;
                        model.CreditCardId = Convert.ToString(subs.CustomerId);
                        model.PaymentId = Convert.ToString(subs.Id);
                        _objPayment.MakePayment(model);
                    }
                    if (CurrentPaln_Id != null && CurrentUserId != null)
                    {
                        model.PlanId = Convert.ToInt64(CurrentPaln_Id);
                        model.UserId = Convert.ToInt64(CurrentUserId);
                        model.PaymentId = Convert.ToString(subs.Id);
                        _objPayment.GetpaymentsuccessDetailById(model);
                    }
                }
                else
                {
                    return RedirectToAction("Plan", "Home");
                }
                model.UserAccountType = Convert.ToInt64(Session["UsertypeId"]);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }
        #endregion
        /// <summary>
        /// Payment success
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Cancel(string session_id)
        {
            PaymentViewModel model = new PaymentViewModel();
            StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["Secretkey"].ToString();
            try
            {
                var service = new SessionService();
                Session session = service.Get(session_id);
                var subs = new SubscriptionService().Get(session.SubscriptionId);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }

        /// <summary>
        /// error
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult error(string session_id)
        {
            StripeConfiguration.ApiKey = "sk_test_51MLrLMEQVZq88mvAon4X4vAE7iUB33rAaDVV7eXndtedZ9H6LBF1ntMmdrcTJYw6ElYEiAdR7EPYR9A3V3Q7l4wZ00sa0DVTHy";

            var options = new RefundCreateOptions
            {
                Charge = "ch_3MU653EQVZq88mvA0zeinv7y",
            };
            var service = new RefundService();
            service.Create(options);



            //var id = "pi_3MU3smEQVZq88mvA0xlJr4mm";
            //var options = new RefundCreateOptions { PaymentIntent = id};
            //var service = new RefundService();
            //var check=  service.Create(options);



            PaymentViewModel model = new PaymentViewModel();
            try
            {
                Session["CurrentPaln_Id"] = null;

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex) + "error session_id:- " + session_id);
            }
            return View(model);
        }



        /// <summary>
        /// job
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult job(JobsModel model)
        {
            try
            {
                model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                model.locationKey = "https://maps.googleapis.com/maps/api/js?key=" + ConfigurationManager.AppSettings["locationKey"].ToString() + "&libraries=places";
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                if (model.days == 0)
                {
                    model.days = 356;
                }
                _Ilogin.job(model);

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return View(model);
        }


        /// <summary>
        /// GetJobssearch
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public PartialViewResult GetJobssearch(JobsModel model)
        {
            try
            {
                model.checkId = 1;
                HttpCall _httpCall = new HttpCall();
                if (model.zipcode != null)
                {
                    if (model.mile == 0)
                    {
                        model.mile = Convert.ToInt64(ConfigurationManager.AppSettings["miles"]);
                    }
                }
                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);
                _Ilogin.job(model);

                SolrJobsSearch objJobSolrSearch = new SolrJobsSearch();
                var searchOption = new Web.SolrJobs.Helpers.IndexedSearchOption();
                searchOption.Tags = model.Tags;
                if (model.jobtitle != null)
                {
                    searchOption.JobTitle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.jobtitle.Trim().ToLower());
                }

                searchOption.zipcode = model.zipcode;
                searchOption.location = model.City;
                if (model.Relevance == 2 || model.Relevance == 0)
                {
                    searchOption.AscDescId = 2;
                }
                else
                {
                    searchOption.AscDescId = 1;
                }

                searchOption.Days = model.days;
                if (model.JobCategoryId > 0)
                {
                    searchOption.CategoryId = model.JobCategoryId;
                }
                searchOption.JobType = model.Jobtype;
                searchOption.MinSalary = model.MinSalary;
                searchOption.MaxSalary = model.MaxSalary;
                searchOption.jobIds = model.jobIds;
                searchOption.jobstatusid = 2;
                searchOption.SearchType = 1;
                if (searchOption.MinSalary == null)
                {
                    searchOption.MinSalary = "0";
                }
                searchOption.salertchangeId = model.salertchangeId;
                int TotalCount = 0;
                string msg = "";
                GetJobListList(model, objJobSolrSearch, searchOption, out TotalCount, out msg);


                model.JobCountData = model.SolrJobListCollection.Count();
                model.result = "success";
                model.TotalRowCount = TotalCount;
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                model.result = ex.Message;
            }
            return PartialView(model);
        }
        private void GetJobListList(JobsModel model, SolrJobsSearch objSolrSearch, Web.SolrJobs.Helpers.IndexedSearchOption searchOption, out int TotalCount, out string msg)
        {
            var result = new List<Web.SolrJobs.Helpers.SearchDocumentResultForView>();
            msg = null;
            TotalCount = 0;
            var pageindex = Convert.ToInt32(model.CurrentPageIndex);
            if (string.IsNullOrEmpty(model.zipcode))
            {
                //DO AS BEFORE. USE PAGINATION ON SOLR
                model.SolrJobListCollection = objSolrSearch.ExecuteSearchAsSearchResult1
                   (searchOption, Convert.ToInt32(model.CurrentPageIndex), model.maxRows, out TotalCount, out msg);
            }
            else
            {

                //DO PAGINATION ON SESSION
                var zips = GetNearByZipCodewithlatlong(model.mile, model.zipcode);

                searchOption.zipcode = string.Join(",", zips.Select(x => x.ZipCodeWithZero).ToList());

                var sessionKey = $"T={model.mile};{model.Tags};JT={model.jobtitle};Z={model.zipcode};L={model.City};R={model.Relevance};" +
                    $"D={model.days};CID={model.JobCategoryId};JT={model.Jobtype};MS={model.MinSalary};MS={model.MaxSalary};" +
                    $"JID={model.jobIds}; SCI={model.salertchangeId};";
                if (Session[sessionKey] == null)
                {
                    var completeCandidateList = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, 1, 1000, out TotalCount, out msg).Where(x => !string.IsNullOrEmpty(x.zip_code) && !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)).ToList();

                    var zip = FindZipCodewithlatlong(model.zipcode);

                    completeCandidateList.ForEach(x => x.miles_range = Convert.ToDecimal(HaversineFormula.Distance(zip.lat, zip.log, Convert.ToDouble(x.Latitude), Convert.ToDouble(x.Longitude))));

                    Session[sessionKey] = completeCandidateList;
                }
                var candidates = Session[sessionKey] as List<Web.SolrJobs.Helpers.SearchDocumentResultForView>;
                TotalCount = candidates.Count;

                model.SolrJobListCollection = candidates.OrderBy(x => x.miles_range).Skip(pageindex == 1 ? 0 : (pageindex - 1) * model.maxRows).Take(model.maxRows).ToList();
            }

        }
        /// <summary>
        /// sendemail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult sendemail(JobsModel model)
        {
            try
            {
                model.CretedBy = Convert.ToInt64(Session["Id"]);
                model.Id = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss"));
                _Ilogin.sendemail(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// AppliedJob
        /// </summary>
        /// <param name="model1"></param>
        /// <returns></returns>
        public JsonResult AppliedJob(JobsModel model1)
        {
            try
            {
                // applyjob
                _Ilogin.AppliedJob(model1);
                // (candidate Update by self on solr profile)

            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model1, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AppliedJob
        /// </summary>
        /// <param name="model1"></param>
        /// <returns></returns>
        public JsonResult requestmoreinfo(JobsModel model1)
        {
            try
            {
                // applyjob
                _Ilogin.requestmoreinfo(model1);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model1, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// JobSave
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult JobSave(JobsModel model)
        {
            try
            {
                _Ilogin.JobSave(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// CandidateJobapplyLogin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CandidateJobapplyLogin(LoginModel model)
        {
            try
            {
                _Ilogin.CandidateLogin(model);
                if (model.Status == 1)
                {
                    Session["Id"] = model.Id;
                    Session["Email"] = model.Email;
                    Session["UsertypeId"] = model.UsertypeId;
                    Session["RoleId"] = model.RoleId;
                    Session["UsertypeName"] = model.UsertypeName;
                    Session["Name"] = model.Name;
                    Session["FirstName"] = model.FirstName;
                    Session["LastName"] = model.LastName;
                    Session["Phone"] = model.Phone;
                    Session["Title"] = model.Title;
                    Session["Image"] = model.Image;
                    //  FormsAuthentication.SetAuthCookie(model.UsertypeName.ToString(), false);
                    if (model.KeepLogIn == 1)
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["LoginEmail"] = model.Email;
                        userInfo["Password"] = model.Password;
                        userInfo["KeepLogIn"] = model.KeepLogIn.ToString();
                        Response.Cookies.Add(userInfo);
                    }
                    else
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["LoginEmail"] = "";
                        userInfo["Password"] = "";
                        userInfo["KeepLogIn"] = model.KeepLogIn.ToString();
                        Response.Cookies.Add(userInfo);
                    }
                    var userData = JsonConvert.SerializeObject(model);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddHours(1), model.KeepLogIn == 1, userData);
                    var value = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, value));

                    var models = _Ilogin.GetAllMenuSubmenu();
                    Session["Menus"] = models;

                }
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// maintenance
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult maintenance(LoginModel model)
        {
            try
            {
                if (model.Email == "maintenance@gmail.com" && model.Password == "maintenance")
                {
                    model.Status = 1;
                }
                else
                {
                    model.Status = 0;

                }
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.Status, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// creategustcandidate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult creategustcandidate(JobsModel model)
        {
            try
            {
                string fname = "";
                model.Password = "1234";
                _Ilogin.creategustcandidate(model);
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

                if (model.Id > 0)
                {
                    // Create Candidate on time job apply



                    CandidateModel model1 = new CandidateModel();
                    model1.Id = model.Id;
                    _IobjCandidate.UpdateCandidateOnsolr(model1);

                    // (candidate Update by admin on solr profile)
                    SearchDocumentNew SearchDocument = new SearchDocumentNew();
                    SearchDocument.id = Convert.ToString(model1.Id);
                    SearchDocument.first_name = model1.Name;
                    SearchDocument.last_name = model1.LastName;
                    SearchDocument.full_name = model1.Name.Trim() + " " + model1.LastName;
                    SearchDocument.email = model1.Email;

                    if (model1.Phone != null && model1.Phone.Trim() != "")
                    {
                        SearchDocument.mobile = model1.Phone;
                    }

                    SearchDocument.created_by = Convert.ToInt64(model1.Id);
                    SearchDocument.updated_by = Convert.ToInt64(model1.Id);
                    SearchDocument.updated_date = DateTime.Now;
                    SearchDocument.ProfileCheck_Id = Convert.ToInt16(model1.ProfileCheck_Id);
                    if (model1.Title != null)
                    {
                        SearchDocument.current_job_title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model1.Title.Trim().ToLower());
                    }
                    SearchDocument.IndustryName = model1.IndustryName;
                    SearchDocument.ZipCode = model1.Zipcode;
                    SearchDocument.Latitude = model.Latitude;
                    SearchDocument.Longitude = model.Longitude;
                    SearchDocument.EducationlevelName = model1.EducationlevelName;
                    SearchDocument.jobTypeId = Convert.ToString(model1.JobTypeId);
                    SearchDocument.jobType = model1.JobTypeName;
                    SearchDocument.profile_image = model1.FileName;
                    if (model1.location != null && model1.location != "")
                    {
                        SearchDocument.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model1.location.Trim().ToLower());
                    }
                    SearchDocument.Description = Convert.ToString(model1.description);
                    SearchDocument.DesiredTitle1 = model1.DesiredTitle1;
                    SearchDocument.DesiredTitle2 = model1.DesiredTitle2;
                    SearchDocument.Experience_Name = model1.experienceName;
                    if (model1.experience != null && model1.experience.Trim() != "")
                    {
                        if (Convert.ToInt32(model1.experience) > 0)
                        {
                            SearchDocument.experience = model1.experience;
                        }
                        else
                        {
                            SearchDocument.experience = "0";
                        }
                    }
                    SearchDocument.statusid = 1;
                    SearchDocument.CurrentSalary = model1.CurrentSalary;

                    SearchDocument.CurrentSalaryId = Convert.ToInt64(model1.CurrentSalaryId);

                    SearchDocument.IndustryName = Convert.ToString(model1.IndustryName);
                    SearchDocument.IndustryId = Convert.ToInt16(model1.Industry);
                    SearchDocument.Candidateskill = model1.Candidateskill;
                    SearchDocument.CandidateTag = model1.CandidateTag;

                    SolrIndex.IndexCandidate(SearchDocument, 1, true);


                    //SearchDocument.profile_image = "/FileUpload/candidatedefaultImage/No_image_available.PNG";
                    //if (fname != "")
                    //{
                    //    string ext = System.IO.Path.GetExtension(fname).ToLower();
                    //    SearchDocument.Resume_Content = SolrIndex.GetTxtFromFile(fname);
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
        /// AutoComplete
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AutoComplete(string location)
        {
            LoginModel model = new LoginModel();
            try
            {
                model.location = location;
                _Ilogin.GetLocation(model);
            }
            catch (Exception)
            {

                throw;
            }
            return Json(model.CollectionLocation);
        }

        /// <summary>
        /// NewletterCreate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult NewletterCreate(LoginModel model)
        {
            try
            {

                _Ilogin.NewletterCreate(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// savejobalert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult savejobalert(jobalertviewmodel model)
        {
            try
            {
                _Ilogin.savejobalert(model);
                model.statusid = 1;
            }
            catch (Exception ex)
            {

                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model.statusid, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Jobsautocomplete
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Jobsautocomplete(string prefix)
        {
            JobsModel model = new JobsModel();
            try
            {
                model.Name = prefix;
                _Ilogin.Jobsautocomplete(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json((new string(model.JobsCollection.SelectMany(x => x.jobtitle + ",").ToArray())).Split(','), JsonRequestBehavior.AllowGet);

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
                _Iclient.Candidateconversationsaved(model);
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        #region ContentResult
        [HttpGet]
        public ContentResult PostJobsOnZipRecruiter()
        {
            _Ilogin.ZipRecruiter();
            string xml = System.IO.File.ReadAllText(Server.MapPath("~/XML/sharejob.xml"));
            return Content(xml, "text/xml");
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

        public ActionResult solrzipcodeLatLong()
        {
            var origin = "76105";
            var destination = "76106";

            System.Threading.Thread.Sleep(1000);
            int distance = 0;
            string key = "AIzaSyAz8lf6UZeLBkP5w6o3sYFJvJ9ZZ06IJSY";

            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=" + key;
            url = url.Replace(" ", "+");
            string content = fileGetContents(url);
            JObject o = JObject.Parse(content);
            try
            {
                distance = (int)o.SelectToken("routes[0].legs[0].distance.text");

            }
            catch
            {

            }



            CandidateModel model = new CandidateModel();
            string multiCharString = "d";

            string[] multiArray = multiCharString.Split(new Char[] { ',' });
            foreach (string author in multiArray)
            {
                model.Id = Convert.ToInt64(author);

                _IobjCandidate.UpdateCandidateOnsolr(model);

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


            return View();
        }

        public ActionResult CoreUpdate()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = _IobjCandidate.CoreUpdate();
                CandidateModel model = new CandidateModel();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    model.Id = Convert.ToInt64(dt.Rows[i]["Id"]);
                    _IobjCandidate.UpdateCandidateOnsolr(model);

                    if (string.IsNullOrEmpty(model.Zipcode) == false)
                    {
                        // (candidate Update by self on solr profile)
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
                        System.Threading.Thread.Sleep(2000);
                    }

                }



            }
            catch (Exception ex)
            {

            }
            return View();
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

        #endregion
    }
}