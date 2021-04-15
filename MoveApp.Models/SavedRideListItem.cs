using MoveApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Models
{
    public class SavedRideListItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public int LocationId { get; set; }
        public LocationListItem Location { get; set; }
        public int RideStatsId { get; set; }
        public RideStatsListItem RideStats { get; set; }
    }
}
