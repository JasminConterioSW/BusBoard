using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusBoard1.Web.Models;
using BusBoard1.Api.Clients;

namespace BusBoard1.Web.Controllers
{
    public class ArrivalsController : Controller
    {
        private readonly ILogger<ArrivalsController> _logger;
        private readonly TflApi _tflApi;

        private readonly PostCodeApi _postCodeApi;
        
        public ArrivalsController(ILogger<ArrivalsController> logger, TflApi tflApi, PostCodeApi postCodeApi)
        {
            _logger = logger;
            _tflApi = tflApi;
            _postCodeApi = postCodeApi;

        }
        
        //[HttpGet("")] 
        public IActionResult Buses(string postcode = "NW5 1TL")
        //public IActionResult Buses([FromRoute] string postcode)
        {
            var longlat = _postCodeApi.GetLongLatFromPostCodeApi(postcode); // getlonglatfrompostcode(postcode)
            var busStopCodes = _tflApi.GetBusStopCodesFromLongLat(longlat, 2);// get bus stopcode from longlat
            var busTimes = GetBusTimes(busStopCodes);// get bus stop times from bus stopcode
            var buses = busTimes.Select(a => new BusViewModel(a)).ToList();   // convert bus model to view model
            //    return model
            
            return View(buses);
        }
    }
}