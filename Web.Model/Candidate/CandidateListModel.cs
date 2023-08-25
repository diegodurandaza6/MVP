using System.Collections.Generic;
using Web.Model.Common;
using Web.SolrClient.Helpers;

namespace Web.Model.Candidate
{
    public class CandidateListModel
    {
        public string jobtype;
        public string UserIdByTitle { get; set; }
        public long salery { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string SaleryName { get; set; }
        public string CandidateIds { get; set; }
        public IEnumerable<DropDownViewModel> milescollection { get; set; }
        public IEnumerable<DropDownViewModel> jobtypecollection { get; set; }

        public IEnumerable<DropDownViewModel> experiencecollection { get; set; }

        public IEnumerable<DropDownViewModel> Educationcollection { get; set; }

        public long UserId { get; set; }
        public long IndustryId { get; set; }
        public string Industry { get; set; }
        public string locationKey { get; set; }
        public string Location { get; set; }
        public string Jobtype { get; set; }
        public long checkId { get; set; }
        public long SearchId { get; set; }
        public string Jobcatagory { get; set; }
        public long mile { get; set; }
        public decimal milesrange { get; set; }
        public long experienceId { get; set; }
        public string experienceIds { get; set; } 
        public long educationlavelId { get; set; } 
        public string searchkeyword { get; set; }
        public long Id { get; set; }
        public long CountryId { get; set; }
        public long StateId { get; set; }
        public string City { get; set; }
        public long CityId { get; set; }
        public string Zip { get; set; }
        public string Title { get; set; }
        public long gid { get; set; }
        public string gids { get; set; }
        public string groupcandidateId { get; set; }

        public long CandidateListMaxRow { get; set; }
        public long? CurrentPageIndex { get; set; }
        public int maxRows { get; set; }
        public long OffsetId { get; set; }

        public string Keyword { get; set; }
        public long accounttype { get; set; }
        public int favoriteTotalCount { get; set; }
        public int TotalRowCount { get; set; }
        public int PageCount { get; set; }
        public int indexlegth { get; set; }

        public IEnumerable<CandidateModel> Collection { get; set; }
        public IEnumerable<DropDownViewModel> CountryListCollection { get; set; }
        public IEnumerable<DropDownViewModel> StateCollection { get; set; }
        public IEnumerable<DropDownViewModel> CityCollection { get; set; }
        public List<SearchDocumentResultForView> CandiateList { get; set; }
        public IEnumerable<CandidateListModel> SearchCollection { get; set; }
        public string Name { get; set; }
        public string educationlavel { get; set; }
        public long jobtypeId { get; set; }
        public string imagepath { get; set; }
        public IEnumerable<DropDownViewModel> IndustryCollection { get; set; }
        public long ClientId { get; set; }
    }
}
