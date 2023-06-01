using SeaBreeze.Service.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Service.Interfaces
{
    public interface ILocalizing
    {
        string this[string key] { get; }
        void Add(StaticTranslateDto dto);
        void Remove(string key);
        void Update(StaticTranslateDto dto);
        string GetByLangCode(string langCode, string key);
    }
}
