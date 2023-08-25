namespace PaymentScheduler
{
    public class PaymentViewModel
    {
        public string CardTypeId { get; set; }
        public long CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public long CVVNumber { get; set; }
        public string CardHolderName { get; set; }
        public long PlanId { get; set; }
        public long Id { get; set; }
        public long AdId { get; set; }
        public long UserId { get; set; }
        public string TransactionId { get; set; }
        public string CreditCardId { get; set; }
        public decimal Amount { get; set; }
        public long PlanDays { get; set; }
        public long StatusId { get; set; }
        public string CouponCode { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ProductName { get; set; }
        public decimal Discount { get; set; }
    }
}
