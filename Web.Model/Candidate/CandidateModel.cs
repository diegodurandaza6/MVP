
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Model.Candidate
{
    public class CandidateModel
    {
        public string p_Id { get; set; }
        public string educationlevels;
        public string jobtypeName;
        public long refrenceId;
        public string imageFile;
        public string jobtitle;
        public long sharedjobapplyId;
        public string groupcandidateId;

        public long CompanyId { get; set; }
        public long Featured { get; set; }
        public long zip { get; set; }
        public IEnumerable<DropDownViewModel> candidatelistcollection { get; set; }
        public string Relocation { get; set; }
        public string ClientFName { get; set; }
        public IEnumerable<CandidateModel> Clientnotecollection { get; set; }

        public IEnumerable<ClientModel> MileCollection { get; set; }


        public long MileId { get; set; }
        public long gid { get; set; }
        public IEnumerable<CandidateModel> tagscollection { get; set; }
        public int Typeid { get; set; }
        public long TagtypeId { get; set; }
        public string tags { get; set; }
        public IEnumerable<CandidateModel> candidatetagviewcollection { get; set; }

        public IEnumerable<DropDownViewModel> CompanyColloction { get; set; }

        public string ClientNote { get; set; }
        public IEnumerable<DropDownViewModel> candidatetagvaluecollection { get; set; }
        public long checkzipcode { get; set; }
        public long mile { get; set; }
        public long SubmitedByAdmin { get; set; }

        public string paymentPlandatecount { get; set; }

        public string CandidateTag { get; set; }

        public string paymentcount { get; set; }

        public long applicanttypeId { get; set; }
        public IEnumerable<CandidateModel> candidatesharedjobcollection { get; set; }
        public List<CandidateModel> JobListCollection { get; set; }
      

        public IEnumerable<CandidateModel> interviewListCollection { get; set; }

        public string locationKey { get; set; }
        public string sharedJobCheckId { get; set; }

        public string JobType { get; set; }
        public string key { get; set; }
        public long jobStatus { get; set; }
        public long InterviewSId { get; set; }
        public string skill { get; set; }
        public string percentage { get; set; }
        public string expectedSalary { get; set; }
        public string educationlevel { get; set; }
        public string expectedSalaryId { get; set; }
        public long Jobids { get; set; }
        public long? CurrentPageIndex { get; set; }
        public int maxRows { get; set; }
        public long OffsetId { get; set; }

        public int TotalRowCount { get; set; }
        public int PageCount { get; set; }
        public int indexlegth { get; set; }


        public long Industry { get; set; }
        public long JobTypeId { get; set; }
        public string JSs { get; set; }
        public string JIds { get; set; }


        public long CandidateId { get; set; }
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long tid { get; set; }
        public string Ids { get; set; }
        public long PortfolioId { get; set; }
        public string PorfileDescerption { get; set; }
        [AllowHtml]
        public string VideoUrl { get; set; }

        public string JobPostingUrl { get; set; }
        public string PreferredEMail { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string CandidateName { get; set; }
        public string CandidatePhone { get; set; }
        public string Phone { get; set; }
        public string Education { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public long StatusId { get; set; }
        public long favoriteStatusId { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
        public string FileUpload { get; set; }
        public long TabId { get; set; }
        public string Password { get; set; }
        public string Keyword { get; set; }
        public string Title { get; set; }
        public string DesiredTitle1 { get; set; }
        public string DesiredTitle2 { get; set; }
        public string VideoTitle { get; set; }
        public long UserId { get; set; }
        public long AccountType { get; set; }

        public string salt { get; set; }
        public string CId { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public string experience { get; set; }
        public long experienceId { get; set; }
        public string age { get; set; }
        public long salary { get; set; }
        public long qualification { get; set; }

        [AllowHtml]
        public string description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string experienceName { get; set; }
        public string ageName { get; set; }
        public string salaryname { get; set; }
        public string qualificationname { get; set; }
        public string Resumefile { get; set; }
        public string univarsity { get; set; }
        public string year { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }

        public string experienceIds { get; set; }
        public string location { get; set; }
        public long GuestId { get; set; }
        public long CreateBy { get; set; }
        public string Todate { get; set; }
        public string InterviewDate { get; set; }
        public string Fromdate { get; set; }
        public long workId { get; set; }
        public long educationId { get; set; }
        public long awardId { get; set; }
        public string Link { get; set; }
        public string UsertypeName { get; set; }
        public string oldPassword { get; set; }
        public string NewPassword { get; set; }
        public string resumeName { get; set; }
        public string visibleName { get; set; }
        public string EndYear { get; set; }

        public IEnumerable<CandidateModel> LicensesCertifications { get; set; }
        public IEnumerable<CandidateModel> Interviewcolloction { get; set; }
        public IEnumerable<CandidateModel> Pipelinestage { get; set; }
        public IEnumerable<CandidateModel> candidaterefrencecollection { get; set; }
        public IEnumerable<CandidateModel> CandidateCollection { get; set; }
        public IEnumerable<DropDownViewModel> experienceCollection { get; set; }
        public IEnumerable<DropDownViewModel> IndustryCollection { get; set; }
        public IEnumerable<DropDownViewModel> SalaryCollection { get; set; }
        public IEnumerable<DropDownViewModel> QualificationCollection { get; set; }
        public IEnumerable<CandidateModel> EducationCollection { get; set; }
        public IEnumerable<DropDownViewModel> CountryCollection { get; set; }
        public IEnumerable<DropDownViewModel> StateCollection { get; set; }
        public IEnumerable<DropDownViewModel> JobTypeCollection { get; set; }
        public IEnumerable<DropDownViewModel> MilesCollection { get; set; }
        public IEnumerable<DropDownViewModel> CityCollection { get; set; }
        public IEnumerable<DropDownViewModel> ClientCollection { get; set; }
        public IEnumerable<CandidateModel> workexperiencecollection { get; set; }
        public IEnumerable<CandidateModel> Awardscecollection { get; set; }

        public IEnumerable<CandidateModel> portfoliocecollection { get; set; }

        public IEnumerable<DropDownViewModel> JobCollection { get; set; }
        public IEnumerable<DropDownViewModel> CompanyJobCollection { get; set; }
        public IEnumerable<CandidateModel> SkillCollection { get; set; }
        public IEnumerable<DropDownViewModel> InterviewStaus { get; set; }

        public IEnumerable<DropDownViewModel> visibleidCollection { get; set; }
        public IEnumerable<DropDownViewModel> JobStatusCollection { get; set; }

        public IEnumerable<CandidateModel> CandidatedefaultimageCollection { get; set; }
        public long visibleid { get; set; }

        public string CurrentSalary { get; set; }
        public string CurrentSalaryId { get; set; }
        public string Educationlevels { get; set; }
        public string Zipcode { get; set; }
        public string Longitude { get; set; } 
        public string Latitude { get; set; }
        public string Certifications { get; set; }

        public string IndustryName { get; set; }

        public string EducationlevelName { get; set; }
        public string Jobappliedcount { get; set; }
        public string Jobsavedcount { get; set; }

        public long applyjobId { get; set; }
        public long JobId { get; set; }
        public string ContactIs { get; set; }
        public string InterviewStausName { get; set; }
        public List<Web.SolrClient.Helpers.SearchDocumentResultForView> CandiateList { get; set; }

        public List<Web.SolrMyCandidate.Helpers.SearchDocumentResultForView> MyCandiateList { get; set; }
        public string ProfileCheck_Id { get; set; }

        public string IdsJobId { get; set; }

        public string JobTypeName { get; set; }
        public string createddate { get; set; }
        public string JobStatusName { get; set; }
        public string City { get; set; }
        public string WorkExperienceMax { get; set; }
        public string JobCategoryName { get; set; }
        public string ClientName { get; set; }
        //public string ClientEmail { get; set; }


        public string Subject { get; set; }
        public string InterviewerName { get; set; }
        public string InterviewerEmail { get; set; }
        public string InterviewLocation { get; set; }


        public string UserName { get; set; }
        public long TagId { get; set; }
        public IEnumerable<CandidateModel> SimilarCandidatescollection { get; set; }

        public IEnumerable<CandidateModel> mycandidatecollection { get; set; }
        public IEnumerable<CandidateModel> candidateconversationcollection { get; set; }
        public long pipelinemessagecount { get; set; }
        public string Candidateskill { get; set; }
        public string EducaStartYear { get; set; }
        public string EducaEndYear { get; set; }
        public string WorkExpStartDate { get; set; }
        public string WorkExpEndDate { get; set; }
        public string UpdatedDate { get; set; }
        public string AccountTypeName { get; set; }
        public string CreatedByName { get; set; }
        public string UserIdByTitle { get; set; } 
    }
}
