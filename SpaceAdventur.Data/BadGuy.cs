using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Data
{
    public class BadGuy
    {
        [Key]
        public int BadGuyId { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public int Health => Level * 200;

        [Required]
        public int Damage => Level * 19;

        [Required]
        public int XpDropped { get; set; }

        [Required]
        [ForeignKey(nameof(Planet))]
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
    }
}
