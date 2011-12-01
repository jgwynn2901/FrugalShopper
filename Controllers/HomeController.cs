using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Api.Maps.Service.Geocoding;
using Google.Api.Maps.Service;
using FrugalShopper.Models;

namespace FrugalShopper.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

         public ActionResult Details(string address)
        {
            var request = new GeocodingRequest();
            request.Address = address;
            request.Sensor = "false";
            var response = GeocodingService.GetResponse(request);

            if (response.Status == ServiceResponseStatus.Ok && response.Results != null)
            {
                var location = new Location
                    {
                        UserId = 1,
                        FormattedAddress = response.Results[0].FormattedAddress,
                        Latitude = double.Parse(response.Results[0].Geometry.Location.Latitude.ToString()),
                        Longitude = double.Parse(response.Results[0].Geometry.Location.Longitude.ToString())
                    };

                location.Id = UserRepository.Insert(location);
                return Json(location, JsonRequestBehavior.AllowGet);
            }
            return View("Index");
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        } 

        
        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
