using MoveApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Models
{
    public class SavedRideDetail
    {
        public int SavedRideId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public virtual Location Location { get; set; }
        public virtual RideStats Ridestats { get; set; }
    }
}
