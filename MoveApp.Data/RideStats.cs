using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Data
{
    public enum TypeOfBike { RoadBike, MountainBike }
    public class RideStats
    {
        [Required]
        public int RideStatsId { get; set; }
        [Required]
        public double Distance { get; set; }
        [Required]
        public int Time { get; set; }
        public int Calories { get { return Time * 8; }}
        [Required]
        [Display(Name = "Type of Bike")]
        public TypeOfBike BikeType { get; set; }
    }
}
