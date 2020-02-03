using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Appreciation.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Appreciation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IHostingEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            MessageViewModel message = new MessageViewModel();
            return View();
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("AppreciateToName,AppreciationMessage,NameOfPoster,ShowAppreciatorName")]MessageViewModel message)
        {
            string tempPath = System.IO.Path.Combine(_env.WebRootPath, "abcd.txt");
            if (!System.IO.File.Exists(tempPath))
            {
                System.IO.File.Create(tempPath);
                
            }
            message.CreationDateTime = DateTime.UtcNow;
            message.Id = Guid.NewGuid().ToString();

            //var readAllDataOfFile = System.IO.File.ReadAllBytes(tempPath);
            System.IO.File.AppendAllText(tempPath, string.Format("{0},{1}",JsonConvert.SerializeObject(message), "{{*}}"));
            
            return RedirectToAction("Index", "AppreciationList");
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
