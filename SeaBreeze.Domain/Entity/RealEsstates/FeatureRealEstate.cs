namespace SeaBreeze.Domain.Entity.RealEsstates
{
    public class FeatureRealEstate
    {
        public int Id { get; set; }
        public Feature Feature { get; set; }
        public RealEstate RealEstate { get; set; }
        public string Value { get; set; }
    }
}
