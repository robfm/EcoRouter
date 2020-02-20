using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoRouter.Models
{
    public class MapPointModel
    {
        [Key]
        public string MarkID { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
