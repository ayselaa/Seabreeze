using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Domain.Entity.Entertainments
{
    public class EntertainmentImages
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public int EntertainmentId { get; set; }
        public Entertainment Entertainment { get; set; }
    }
}
