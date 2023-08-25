
using System.Collections.Generic;
using Web.Model.Common;

namespace Web.Model.Admin
{
    public class CampaignModel
    {

        public string tagids { get; set; }
        public long Id { get; set; }
        public long CreateBy { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public long contactcount { get; set; }
        public long sentcontactcount { get; set; }
        public long statusId { get; set; }
        public long CStatusId { get; set; }
        public string emailbody { get; set; }
        public long CampaignId { get; set; }
        public string StatusName { get; set; }
        public string Email { get; set; }
        public string count { get; set; }
        public string Phone { get; set; }
        public string ComapnyName { get; set; }
        public long campaigntypeid { get; set; }

        public IEnumerable<CampaignModel> campaigncollection { get; set; }
        public IEnumerable<CampaignModel> Campaigncontactcollection { get; set; }
        public IEnumerable<DropDownViewModel> CampaignstatusCollection { get; set; }

        public IEnumerable<DropDownViewModel> CampaigntypeCollection { get; set; }
        public IEnumerable<DropDownViewModel> CampaigntagCollection { get; set; }
    }
}
