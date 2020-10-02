using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Models.BadGuy
{
    public class BadGuyDetails
    {

        public int BadGuyId { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Health { get; set; }

        public int Damage { get; set; }

        public int XpDropped { get; set; }

        [ForeignKey(nameof(PlanetId))]
        public int PlanetId { get; set; }
    }
}
