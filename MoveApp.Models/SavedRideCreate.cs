using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Models
{
    public class SavedRideCreate
    {
        public int Id { get; set; }
        [MinLength(1, ErrorMessage = "You must enter a character.")]
        [MaxLength(30, ErrorMessage = "Whoa, too many characters.")]
        public string Name { get; set; }
        [MaxLength(90)]
        public string Description { get; set; }
    }
}
