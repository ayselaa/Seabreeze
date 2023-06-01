namespace SeaBreeze.Service.DTOS.Account
{
    public class ChangePasswordDto
    {
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string ReNewPass { get; set; }
    }
}
