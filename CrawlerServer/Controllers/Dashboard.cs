using CrawlerServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using CrawlerServer.Services.Download;

namespace CrawlerServer.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly ILogger<DashBoardController> _logger;

        public DashBoardController(ILogger<DashBoardController> logger)
        {
            _logger = logger;
        }

        public IActionResult DashBoard()
        {
            downloadvideo dv = new downloadvideo();
            string result = dv.GetVideoUrl();
            _logger.LogInformation("helo khoa this is log");
            _logger.LogInformation(result);
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
    }
}