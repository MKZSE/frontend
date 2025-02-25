
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using frontendForMasterDev.Services;
using FrontendForMasterdev.Models;
namespace frontendForMasterdev.Controllers;

public class HomeController : Controller
{
    private readonly Request _request;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, Request request)
    {
        _logger = logger;
        _request = request;
    }

    public IActionResult Index()
    {

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Test()
    {

        var GetApps = await _request.Get_(postfix: "GetLogs", appId: 1);

        return View(GetApps);
    }
    //********************************************************************************

    public async Task<IActionResult> GetApps()
    {

        var GetApps = await _request.Get_(postfix: "GetApps");

        return View("Index", GetApps);
    }

    public async Task<IActionResult> GetLogs(int app_id)
    {
        var GetApps = await _request.Get_(postfix: "GetLogs", app_id);
        return View("Index", GetApps);
    }
}