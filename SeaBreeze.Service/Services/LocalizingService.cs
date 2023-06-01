using SeaBreeze.Domain;
using SeaBreeze.Domain.Entity.Localizations;
using SeaBreeze.Service.DTOS;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Service.Services
{
    public class LocalizingService : ILocalizing
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUser _currentUserService;
        public LocalizingService(AppDbContext context, ICurrentUser currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }


        public string this[string key]
        {
            get
            {
                var currentUser = _currentUserService.GetCurrentUser();
                if (currentUser is null) return key;
                var data = _context.StaticLocalizationTranslates.Where(c => c.Key == key && c.LangCode == currentUser.LangCode).FirstOrDefault();
                if (data is null) return key;
                return data.Value;
            }
        }

        public void Add(StaticTranslateDto dto)
        {
            throw new NotImplementedException();
        }

        public string GetByLangCode(string langCode, string key)
        {
            var data = _context.StaticLocalizationTranslates.Where(c => c.Key == key && c.LangCode == langCode).FirstOrDefault();
            if (data is null) return key;
            return data.Value;
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(StaticTranslateDto dto)
        {
            throw new NotImplementedException();
        }


        //public void Add(StaticTranslateDto dto)
        //{
        //    var entityDatas = dto.Translates.Select(c => new StaticLocalizationTranslate()
        //    {
        //        Key = dto.Key,
        //        Value = c.Value,
        //        LangCode = c.LangCode,
        //    });
        //    _context.StaticLocalizationTranslates.AddRange(entityDatas);
        //    _context.SaveChangesAsync();
        //}


        //public void Remove(string key)
        //{
        //    var entityDatas = _context.StaticLocalizationTranslates.Where(c => c.Key == key);
        //    _context.StaticLocalizationTranslates.RemoveRange(entityDatas);
        //    _context.SaveChanges();
        //}

        //public void Update(StaticTranslateDto dto)
        //{
        //    var entityDatas = _context.StaticLocalizationTranslates.Where(c => c.Key == dto.Key);
        //    foreach (var item in entityDatas)
        //    {
        //        item.Value = dto.GetKey(item.LangCode);
        //    }
        //    _context.UpdateRange(entityDatas);
        //    _context.SaveChanges();
        //}
    }
}
