using System.Collections.Generic; 
using Web.Model.Common;

namespace Web.Model.Candidate
{
    public class PlanModel
    {
        public string planCreditCardId;
        public string validdate;

        public string StripePriceid { get; set; }
        public string StripeProductId { get; set; }

        public long Id { get; set; }
        public long UserId { get; set; }
        public long UsertypeId { get; set; }
        public string noofjob { get; set; }
        public string noofinterview { get; set; }
        public string noofsubmission { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string PlanStatusName { get; set; }
        public long PlanTypeId { get; set; } 
        public string Description { get; set; }
        public long PlanStatusId { get; set; }
        public long Subscription { get; set; }
        public string transactionno { get; set; }

        public IEnumerable<DropDownViewModel> PlanCollection { get; set; }
        public IEnumerable<PlanModel> PlanListCollection { get; set; }
        public IEnumerable<DropDownViewModel> PlanTypeCollection { get; set; }
        public string Ids { get; set; }
        public string PlanTypeName { get; set; }
        public string Plantransactionno { get; set; }
        public string CreatedDate { get; set; }
    }
}
