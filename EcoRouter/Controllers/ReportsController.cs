using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoRouter.Data;
using Microsoft.AspNetCore.Mvc;
using EcoRouter.Models;
using Microsoft.AspNetCore.Authorization;

namespace EcoRouter.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private RouterContext _context;

        public ReportsController(RouterContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DataService service = new DataService(_context);

            var routes = service.GetRoutes();
            ReportViewModel VM = new ReportViewModel();

            List<ReportModel> rep = routes.GroupBy(a => a.CreatedAt.Date)
                .Select(a => new ReportModel {
                    Date = (DateTime)a.Key.Date,
                    TotalDistance = Math.Round(a.Sum(b=>Decimal.Parse(b.Distance.Replace(".",","))), 2),
                    TotalFuelEstimation = Math.Round(a.Sum(x=> Decimal.Parse(x.FuelEstimation.Replace(".", ","))), 2)
                }).ToList();

            VM.totals = rep;

            return View(VM);
        }
    }
}