using System.Collections.Generic;
using Web.Model.Candidate;

namespace Web.Model.Group
{
    public class GroupViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Status { get; set; }
        public long CreatedBy { get; set; }
        public string Date { get; set; }
        public string Ids { get; set; }
        public List<CandidateModel> CandidateCollection { get; set; }
    }
}
