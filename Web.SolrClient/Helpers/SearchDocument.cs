using SolrNet.Attributes;
using System;

namespace Web.SolrClient.Helpers
{
    public class SearchDocumentNew
    {
        [SolrField(SearchDocumentMetadataNew.id)]
        public string id { get; set; }
        [SolrField(SearchDocumentMetadataNew.first_name)]
        public string first_name { get; set; }

        [SolrField(SearchDocumentMetadataNew.last_name)]
        public string last_name { get; set; }

        [SolrField(SearchDocumentMetadataNew.email)]
        public string email { get; set; } 

        [SolrField(SearchDocumentMetadataNew.CityName)]
        public string CityName { get; set; }


        [SolrField(SearchDocumentMetadataNew.Zip_Code)]
        public string ZipCode { get; set; }


        [SolrField(SearchDocumentMetadataNew.Longitude)]
        public string Longitude { get; set; }


        [SolrField(SearchDocumentMetadataNew.milesrange)]
        public Decimal miles_range { get; set; }


        [SolrField(SearchDocumentMetadataNew.Latitude)]
        public string Latitude { get; set; }

        [SolrField(SearchDocumentMetadataNew.EducationlevelName)]
        public string EducationlevelName { get; set; }


        [SolrField(SearchDocumentMetadataNew.ImagePath)]
        public string ImagePath { get; set; }




        [SolrField(SearchDocumentMetadataNew.IsFavorites)]
        public Int64 IsFavorites { get; set; }



        [SolrField(SearchDocumentMetadataNew.mobile)]
        public string mobile { get; set; }


        [SolrField(SearchDocumentMetadataNew.current_job_title)]
        public string current_job_title { get; set; }


        [SolrField(SearchDocumentMetadataNew.job_TypeId)]
        public string jobTypeId { get; set; }

        [SolrField(SearchDocumentMetadataNew.job_Type)]
        public string jobType { get; set; }




        [SolrField(SearchDocumentMetadataNew.statusid)]
        public Int32 statusid { get; set; }


        [SolrField(SearchDocumentMetadataNew.Industry_Id)]
        public Int32 IndustryId { get; set; }




        [SolrField(SearchDocumentMetadataNew.ProfileCheckId)]
        public Int32 ProfileCheck_Id { get; set; }



        [SolrField(SearchDocumentMetadataNew.created_date)]
        public DateTime created_date { get; set; }

        [SolrField(SearchDocumentMetadataNew.updated_date)]
        public DateTime updated_date { get; set; }

        [SolrField(SearchDocumentMetadataNew.created_by)]
        public long created_by { get; set; }

        [SolrField(SearchDocumentMetadataNew.updated_by)]
        public long updated_by { get; set; }




        [SolrField(SearchDocumentMetadataNew.Resume_Content)]
        public string Resume_Content { get; set; }



        [SolrField(SearchDocumentMetadataNew.profile_image)]
        public string profile_image { get; set; }


        [SolrField(SearchDocumentMetadataNew.industry_name)]
        public string IndustryName { get; set; }



        [SolrField(SearchDocumentMetadataNew._Description)]
        public string Description { get; set; }


        [SolrField(SearchDocumentMetadataNew.DesiredTitle_1)]
        public string DesiredTitle1 { get; set; }

        [SolrField(SearchDocumentMetadataNew.DesiredTitle_2)]
        public string DesiredTitle2 { get; set; }


        [SolrField(SearchDocumentMetadataNew.location)]
        public string location { get; set; }


        [SolrField(SearchDocumentMetadataNew.experienceid)]
        public string experience { get; set; }





        [SolrField(SearchDocumentMetadataNew.Experience_Name)]
        public string Experience_Name { get; set; }



        [SolrField(SearchDocumentMetadataNew.CurrentSalary_Id)]
        public long CurrentSalaryId { get; set; }



        [SolrField(SearchDocumentMetadataNew.Current_Salary)]
        public string CurrentSalary { get; set; }




        [SolrField(SearchDocumentMetadataNew.certifications)]
        public string Certifications { get; set; }










        [SolrField(SearchDocumentMetadataNew.CandidateTag)]
        public string CandidateTag { get; set; }


        [SolrField(SearchDocumentMetadataNew.Candidateskill)]
        public string Candidateskill { get; set; }
        public long CId { get; set; }


        [SolrField(SearchDocumentMetadataNew.full_name)]
        public string full_name { get; set; }


    }


}
