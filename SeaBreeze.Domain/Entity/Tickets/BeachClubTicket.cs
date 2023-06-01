namespace SeaBreeze.Domain.Entity.Tickets
{
    public class BeachClubTicket
    {
        public string Id { get; set; }
        public string Season { get; set; }
        public DateOnly ValidTime { get; set; }
        public DateTime UsedTime { get; set; }
        //public DateTime ExpireDate { get; set; }
        public bool IsPremium { get; set; }
        public bool IsActive { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? Name { get; set; }
        public bool IsInsured { get; set; }
        public bool IsRoseBar { get; set; }
        public decimal Price { get; set; }
        public string? FIN { get; set; }

        //public decimal RoseBarPrice { get; set; }
        //public decimal BeachClubPrice { get; set; }
        public BeachClubOrder BeachClubOrder { get; set; }

    }
}
