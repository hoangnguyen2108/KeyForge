namespace KeyForge.Model
{
    public class PaymentClass
    {
        public int Id { get; set; }

        // WHen Create user

        // public int UserId {get;set;}

        public int TransactionId { get; set; }
        public int Amount { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
