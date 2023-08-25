using System.Collections.Generic;
using Web.Model.Admin;
using Web.Model.Common;

namespace Web.Model.Client
{
    public class ClientModel
    {
        public string adminName { get; set; }

        public long generalmessagecount { get; set; }
        public long conversationcount { get; set; }
        public long submitedprofilecount { get; set; }
        public string Password { get; set; }
        public long CompanyuserTypeid { get; set; }
        public long pipelinemessagecount { get; set; }
         
        public long totalcount { get; set; }
        public long jobleft { get; set; }
        public long leftinterview { get; set; }

        public string pipeline { get; set; }
        public long fromId { get; set; }
        public string JobTypeId { get; set; }
        public string matchurl { get; set; }
        public long noofjob { get; set; }
        public long noofinterview { get; set; }
        public long noofsubmission { get; set; }

        public long LoginAccess { get; set; }
        public string JIds { get; set; }
        public string JSs { get; set; }

        public string todate { get; set; }
        public string PreviousToDate { get; set; }
        public string fromdate { get; set; }

        public string Education { get; set; }
        public string Jobtitle { get; set; }
        public IEnumerable<DropDownViewModel> sharedjobCompanycollection { get; set; }
        public IEnumerable<DropDownViewModel> sharedjobcollection { get; set; }
        public long CreateBy { get; set; }
        public string locationKey { get; set; }
        public long JobId { get; set; }
        public long result { get; set; }
        public long jobCount { get; set; }
        public long applyjobCount { get; set; }
        public long favoritecandidateCount { get; set; }
        public long sendenqueryCount { get; set; }
        public long? CurrentPageIndex { get; set; }
        public int maxRows { get; set; }
        public long OffsetId { get; set; }
        public string InterviewDate { get; set; }
        public int TotalRowCount { get; set; }
        public int PageCount { get; set; }
        public int indexlegth { get; set; }
        public string Fromname { get; set; }
        public string ToName { get; set; }

        public string InterviwerName { get; set; }
        public long applicantcount { get; set; }
        public string cids { get; set; }
        public long CId { get; set; }
        public string Ids { get; set; }
        public long NewCandidatecount { get; set; }
        public string JobType { get; set; }
        public string JobTypeName { get; set; }
        public string Industry { get; set; }
        public string msg { get; set; }
        public long Unreadcount { get; set; }
        public long PrimaryEmail { get; set; }
        public string candidateTitle { get; set; }
        public string days { get; set; }
        public string IndustryName { get; set; }
        public string Candidateloction { get; set; }
        public string Title { get; set; }
        public string candidatedescription { get; set; }
        public string candidateaddress { get; set; }
        public string candidatefacebook { get; set; }
        public string candidatetwitter { get; set; }
        public string candidatelinkedin { get; set; }
        public string candidateexp { get; set; }
        public string candidateimage { get; set; }
        public string candidateresume { get; set; }
        public string candidatezipcode { get; set; }
        public long UseraccountprofileId { get; set; }
        public long Id { get; set; }
        public long CandidateId { get; set; }
        public string CandidateName { get; set; }

        public long requestmoreinfo { get; set; }
        public long tid { get; set; }
        public string ContactIds { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string JobPostingUrl { get; set; }
        public string Website { get; set; }
        public string Url { get; set; }
        public string Host { get; set; }
        public string Phone1 { get; set; }
        public string pipelineId { get; set; }
        public string Phone2 { get; set; }
        public string Zip { get; set; }
        public string ZipCode { get; set; }
        public long Status { get; set; }
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public long CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Email { get; set; }
        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public string clientLogo { get; set; }
        public string Position { get; set; }
        public string lastemailsent { get; set; }
        public string Linkdin { get; set; }
        public long TabId { get; set; }
        public long ClientId { get; set; }
        public long isubscribe { get; set; }
        public string comments { get; set; }
        public string ZoneId { get; set; }
        public string Subject { get; set; }
        public string DueDate { get; set; }
        public string Resumefile { get; set; }
        public string FileName { get; set; }
        public string experienceName { get; set; }
        public string experience { get; set; }
        public string FilePath { get; set; }

        public string CurrentSalary { get; set; }
        public long CurrentSalaryId { get; set; }
        public string Description { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
        public string DesiredTitle2 { get; set; }
        public string DesiredTitle1 { get; set; }
        public long TypeId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public long CompanyId { get; set; }
        public string Designation { get; set; }
        public IEnumerable<DropDownViewModel> CountryCollection { get; set; }
        public IEnumerable<DropDownViewModel> StateCollection { get; set; }
        public IEnumerable<DropDownViewModel> CityCollection { get; set; }
        public IEnumerable<ClientModel> GetClientList { get; set; }
        public IEnumerable<ClientModel> GetShortList { get; set; }
        public IEnumerable<ClientModel> PipelineCollection { get; set; }

        public IEnumerable<ClientModel> clientContactForm { get; set; }
        public IEnumerable<ClientModel> CompanyToDoCollection { get; set; }
        public IEnumerable<ClientModel> PipelineStatusCollection { get; set; }
        public IEnumerable<EmailTempleteViewModel> ColloctionEmail { get; set; }
        public IEnumerable<DropDownViewModel> TimeZoneCollection { get; set; }
        public string Company { get; set; }
        public string Pipelinename { get; set; }
        public IEnumerable<ClientModel> Notescollection { get; set; }
        public IEnumerable<ClientModel> clientsendenuerycollection { get; set; }
        public IEnumerable<ClientModel> ClienConversationcollection { get; set; }
        public IEnumerable<ClientModel> interviewListCollection { get; set; }
        public IEnumerable<ClientModel> CompletedInterviewListCollection { get; set; }
        public IEnumerable<ClientModel> unreadmessageCollection { get; set; }
        public string sortdescription { get; set; }
        public long UserId { get; set; }
        public string purl { get; set; }
        public long AccountTypeId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ProfileCheck_Id { get; set; }
        public long checkzipcode { get; set; }
        public string CandidatePhone { get; set; }
        public string Candidateage { get; set; }
        public long EnquireyId { get; set; }
        public long ToId { get; set; }
        public string CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public string LastName { get; set; }
        public string candidateEmail { get; set; }
        public string ClientEmail { get; set; }
        public string InterviewBcc { get; set; }
        public string InterviewCc { get; set; }
        public string Location { get; set; }
        public long viewcount { get; set; }
        public string MinSalary { get; set; }
        public string Number { get; set; }
        public string MaxSalary { get; set; }
        public string Amount { get; set; }
        public string Point { get; set; }
        public long RowsId { get; set; }
        public string ValidPlanDate { get; set; }

        public long myJobId { get; set; }
        public long SharedJobId { get; set; }

        public IEnumerable<DropDownViewModel> Jobscollection { get; set; }
        public IEnumerable<DropDownViewModel> Adminjobcollection { get; set; }
        public string CandidateTag { get; set; }
        public string Candidateskill { get; set; }
        public long TagtypeId { get; set; }
        public IEnumerable<Tagsmodel> Clienttagcollection { get; set; }
        public IEnumerable<ClientModel> applicantjobapply { get; set; }
        public IEnumerable<ClientModel> joblistcollection { get; set; }
        public long jobStatus { get; set; }
        public long Notecount { get; set; }
        public long Interviewcount { get; set; }
        public IEnumerable<ClientModel> generalmessagecollection { get; set; }
        public List<DropDownViewModel> clientlistcollection { get; set; }

        public string ClientContactPhone { get; set; }
        public string CreatedByName { get; set; }
        public string CompanyIamge { get; set; }
        public IEnumerable<ClientModel> ClientJobsCollection { get; set; }
        public string InterviewerName { get; set; }
        public string SubmissionDate { get; set; }
        public IEnumerable<ClientModel> SubmissionCollection { get; set; }
        
        public long MileId { get; set; }
        public IEnumerable<ClientModel> MileCollection { get; set; }
        public long PastMonthCount { get; set; }
        public long AllCount { get; set; }
        public long Count { get; set; }
        public long? pId { get; set; }
        public int CompletedmaxRows { get; set; }
        public long CompletedOffsetId { get; set; }
        public int CompletedTotalRowCount { get; set; }
        public int CompletedPageCount { get; set; }
        public int Completedindexlegth { get; set; }
    }
}
