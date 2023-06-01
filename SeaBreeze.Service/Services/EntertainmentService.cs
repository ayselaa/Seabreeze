using SeaBreeze.Service.DTOS.Entertainment;
using SeaBreeze.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Service.Services
{
    public class EntertainmentService : IEntertainmentService
    {
        public Task<List<GetAllDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
