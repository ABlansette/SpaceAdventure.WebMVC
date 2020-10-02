using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Models.BadGuy
{
    public class BadGuyListItems
    {
        public int BadGuyId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int PlanetId { get; set; }
        public int XpDropped { get; set; }

        //public virtual Planet { get; set; }
    }
}
