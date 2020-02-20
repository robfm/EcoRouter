using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRouter.Models
{
    public class ReportModel
    {
        public decimal TotalFuelEstimation { get; set; }
        public decimal TotalDistance { get; set; }
        public DateTime Date { get; set; }
    }
}
