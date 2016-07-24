using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Embryo.Web.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Embryo.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<MyCustomSettings> appOptions, ILogger<HomeController> logger)
        {
            _appOptions = appOptions;
            _logger = logger;
        }

        IOptions<MyCustomSettings> _appOptions;
        ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            _logger.LogError(LoggingEvents.ITEM_NOT_FOUND, "Some error! {msg}", "Uh oh!");

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
