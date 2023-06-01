using SeaBreeze.Service.DTOS.Entertainment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Service.Interfaces
{
    public interface IEntertainmentService
    {
        Task<List<GetAllDto>> GetAll();
      
    }
}
