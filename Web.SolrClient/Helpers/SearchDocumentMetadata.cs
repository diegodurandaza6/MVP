namespace Web.SolrClient.Helpers
{
    public class SearchDocumentMetadataNew
    {

        public const string Candidateskill = "Candidateskill";


        public const string id = "id";
        public const string first_name = "first_name";
        public const string last_name = "last_name";

        public const string CandidateTag = "CandidateTag";

        public const string certifications = "certifications";


        public const string email = "email";

         
        public const string mobile = "mobile";
        public const string created_by = "created_by";
        public const string created_date = "created_date";
        public const string updated_by = "updated_by";
        public const string updated_date = "updated_date";
        public const string statusid = "statusid";
        public const string current_job_title = "current_job_title";
        public const string industry_name = "industry_name";
         
        public const string CityName = "CityName";
        public const string EducationlevelName = "EducationlevelName";
        public const string Resume_Content = "Resume_Content";
        public const string profile_image = "profile_image";
        public const string File_Content = "_text_";
        public const string Zip_Code = "Zip_Code";

        public const string Longitude = "Longitude";
        public const string Latitude = "Latitude";

        public const string milesrange = "milesrange";

        public const string job_TypeId = "job_TypeId";
        public const string job_Type = "job_Type";

        public const string ImagePath = "ImagePath";
        public const string ProfileCheckId = "ProfileCheckId";

        public const string _Description = "description";

        public const string DesiredTitle_1 = "desiredtitle1";
        public const string DesiredTitle_2 = "desiredtitle2";

        public const string location = "location";

        public const string Industry_Id = "Industry_Id";
        public const string experienceid = "experienceid";


        public const string CurrentSalary_Id = "CurrentSalary_Id";
        public const string Current_Salary = "Current_Salary";


        public const string Experience_Name = "Experience_Name";

        public const string full_name = "full_name";


        public const string IsFavorites = "IsFavorites";


        [SearchResult(Display = true)]
        public static string Is_Favorites { get { return IsFavorites; } }







        [SearchResult(Display = true)]
        public static string Full_Name { get { return full_name; } }




        [SearchResult(Display = true)]
        public static string Current_Job_Title { get { return current_job_title; } }







        [SearchResult(Display = true)]
        public static string Certifications { get { return certifications; } }








        [SearchResult(Display = true)]
        public static string Candidates_kill { get { return Candidateskill; } }






        [SearchResult(Display = true)]
        public static string CurrentSalaryId { get { return CurrentSalary_Id; } }

        [SearchResult(Display = true)]
        public static string CurrentSalary { get { return Current_Salary; } }


        [SearchResult(Display = true)]
        public static string ExperienceName { get { return Experience_Name; } }



        [SearchResult(Display = true)]
        public static string Candidate_Tag { get { return CandidateTag; } }




        [SearchResult(Display = true)]
        public static string IndustryId { get { return Industry_Id; } }


        [SearchResult(Display = true)]
        public static string Location { get { return location; } }




        [SearchResult(Display = true)]
        public static string Description { get { return _Description; } }

       
        [SearchResult(Display = true)]
        public static string DesiredTitle1 { get { return DesiredTitle_1; } }


        [SearchResult(Display = true)]
        public static string DesiredTitle2 { get { return DesiredTitle_2; } }



        [SearchResult(Display = true)]
        public static string FileContent { get { return File_Content; } }




        [SearchResult(Display = true)]
        public static string ProfileCheck_Id { get { return ProfileCheckId; } }




        [SearchResult(Display = true)]
        public static string Image_Path { get { return ImagePath; } }




        [SearchResult(Display = true)]
        public static string jobTypeId { get { return job_TypeId; } }

        [SearchResult(Display = true)]
        public static string JobType { get { return job_Type; } }


        [SearchResult(Display = true)]
        public static string ZipCode { get { return Zip_Code; } }


        [SearchResult(Display = true)]
        public static string zip_Longitude { get { return Longitude; } }


        [SearchResult(Display = true)]
        public static string zip_Latitude { get { return Latitude; } }



        [SearchResult(Display = true)]
        public static string mile_srange { get { return milesrange; } }


        [SearchResult(Display = true)]
        public static string Educationlevel_Name { get { return EducationlevelName; } }


        [SearchResult(Display = true)]
        public static string Id { get { return id; } }


        [SearchResult(Display = true)]
        public static string IndustryName { get { return industry_name; } }


        [SearchResult(Display = true)]
        public static string FirstName { get { return first_name; } }
        [SearchResult(Display = true)]
        public static string LastName { get { return last_name; } }




        [SearchResult(Display = true)]
        public static string Email { get { return email; } }

        
       

        [SearchResult(Display = true)]
        public static string City_Name { get { return CityName; } }


        [SearchResult(Display = true)]
        public static string Mobile { get { return mobile; } }



        [SearchResult(Display = true)]
        public static string StatusId { get { return statusid; } }
        [SearchResult(Display = true)]
        public static string CreatedBy { get { return created_by; } }
        [SearchResult(Display = true)]
        public static string CreatedDate { get { return created_date; } }


        [SearchResult(Display = true)]
        public static string UpdatedBy { get { return updated_by; } }


        [SearchResult(Display = true)]
        public static string UpdatedDate { get { return updated_date; } }



        [SearchResult(Display = true, Highlight = true)]
        public static string ResumeContent { get { return Resume_Content; } }


        [SearchResult(Display = true)]
        public static string ProfileImage { get { return profile_image; } }










    }

}
