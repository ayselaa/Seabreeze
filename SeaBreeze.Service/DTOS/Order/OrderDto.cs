using System.ComponentModel;

namespace SeaBreeze.Service.DTOS.Order
{
    public class OrderDto
    {
        public int Count { get; set; }
        [DefaultValue(false)]
        public bool IsRosebar { get; set; }
        [DefaultValue(false)]
        public bool IsInsured { get; set; }
        public string OrderDate { get; set; }

    }
}
