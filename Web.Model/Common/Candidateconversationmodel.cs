using System.Collections.Generic;

namespace Web.Model.Common
{
    public class Candidateconversationmodel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CId { get; set; }
        public long ClientId { get; set; }

        public long CompanyId { get; set; }

        public long CandidateId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public long jId { get; set; }
        public string JIds { get; set; }
        public string location { get; set; }
        public string IndustryName { get; set; }
        public string JobTypeName { get; set; }
        public string CandidateJobTypeName { get; set; }
        public string Salery { get; set; }
        public string imageFile { get; set; }
        public string FileUpload { get; set; }
        public string description { get; set; }
        public long FromId { get; set; }
        public IEnumerable<Candidateconversationmodel> submitedprofileCollection { get; set; }
        public long ClientCandidateId { get; set; }
        public IEnumerable<CandidateConversationEditModel> candidateconversationcollection { get; set; }

        public string FirstName { get; set; }
        public long maxRows { get; set; }

        public long? CurrentPageIndex { get; set; }

        public string createddate { get; set; }

        public long JobId { get; set; }
        public string Ids { get; set; }
        public string JobTitle { get; set; }
        public string qualificationName { get; set; }
        public string DesignationName { get; set; }
        public string jobcategory { get; set; }

        public long ToId { get; set; }
        public long OffsetId { get; set; }

        public int TotalRowCount { get; set; }
        public int PageCount { get; set; }
        public int indexlegth { get; set; }

        public string zipcode { get; set; }
        public IEnumerable<DropDownViewModel> Collection { get; set; }
        public List<CandidateConversationEditModel> CollectionList { get; set; }
        public string CandidateLocation { get; set; }
        public string CandidateTitle { get; set; }
        public string CandidatePhoneNo { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateName { get; set; }
        public string CandidateImage { get; set; }


        public string ClientImage { get; set; }
        public string ClientName { get; set; }

        public string ClientEmail { get; set; }

        public string ClientPhoneNo { get; set; }

        public string ClientWebsite { get; set; }
        public string MaxSalary { get; set; }
        public string MinSalary { get; set; }
        public string DesiredTitle1 { get; set; }
        public string DesiredTitle2 { get; set; }
        public List<CandidateConversationEditModel> generalmessagelistcollection { get; set; }
        public string compnayname { get; set; }
        public string CanId { get; set; }

        public long AccountTypeId { get; set; }
        public string LastName { get; set; }


        public string Email { get; set; }
        public string ClientPhone { get; set; }

        public string Address { get; set; }

        public long UnReadCount { get; set; }

        public string Role { get; set; }

    }
}
