using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using EcoRouter.Models;
using EcoRouter.Data;
using Microsoft.AspNetCore.Authorization;

namespace EcoRouter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private RouterContext _context;

        public HomeController(RouterContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DataService service = new DataService(_context);

            var routes = service.GetRoutes();
            var points = service.GetMapPoints();

            RouteViewModel VM = new RouteViewModel();            

            foreach (var r in routes)
            {
                var dist = Decimal.Parse(r.Distance.Replace(".",","));

                if (dist % 1 == 0)// Check if the number is integer
                    r.Distance = Convert.ToInt32(dist).ToString();
                else
                    r.Distance = Math.Round(dist, 2).ToString();

                var fuel = Decimal.Parse(r.FuelEstimation.Replace(".", ","));

                if (fuel % 1 == 0)// Check if the number is integer
                    r.FuelEstimation = Convert.ToInt32(fuel).ToString();
                else
                    r.FuelEstimation = Math.Round(fuel, 2).ToString();
            }
            VM._routes = routes;
            VM._points = points;

            return View(VM);
        }

        public IActionResult Reports()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveRoute(List<MapPointModel> _points, RouteModel route)
        {
            DataService service = new DataService(_context);

            string userName = "admin";            
            service.SaveRoute(_points, route, userName);
            return Ok();
        }
    }
}
