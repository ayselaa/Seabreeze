namespace Dashboard.Areas.ViewModels
{
    public class BeachClubTicketVM
    {
        public DateOnly ValidTime { get; set; }
        public string UserFullName { get; set; }
        //public decimal BeachClubPrice { get; set; }
        //public decimal RoseBarPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
