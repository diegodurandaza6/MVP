using System.Collections.Generic;

namespace Web.Model.Admin
{
    public class Tagsmodel
    {
        public string location;
        public string description;

        public long CurrentSalaryId { get; set; }

        public string CurrentSalary { get; set; }

        public string experienceName { get; set; }
        public string experience { get; set; }
        public long Id { get; set; }
        public string CandidateTag { get; set; }
        public long CreateBy { get; set; }
        public long TagtypeId { get; set; }
        public long CId { get; set; }

        public IEnumerable<Tagsmodel> candidatetagcollection { get; set; }
        public long TagId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfileCheck_Id { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string IndustryName { get; set; }
        public string StateId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string Zipcode { get; set; }
        public long Industry { get; set; }
        public string EducationlevelName { get; set; }
        public long JobTypeId { get; set; }
        public string JobType { get; set; }
        public string DesiredTitle1 { get; set; }
        public string DesiredTitle2 { get; set; }
        public string FileName { get; set; }
        public string Resumefile { get; set; }

        public int tagtype_Id { get; set; }
    }
}
