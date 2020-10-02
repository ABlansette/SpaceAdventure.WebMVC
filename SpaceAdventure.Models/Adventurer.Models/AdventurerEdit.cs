using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Models.Adventurer
{
    public class AdventurerEdit
    {
        public int AdventurerId { get; set; }
        public string Name { get; set; }
    }
}
