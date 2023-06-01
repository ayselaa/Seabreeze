namespace SeaBreeze.Domain.Entity.Stories
{
    public class Stories
    {
        public int Id { get; set; }
        public string BannerImage { get; set; }
        public bool IsActive { get; set; }
        public string IticketUrl { get; set; }
        public string Date { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public List<StoriesTranslate> StoriesTranslates { get; set; }
    }
}
