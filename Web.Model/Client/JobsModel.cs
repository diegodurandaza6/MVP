using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Model.Common; 
using Web.SolrJobs.Helpers;

namespace Web.Model.Client
{
    public class JobsModel
    {
        public string qualificationName;
        public string createddate;
        public DateTime CreDate { get; set; }
        public string website;
        public long applyedStatus;
        public long requestmoreinfo;
        public string applyedCount;
        public long applyjobId;
        public long salertchangeId { get; set; }
        public DateTime date { get; set; }
        public long zip { get; set; }
        public string JIds { get; set; }

        public string result { get; set; }
        public long KeepLogIn { get; set; }
        public long accounttype { get; set; }

        public IEnumerable<DropDownViewModel> tagcollection { get; set; }

        public long JobPostStatus { get; set; }
        public IEnumerable<JobsModel> interviewlistcollection { get; set; }

        public IEnumerable<JobsModel> applicantlistcollection { get; set; }

        public long PipeLineId { get; set; }
        public IEnumerable<JobsModel> submissionprofilelistcollection { get; set; }
        public IEnumerable<JobsModel> submissionprofilecollection { get; set; }
        public string locationKey { get; set; }
        public IEnumerable<JobsModel> resentjobcollection { get; set; }
        public string searchId { get; set; }
        public string searchkeyword { get; set; }
        public long checkId { get; set; }
        public string location { get; set; }
        public long applicantcount { get; set; }
        public long Featured { get; set; }
        public long Relevance { get; set; }
        public long viewcount { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Ids { get; set; }
        public long SId { get; set; }
        public long days { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Jobtype { get; set; }
        public string description { get; set; }
        public string DesiredTitle2 { get; set; }
        public string DesiredTitle1 { get; set; }
        public string subject { get; set; }
        public long SharedJob { get; set; }

        public string Jobcatagory { get; set; }
        public string jobtitle { get; set; }
        public string KeySkills { get; set; }
        public string Tags { get; set; }
        public long TId { get; set; }
        public long DesignationId { get; set; }
        public string Designation { get; set; }
        public string WorkExperienceMin { get; set; }
        public string EducationlevelsName { get; set; }
        public string MinSalary { get; set; }
        public string MaxSalary { get; set; }
        public long usertype { get; set; }
        public string WorkExperienceMax { get; set; }

        public long JobSearchId { get; set; }
        public long ClientId { get; set; }


        public string JSs { get; set; }
        public long ParentId { get; set; }
        public long JobTypeId { get; set; }
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public string City { get; set; }
        public string Keyword { get; set; }
        public long JobStatusId { get; set; }
        public long StatusId { get; set; }
        public long JobCategoryId { get; set; }
        public long QualificationId { get; set; }
        [AllowHtml]
        public string JobDescription { get; set; }
        public string sortdescription { get; set; }
        public long? CurrentPageIndex { get; set; }
        public long? pageno { get; set; }
        public int maxRows { get; set; }
        public long OffsetId { get; set; }

        public int TotalRowCount { get; set; }
        public int PageCount { get; set; }
        public int indexlegth { get; set; }
        public IEnumerable<DropDownViewModel> JobSearchdaysCollection { get; set; }

        public IEnumerable<DropDownViewModel> ClientCollection { get; set; }

        public IEnumerable<JobsModel> MyappliedJobsCollection { get; set; }

        public IEnumerable<DropDownViewModel> LatestCandidatesCollection { get; set; }
        public IEnumerable<DropDownViewModel> JobTypeCollection { get; set; }
        public IEnumerable<DropDownViewModel> CountryCollection { get; set; }
        public IEnumerable<DropDownViewModel> StateCollection { get; set; }


        public IEnumerable<JobsModel> SearchCollection { get; set; }

        public IEnumerable<DropDownViewModel> JobStatusCollection { get; set; }
        public IEnumerable<DropDownViewModel> JobCategoryCollection { get; set; }
        public IEnumerable<DropDownViewModel> JobDeginationCollection { get; set; }
        public IEnumerable<JobsModel> JobsCollection { get; set; }
        public IEnumerable<DropDownViewModel> SkillCollection { get; set; }
        public IEnumerable<JobsModel> MySavedJobsCollection { get; set; }

        public IEnumerable<JobsModel> JobQualficationCollection { get; set; }
        public string JobStatusName { get; set; }
        public string JobTypeName { get; set; }
        public string CountyName { get; set; }
        public string StateName { get; set; }
        public string DesignationName { get; set; }
        public string JobCategoryName { get; set; }
        public string CityName { get; set; }
        public string Mobile { get; set; }
        public string Resumefile { get; set; }
        public string experienceName { get; set; }

        public string experience { get; set; }
        public string Candidateskill { get; set; }
        public string CurrentSalary { get; set; }
        public long CurrentSalaryId { get; set; }
        public string CandidateTag { get; set; }

        public string FileName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountryName { get; set; }
        public string CompanyStateName { get; set; }
        public string CompanyCityName { get; set; }
        public string Address { get; set; }
        public string zipcode { get; set; }
        public string ProfileCheck_Id { get; set; }
        public string IndustryName { get; set; }

        public string Industry { get; set; }
        public long mile { get; set; }
        public long UsertypeId { get; set; }
        public string UsertypeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public long noofjob { get; set; }
        public string RandomNumber { get; set; }
        public long SavedStatus { get; set; }
        public long JobId { get; set; }
        public string PageUrl { get; set; }
        public long LeftJobs { get; set; }
        public string ValidPlandate { get; set; }

        public DateTime Validdate { get; set; }

        public string imagepath { get; set; }
        public string FilePath { get; set; }
        public IEnumerable<JobsModel> Jobsuploadresumecollection { get; set; }
        public long CretedBy { get; set; }

        public int JobCountData { get; set; }
        public List<JobsModel> JobListCollection { get; set; }
        public List<Web.SolrJobs.Helpers.SearchDocumentResultForView> SolrJobListCollection { get; set; }
        public IEnumerable<DropDownViewModel> Milescollection { get; set; }
        public long InterviewSId { get; set; }
        public string ClientName { get; set; }
        public long CandidateId { get; set; }
        public List<SearchDocumentResultForView> CandiateList { get; set; }
        public string Dayscount { get; set; }
        public IEnumerable<JobsModel> SimilarJobscollection { get; set; }
        public string jobIds { get; set; }
        public string interviewStatus { get; set; }
        public List<JobsModel> applicantlistviewcollection { get; set; }
        public long InterviewStatusId { get; set; }
        public long NewCandidatecount { get; set; }
        public long Interviewcount { get; set; }
        public long pipelinemessagecount { get; set; }
        public long SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public IEnumerable<JobsModel> SubCategoryCollection { get; set; }
        public string SharedJobDate { get; set; }
        public string PostedBy { get; set; }
        public string JobLocation { get; set; }
        public string ClientName_Admin { get; set; }
        
        public string FileName_Company { get; set; }

        public long PositionLevelId { get; set; }
        public string PositionLevelName { get; set; }
        public IEnumerable<JobsModel> PositionLevelCollection { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

