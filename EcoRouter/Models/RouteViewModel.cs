using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRouter.Models
{
    public class RouteViewModel
    {
        public List<RouteModel> _routes { get; set; }
        public List<MapPointModel> _points { get; set; }
    }
}
