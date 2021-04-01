using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Data
{
    public class SavedRide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public int LocationId { get; set; }
        public int RideStatsId { get; set; }
        public virtual Location Location { get; set; }
        public virtual RideStats Ridestats { get; set; }
        
    }
}
