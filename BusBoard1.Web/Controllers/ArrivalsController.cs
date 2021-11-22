using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusBoard1.Web.Models;

namespace BusBoard1.Web.Controllers
{
    public class ArrivalsController : Controller
    {
        private readonly ILogger<ArrivalsController> _logger;

        public ArrivalsController(ILogger<ArrivalsController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Buses()
        {
            
            return View();
        }
    }
}