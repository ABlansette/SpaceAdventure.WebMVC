using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Data
{
    public class Planet
    {
        [Key]
        public int PlanetId { get; set; }

        public Guid UserId { get; set; }
        [Required]
        public string PlanetaryName { get; set; }

        public int NumOfBadGuys { get; set; }
    }
}
