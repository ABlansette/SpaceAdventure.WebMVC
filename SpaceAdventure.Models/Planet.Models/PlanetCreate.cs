using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Models.Planet
{
    public class PlanetCreate
    {
        //public int PlanetId { get; set; }
        [Required]
        
        public string PlanetaryName { get; set; }
    }
}
