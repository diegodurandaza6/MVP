using System.Collections.Generic;
using Web.Model.Common;

namespace Web.Model.Admin
{
    public class EnquiresViewModel
    {
        public string createdate;
        public int updatedby;
        public List<DropDownViewModel> enquerytypecollection;

        public string AdminName { get; set; }
        public string updateddate { get; set; }
        public long Id { get; set; }
        public string Date { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public string statusid { get; set; }
        public long typeId { get; set; }
        public long enquiryPshipId { get; set; }

        public long? CurrentPageIndex { get; set; }
        public int maxRows { get; set; }
        public long OffsetId { get; set; }

        public int TotalRowCount { get; set; }
        public int PageCount { get; set; }
        public int indexlegth { get; set; }


        public string replymessage { get; set; }
        public long UserId { get; set; }
        public IEnumerable<EnquiresViewModel> Collection { get; set; }
        public IEnumerable<EnquiresViewModel> enquierycollection { get; set; }
        public string Ids { get; set; }
        public long CreateBy { get; set; }
        public IEnumerable<EnquiresViewModel> Newlettercollection { get; set; }
    }
}
