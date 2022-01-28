using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRLiveChatApp.DAL;
using SignalRLiveChatApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLiveChatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogManager _logger;

        public HomeController(ILogManager logger)
        {
            _logger = logger;
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

        public void Create(string UserName,string Message,string Chanel)
        {

            _logger.Create(UserName, Message,Chanel);
        }

        public string GetList(string chanelID)
        {
             var getlog=_logger.GetById(chanelID);

            return getlog;
        }
    }
}
