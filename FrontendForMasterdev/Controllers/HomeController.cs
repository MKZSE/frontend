using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using frontendForMasterDev.Services;
using FrontendForMasterdev.Models;
using frontendForMasterDev.Models;

namespace frontendForMasterdev.Controllers
{
    public class HomeController : Controller
    {
        private readonly Request _request;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Request request)
        {
            _logger = logger;
            _request = request;
        }

        
        public async Task<IActionResult> Index(int? appId)
        {
            int id = appId ?? 1;  
            var apps = await _request.GetApps("GetApps");
            var logs = await _request.GetLogs("GetLogs", id);
            var updates = await _request.GetUpdate("GetUpdate", "AppName", "1.0");

            var model = new MultiModelViewModel
            {
                Apps = apps,
                Logs = logs,
                Updates = updates
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        
        public async Task<IActionResult> GetApps()//done
        {
            var apps = await _request.GetApps("GetApps");
            
            var logs = await _request.GetLogs("GetLogs", 1);
            var updates = await _request.GetUpdate("GetUpdate", "AppName", "1.0");

            var model = new MultiModelViewModel
            {
                Apps = apps,
                Logs = logs,
                Updates = updates
            };

            return View("Index", model);
        }

        
        public async Task<IActionResult> GetLogs(int appId)//done
        {
            var logs = await _request.GetLogs("GetLogs", appId);
            var apps = await _request.GetApps("GetApps");
            var updates = await _request.GetUpdate("GetUpdate", "AppName", "1.0");

            var model = new MultiModelViewModel
            {
                Apps = apps,
                Logs = logs,
                Updates = updates
            };

            return View("Index", model);
        }

        
        public async Task<IActionResult> SendLogs(int appId, string message)//done
        {
            await _request.SendLogs("SendLogs", appId, message);

           
            var apps = await _request.GetApps("GetApps");
            var logs = await _request.GetLogs("GetLogs", appId);
            var updates = await _request.GetUpdate("GetUpdate", "AppName", "1.0");

            var model = new MultiModelViewModel
            {
                Apps = apps,
                Logs = logs,
                Updates = updates
            };

            return View("Index", model);
        }


        public async Task<IActionResult> GetUpdatedEnabled(int i)//done
        {   
            var enabled = await _request.UpdateEnabled("UpdatesEnabled", i);

            
            var apps = await _request.GetApps("GetApps");
            var logs = await _request.GetLogs("GetLogs", 1); 
            var updates = await _request.GetUpdate("GetUpdate", "AppName", "1.0");

            var model = new MultiModelViewModel
            {
                Apps = apps,
                Logs = logs,
                Updates = updates,
                UpdatesEnabled = enabled 
            };

            return View("Index", model);
        }


        [HttpPost]
        public async Task<IActionResult> GetUpdate(string nazwa_aplikacji, string version)//done
        {
            var update = await _request.GetUpdate("GetUpdate", nazwa_aplikacji, version);
            var apps = await _request.GetApps("GetApps");
            var logs = await _request.GetLogs("GetLogs", 1);

            var model = new MultiModelViewModel
            {
                Apps = apps,
                Logs = logs,
                Updates = update
            };

            return View("Index", model);
        }
    }
}
