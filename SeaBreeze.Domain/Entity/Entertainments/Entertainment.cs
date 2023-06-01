using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Domain.Entity.Entertainments
{
    public class Entertainment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }

        public List <EntertainmentTranslate> EntertainmentTranslates { get; set; }
        public List <EntertainmentImages> EntertainmentImages { get; set; }
    }
}
