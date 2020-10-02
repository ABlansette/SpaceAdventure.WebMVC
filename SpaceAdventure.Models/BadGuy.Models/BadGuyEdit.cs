using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Models.BadGuy
{
    public class BadGuyEdit
    {
        public int BadGuyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int XpDropped { get; set; }

        [Required]
        [ForeignKey(nameof(PlanetId))]
        public int PlanetId { get; set; }
    }
}
