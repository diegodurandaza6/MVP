using SolrNet.Attributes;
using System;

namespace Web.SolrJobs.Helpers
{
    public class SearchJobNew
    {
        [SolrField(SearchDocumentMetadataNew.id)]
        public long Id { get; set; }


        [SolrField(SearchDocumentMetadataNew.jobtitle)]
        public string jobtitle { get; set; }

        [SolrField(SearchDocumentMetadataNew.StateId)]
        public long StateId { get; set; }


        [SolrField(SearchDocumentMetadataNew.jobtypeid)]
        public long jobtypeid { get; set; }

        [SolrField(SearchDocumentMetadataNew.jobtype)]
        public string JobType { get; set; }






        [SolrField(SearchDocumentMetadataNew.description)]
        public string Description { get; set; }

        [SolrField(SearchDocumentMetadataNew.applicationurl)]
        public string applicationurl { get; set; }



        [SolrField(SearchDocumentMetadataNew.companyname)]
        public string CompanyName { get; set; }

        [SolrField(SearchDocumentMetadataNew.website)]
        public string website { get; set; }

        [SolrField(SearchDocumentMetadataNew.tagline)]
        public string tagline { get; set; }

        [SolrField(SearchDocumentMetadataNew.twitterusername)]
        public string twitterusername { get; set; }

        [SolrField(SearchDocumentMetadataNew.logo)]
        public string logo { get; set; }



        [SolrField(SearchDocumentMetadataNew.accounttypeid)]
        public long accounttypeid { get; set; }

        [SolrField(SearchDocumentMetadataNew.accounttypename)]
        public string accounttypename { get; set; }

        [SolrField(SearchDocumentMetadataNew.jobstatusid)]
        public long jobstatusid { get; set; }



        [SolrField(SearchDocumentMetadataNew.MinimumSalary)]
        public string MinimumSalary { get; set; }



        [SolrField(SearchDocumentMetadataNew.MaximumSalary)]
        public string MaximumSalary { get; set; }



        [SolrField(SearchDocumentMetadataNew.MinSalary)]
        public string MinSalary { get; set; }



        [SolrField(SearchDocumentMetadataNew.MaxSalary)]
        public string MaxSalary { get; set; }












        [SolrField(SearchDocumentMetadataNew.MinimumExperience)]
        public string MinimumExperience { get; set; }
        [SolrField(SearchDocumentMetadataNew.MaximumExperience)]
        public string MaximumExperience { get; set; }





        [SolrField(SearchDocumentMetadataNew.CountryId)]
        public long CountryId { get; set; }

        [SolrField(SearchDocumentMetadataNew.CountryName)]
        public string CountryName { get; set; }

        [SolrField(SearchDocumentMetadataNew.statusid)]
        public long statusid { get; set; }


        [SolrField(SearchDocumentMetadataNew.StateName)]
        public string StateName { get; set; }

        [SolrField(SearchDocumentMetadataNew.CityName)]
        public string CityName { get; set; }



        [SolrField(SearchDocumentMetadataNew.CategoryId)]
        public long CategoryId { get; set; }





        [SolrField(SearchDocumentMetadataNew.CategoryName)]
        public string CategoryName { get; set; }


        [SolrField(SearchDocumentMetadataNew.SubCategoryName)]
        public string SubCategoryName { get; set; }




        [SolrField(SearchDocumentMetadataNew.Designation)]
        public string Designation { get; set; }


        [SolrField(SearchDocumentMetadataNew.FileName)]
        public string FileName { get; set; }

        [SolrField(SearchDocumentMetadataNew.File_Content)]
        public string File_Content { get; set; }



        [SolrField(SearchDocumentMetadataNew.created_date)]
        public DateTime created_date { get; set; }

        [SolrField(SearchDocumentMetadataNew.updated_date)]
        public DateTime updated_date { get; set; }

        [SolrField(SearchDocumentMetadataNew.updated_by)]
        public long updated_by { get; set; }

        [SolrField(SearchDocumentMetadataNew.created_by)]
        public long created_by { get; set; }

        [SolrField(SearchDocumentMetadataNew.jobstatusname)]
        public string StatusName { get; set; }

        [SolrField(SearchDocumentMetadataNew.skill)]
        public string skill { get; set; }

        public string JobStatusName { get; set; }



        [SolrField(SearchDocumentMetadataNew.ImagePath)]
        public string ImagePath { get; set; }




        [SolrField(SearchDocumentMetadataNew.zip_code)]
        public string zip_code { get; set; }



        [SolrField(SearchDocumentMetadataNew.Latitude)]
        public string Latitude { get; set; }

        [SolrField(SearchDocumentMetadataNew.Longitude)]
        public string Longitude { get; set; }




        [SolrField(SearchDocumentMetadataNew.milesrange)]
        public Decimal miles_range { get; set; }




        [SolrField(SearchDocumentMetadataNew._location)]
        public string location { get; set; }



        [SolrField(SearchDocumentMetadataNew._Tags)]
        public string Tags { get; set; }


        [SolrField(SearchDocumentMetadataNew.postedd_date)]
        public string posteddate { get; set; }




        [SolrField(SearchDocumentMetadataNew.id_s)]
        public string ids { get; set; }


    }


}
