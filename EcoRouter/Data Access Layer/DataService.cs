using EcoRouter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRouter.Data
{
    public class DataService
    {
        private RouterContext _context;

        public DataService(RouterContext ctx)
        {
            _context = ctx; 
        }

        public void SaveRoute(List<MapPointModel> _points, RouteModel route, string user)
        {
            var dbRoutes = _context.Routes;
            var dbPoints = _context.Points;

            if (dbRoutes.Any(a => a.RouteID == route.RouteID)){

                var r = dbRoutes.First(a => a.RouteID == route.RouteID);
                r.Distance = route.Distance;
                r.FuelEstimation = route.FuelEstimation;
                r.ModifiedBy = user;
                r.ModifiedAt = DateTime.Now;              
            }
            else
            {
                route.CreatedBy = user;
                route.CreatedAt = DateTime.Now;
                route.ModifiedBy = user;
                route.ModifiedAt = DateTime.Now;
                route.DestinationId = (Guid.NewGuid()).ToString();
                route.DepartureId = (Guid.NewGuid()).ToString();

                _points[0].MarkID = route.DestinationId;
                _points[1].MarkID = route.DepartureId;

                dbRoutes.Add(route);
                dbPoints.AddRange(_points);
            }
            _context.SaveChanges();
        }

        public List<RouteModel> GetRoutes()
        {
            return _context.Routes.ToList();
        }
        public List<MapPointModel> GetMapPoints()
        {
            return _context.Points.ToList();
        }
        public List<UserModel> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
