using MoveApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Models
{
    public class RideStatsCreate
    {
        public int RideStatsId { get; set; }
        public double Distance { get; set; }
        public int Time { get; set; }
        public int Calories { get { return Time * 8; } }
        [Display(Name = "Type of Bike")]
        public TypeOfBike BikeType { get; set; }
    }
}
