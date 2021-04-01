using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Data
{
    public enum TypeOfBike { RoadBike, MountainBike}
    public class RideStats
    {
        public int Id { get; set; }
        public int Distance { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Calories { get; set; }
        public TypeOfBike BikeType { get; set; }
    }
}
