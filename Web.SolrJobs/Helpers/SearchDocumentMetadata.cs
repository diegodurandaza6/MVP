namespace Web.SolrJobs.Helpers
{
    public class SearchDocumentMetadataNew
    {
        public const string id = "id";
        public const string jobtitle = "jobtitle";
        public const string jobtypeid = "jobtypeid";
        public const string jobtype = "jobtype";
        public const string description = "description";
        public const string applicationurl = "applicationurl";

        public const string companyname = "companyname";
        public const string website = "website";
        public const string tagline = "tagline";
        public const string twitterusername = "twitterusername";
        public const string logo = "logo";


        public const string accounttypeid = "accounttypeid";
        public const string accounttypename = "accounttypename";
        public const string jobstatusid = "jobstatusid";

        public const string jobstatusname = "jobstatusname";
        public const string CountryId = "CountryId";

        public const string CountryName = "CountryName";
        public const string StateName = "StateName";

        public const string CityName = "CityName";
        public const string CategoryId = "CategoryId";
        public const string CategoryName = "CategoryName";

        public const string SubCategoryName = "SubCategoryName";

        public const string Designation = "Designation";
        public const string FileName = "FileName";
        public const string File_Content = "_text_";
        public const string statusid = "statusid";
        public const string created_by = "created_by";
        public const string created_date = "created_date";
        public const string updated_by = "updated_by";
        public const string updated_date = "updated_date";

        public const string JobCode = "JobCode";
        public const string skill = "skill";

        public const string MinimumSalary = "MinimumSalary";
        public const string MaximumSalary = "MaximumSalary";


        public const string MinSalary = "MinSalary";
        public const string MaxSalary = "MaxSalary";







        public const string MinimumExperience = "MinimumExperience";
        public const string MaximumExperience = "MaximumExperience";

        public const string StateId = "StateId";
        public const string ImagePath = "ImagePath";



        public const string _location = "_location";
        public const string _Tags = "_Tags";

        public const string postedd_date = "postedd_date";


        public const string zip_code = "zip_code";


        public const string Latitude = "Latitude";
        public const string Longitude = "Longitude";
        public const string milesrange = "milesrange";

        public const string id_s = "id_s";







        [SearchResult(Display = true)]
        public static string ids { get { return id_s; } }




        [SearchResult(Display = true)]
        public static string posteddate { get { return postedd_date; } }



        [SearchResult(Display = true)]
        public static string zipcode { get { return zip_code; } }

        [SearchResult(Display = true)]
        public static string Zip_Latitude { get { return Latitude; } }

        [SearchResult(Display = true)]
        public static string Zip_Longitude { get { return Longitude; } }



        [SearchResult(Display = true)]
        public static string mile_srange { get { return milesrange; } }



        [SearchResult(Display = true)]
        public static string Tags { get { return _Tags; } }




        [SearchResult(Display = true)]
        public static string location { get { return _location; } }



        [SearchResult(Display = true)]
        public static string Image_Path { get { return ImagePath; } }




        [SearchResult(Display = true)]
        public static string Id { get { return id; } }
        [SearchResult(Display = true)]
        public static string job_title { get { return jobtitle; } }
        [SearchResult(Display = true)]
        public static string jobtype_id { get { return jobtypeid; } }
        [SearchResult(Display = true)]
        public static string job_type { get { return jobtype; } }
        [SearchResult(Display = true)]
        public static string Description { get { return description; } }
        [SearchResult(Display = true)]
        public static string application_url { get { return applicationurl; } }

        [SearchResult(Display = true)]
        public static string company_name { get { return companyname; } }
        [SearchResult(Display = true)]
        public static string web_site { get { return website; } }
        [SearchResult(Display = true)]
        public static string tag_line { get { return tagline; } }
        [SearchResult(Display = true)]
        public static string twitteruser_name { get { return twitterusername; } }
        [SearchResult(Display = true)]
        public static string Logo { get { return logo; } }
        [SearchResult(Display = true)]

        public static string accounttype_id { get { return accounttypeid; } }
        [SearchResult(Display = true)]
        public static string accounttype_name { get { return accounttypename; } }
        [SearchResult(Display = true)]
        public static string jobstatus_id { get { return jobstatusid; } }
        [SearchResult(Display = true)]







        public static string jobstat_usname { get { return jobstatusname; } }

        [SearchResult(Display = true)]
        public static string Country_Id { get { return CountryId; } }
        [SearchResult(Display = true)]
        public static string Country_Name { get { return CountryName; } }

        [SearchResult(Display = true)]
        public static string State_Name { get { return StateName; } }

        [SearchResult(Display = true)]
        public static string City_Name { get { return CityName; } }
        [SearchResult(Display = true)]
        public static string Category_Id { get { return CategoryId; } }
        [SearchResult(Display = true)]
        public static string Category_Name { get { return CategoryName; } }
        [SearchResult(Display = true)]


        public static string SubCategory_Name { get { return SubCategoryName; } }
        [SearchResult(Display = true)]


        public static string designation { get { return Designation; } }
        [SearchResult(Display = true)]


        public static string File_Name { get { return FileName; } }
        [SearchResult(Display = true, Highlight = true)]
        public static string FileContent { get { return File_Content; } }
        [SearchResult(Display = true)]

        public static string status_id { get { return statusid; } }
        [SearchResult(Display = true)]
        public static string createdby { get { return created_by; } }

        [SearchResult(Display = true)]
        public static string createddate { get { return created_date; } }
        [SearchResult(Display = true)]
        public static string updatedby { get { return updated_by; } }
        [SearchResult(Display = true)]
        public static string updateddate { get { return updated_date; } }


        [SearchResult(Display = true)]
        public static string Job_Code { get { return JobCode; } }

        [SearchResult(Display = true)]
        public static string skills { get { return skill; } }


        [SearchResult(Display = true)]
        public static string minimumSalary { get { return MinimumSalary; } }


        [SearchResult(Display = true)]
        public static string maximumSalary { get { return MaximumSalary; } }



        [SearchResult(Display = true)]
        public static string minSalary { get { return MinSalary; } }


        [SearchResult(Display = true)]
        public static string maxSalary { get { return MaxSalary; } }










        [SearchResult(Display = true)]
        public static string minimumExperience { get { return MinimumExperience; } }





        [SearchResult(Display = true)]
        public static string maximumExperience { get { return MaximumExperience; } }



        [SearchResult(Display = true)]
        public static string State_Id { get { return StateId; } }
    }

}
