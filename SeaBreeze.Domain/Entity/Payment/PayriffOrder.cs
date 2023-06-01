namespace SeaBreeze.Domain.Entity.Payment
{
    public class PayriffOrder
    {
        public int Id { get; set; }
        public string orderId { get; set; }
        public string sessionId { get; set; }
        public string paymentUrl { get; set; }
        public int transactionId { get; set; }
        public decimal totalAmount { get; set; }
        public string status { get; set; }
    }


}
