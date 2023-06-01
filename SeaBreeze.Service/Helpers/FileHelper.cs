using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBreeze.Service.Helpers
{
    public static class FileHelper
    {
        public static string GetFilePath(string root,string folder,string file)
        {
            return Path.Combine(root,folder,file);
        }

        public static async Task SaveFileAsync(string path, IFormFile file)
        {
            using (FileStream stream = new(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }


    }
}
