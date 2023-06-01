namespace Dashboard.Areas.ViewModels
{
    public class CreateEntertainmentVM
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<EntertainmentTranslateVM> Translates { get; set; }
        public List<IFormFile> Photos { get; set; }
        public IFormFile Logo { get; set; }
    }
}
