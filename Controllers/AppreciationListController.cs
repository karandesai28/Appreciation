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
    public class AppreciationListController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IHostingEnvironment _env;

        public AppreciationListController(ILogger<HomeController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string tempPath = System.IO.Path.Combine(_env.WebRootPath, "abcd.txt");
            if (!System.IO.File.Exists(tempPath))
            {
                return View("Index");

            }
            string data = System.IO.File.ReadAllText(tempPath);
            var entryList = new List<MessageViewModel>();
           var eachEntry= data.Split(",{{*}}", StringSplitOptions.RemoveEmptyEntries);
            foreach(var entry in eachEntry)
            {
                entryList.Add(JsonConvert.DeserializeObject<MessageViewModel>(entry));
                
            }

            return View("Index",entryList);
        }

      

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
