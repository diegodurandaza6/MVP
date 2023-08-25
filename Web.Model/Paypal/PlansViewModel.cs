using System.Collections.Generic;

namespace Web.Model.Paypal
{
    public class PlansViewModel
    {
        public long recurringpayment { get; set; }
        public string Status { get; set; }
        public string transactionno { get; set; }
        public string guid { get; set; }
        public string PlanId { get; set; }
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string PlanName { get; set; }
        public long TypeId { get; set; }
        public long Id { get; set; }
        public string Amount { get; set; }
        public string paymentId { get; set; }
        public string CreateDate { get; set; }
        public long Refund { get; set; }
        public string PaymentStopBy { get; set; }
        public string RefundDate { get; set; }
        public string PaymentStopDate { get; set; }
        
        public string ValidPlanDate { get; set; }
        public string Plandateexpired { get; set; }
        public string ClientName { get; set; }
        public string User_Id { get; set; }
        public string CustomerId { get; set; }

    }

    public class PlansListModel
    {
        public string ValidPlanDate;



        public long CheckDate { get; set; }

        public long recurringpayment { get; set; }
        public long UserId { get; set; }
        public string subscriptionId { get; set; }
        public IEnumerable<PlansViewModel> Collection { get; set; }
        public long? CurrentPageIndex { get; set; }
        public int maxRows { get; set; }
        public long OffsetId { get; set; }
        public int TotalRowCount { get; set; }
        public int PageCount { get; set; }
        public int indexlegth { get; set; }
        public long favoritecandidateCount { get; set; }
        public long noofjob { get; set; }
        public long noofinterview { get; set; }


        public long Usesnoofjob { get; set; }
        public long Usesnoofinterview { get; set; }


        public long jobleft { get; set; }
        public string Name { get; set; }
        public long LeftInterview { get; set; }
        public long noofsubmission { get; set; }

        public long Id { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public string pId { get; set; }
        public string PaymentStopBy { get; set; }
        public string PaymentStopDate { get; set; }
        public string RefundDate { get; set; }
        public string RefundBy { get; set; }


        public string RenewDate { get; set; }
        public string RenewBy { get; set; }


        public int tId { get; set; }
    }
}
