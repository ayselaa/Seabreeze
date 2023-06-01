using Dashboard.Areas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeaBreeze.Domain;
using SeaBreeze.Domain.Entity.Entertainments;
using SeaBreeze.Service.Helpers;

namespace Dashboard.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EntertainmentController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public EntertainmentController(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
           List<Entertainment> entertainments= _context.Entertainments
                                               .Include(e=>e.EntertainmentImages)
                                               .Include(e=>e.EntertainmentTranslates)
                                               .ToList();
            return View(entertainments);                                   
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEntertainmentVM entertainment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                List<EntertainmentImages> entertainmentImages = new();
                foreach (var photo in entertainment.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string path = FileHelper.GetFilePath(_env.WebRootPath, "entertainmentgallery", fileName);
                    await FileHelper.SaveFileAsync(path, photo);

                    EntertainmentImages entertainmentImage = new()
                    {
                        Url = fileName
                    };
                    entertainmentImages.Add(entertainmentImage);
                }
                entertainmentImages.FirstOrDefault().IsMain = true;

                string logoFileName = Guid.NewGuid().ToString() + "_" + entertainment.Logo.FileName;
                string logoPath = FileHelper.GetFilePath(_env.WebRootPath, "entertainmentlogo", logoFileName);
                await FileHelper.SaveFileAsync(logoPath, entertainment.Logo);

                Entertainment newEntertainment = new()
                {
                    Name = entertainment.Name,
                    EntertainmentImages = entertainmentImages,
                    Logo = logoFileName,
                    PhoneNumber = entertainment.PhoneNumber
                };

                List<EntertainmentTranslate> entertainmentTranslates = new();
                foreach (var translate in entertainment.Translates)
                {
                    EntertainmentTranslate entertainmentTranslate = new()
                    {
                        LangCode=translate.LangCode,
                        Description=translate.Description
                    };
                    entertainmentTranslates.Add(entertainmentTranslate);
                }
                newEntertainment.EntertainmentTranslates= entertainmentTranslates;

                await _context.EntertainmentImages.AddRangeAsync(entertainmentImages);
                await _context.Entertainments.AddAsync(newEntertainment);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
