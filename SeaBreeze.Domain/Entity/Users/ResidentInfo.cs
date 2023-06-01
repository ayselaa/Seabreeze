using System.ComponentModel.DataAnnotations;

namespace SeaBreeze.Domain.Entity.Users
{
    public class ResidentInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CardId { get; set; }
        public string FIN { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string RealEstate { get; set; }
        public string HouseNo { get; set; }
    }
}
