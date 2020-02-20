using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRouter.Models
{
    public class RouteModel
    {
        [Key]
        public string RouteID { get; set; }
        public string DepartureId { get; set; }
        public string DestinationId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
        public string Distance { get; set; }
        public string FuelEstimation { get; set; }
    }
}
