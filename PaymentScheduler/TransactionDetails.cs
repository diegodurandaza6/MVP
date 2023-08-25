namespace PaymentScheduler
{
    public class TransactionDetails
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PlanId { get; set; }
        public string TransactionId { get; set; }
        public string Month { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Exp { get; set; }
        public string CVC { get; set; }
        public string CardNumber { get; set; }
        public string CreaditCardId { get; set; }
        public long Status { get; set; }
    }
}
