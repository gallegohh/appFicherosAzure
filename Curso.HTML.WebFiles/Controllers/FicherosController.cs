using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft;

namespace Curso.HTML.WebFiles.Controllers
{
    public class FicherosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Upload(string file, string name)
        {
            try
            {
                var dataString = file.Split(',')[1];
                var dataByte = Convert.FromBase64String(dataString);
#if DEBUG
                var ruta = AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\wwwroot\upload\" + name;

                System.IO.File.WriteAllBytes(ruta,
                    dataByte);
#else
                System.IO.File.WriteAllBytes(@"D:\\home\\site\\wwwroot\\wwwroot\\upload\\" + name, dataByte);
#endif
                return "OK";
            }
            catch (Exception)
            {
                return "NOK";
            }
        }
    }
}