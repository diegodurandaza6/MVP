using System;

namespace Web.SolrJobs.Helpers
{

    public class IndexedSearchOption
    {

        public long CategoryId { get; set; }
        public long JobTypeId { get; set; }
        public long CityId { get; set; }
        public long CountryId { get; set; }
        public long CreatedBy { get; set; }
        public string JobTitle { get; set; }
        public int SearchType { get; set; }
        public long Days { get; set; }
        public string zipcode { get; set; }

        public long StateId { get; set; }
        public string CityName { get; set; }
        public long StatusId { get; set; }
        public int TotalRecord { get; set; }
        public long UserId { get; set; }
        public Int32 PageSize { get; set; }
        public Int32 PageNumber { get; set; }
        public long jobstatusid { get; set; }
        public long CurrentUserId { get; set; }
        public long ClientId { get; set; }
        public string CategoryName { get; set; }
        public string JobType { get; set; }

        public long salertchangeId { get; set; }
        //public string SearchText { get; set; }

        // public List<string> OrWords { get; set; }

        // public Int32 JobTypeId { get; set; }
        // public Int32 ExperienceLevelId { get; set; }
        //// public Int32 DayPosted { get; set; }


        // public Int32 MinExp { get; set; }
        // public Int32 MaxExp { get; set; }

        // public Int32 MinHourlyPayRate { get; set; }
        // public Int32 MaxHourlyPayRate { get; set; }

        // public Int32 StateId { get; set; }
        // public Int32 CityId { get; set; }
        // public Int32 Gender { get; set; }
        // public Int32 PositionId { get; set; }
        // public Int32 VisaStatusId { get; set; }

        // public int SearchType { get; set; } //1 AND , 2 or

        // public Int32 UserId { get; set; }
        // public string SearchName { get; set; }

        // public Int32 TotalRecord { get; set; }

        public string location { get; set; }
        // public Int32 CountryID { get; set; }

        public long AscDescId { get; set; }
        public string N_Zipcode { get; set; }

        public string Tags { get; set; }
        public string jobIds { get; set; }
        public string MinSalary { get; set; }
        public string MaxSalary { get; set; }

    }
}
