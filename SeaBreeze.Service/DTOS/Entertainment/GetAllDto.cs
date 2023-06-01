using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Service.DTOS.Entertainment
{
    public class GetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ?Image { get; set; }
        public string Logo { get; set; }

    }
}
