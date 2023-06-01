namespace SeaBreeze.Service.DTOS.Account
{
    public class GetUserInfoDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsResident { get; set; }
    }
}
