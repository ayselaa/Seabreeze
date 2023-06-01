namespace SeaBreeze.Service.DTOS.Ticket
{
    public class TicketStatus
    {
        public bool IsValidDay { get; set; }
        public bool IsPremium { get; set; }
        public bool RoseBar { get; set; }
        public bool IsEnsured { get; set; }
        public bool Used { get; set; }
        public string Date { get; set; }
    }
}
