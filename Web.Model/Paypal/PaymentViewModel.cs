namespace Web.Model.Paypal
{
    public class PaymentViewModel
    {

        public string transactionno { get; set; }
        public string guid { get; set; }
        public string CusId { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PlanId { get; set; }
        public string pid { get; set; }
        public string StripePriceid { get; set; }
        public string StripeProductId { get; set; }
        public string PlanName { get; set; }
        public string Amount { get; set; }
        public long result { get; set; }
        public string OrderID { get; set; }
        public string subscriptionID { get; set; }
        public long UserAccountType { get; set; }
        public string CardTypeId { get; set; }
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string CVVNumber { get; set; }
        public string TransactionId { get; set; }
        public int StatusId { get; set; }
        public string CreditCardId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string PaymentId { get; set; }
    }
}
