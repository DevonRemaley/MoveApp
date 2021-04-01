using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Data
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string Park { get; set; }
    }
}
