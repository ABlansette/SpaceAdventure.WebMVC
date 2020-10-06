using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Models.Adventurer
{
    public class AdventurerListItems
    {
        public int AdventurerId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Species Class { get; set; }
    }

}
