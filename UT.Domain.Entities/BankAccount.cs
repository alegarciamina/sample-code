namespace UT.Domain.Entities
{
    public class BankAccount
    {
        public bool IsAutoPayEnrolled { get; set; }
        public string RoutingNumber { get; set; }
        public string AccountId { get; set; }
        public string AccountNickname { get; set; }
        public string AccountNumber { get; set; }
        public string FinancialInstitution { get; set; }
        public bool IsEditable { get; set; }
    }
}
