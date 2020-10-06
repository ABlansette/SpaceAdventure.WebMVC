using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Models.Adventurer
{
    public class AdventurerDetails
    {
        public int AdventurerId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Species Class { get; set; }
        public string Weapon {get; set;}

        //public bool IsInCombat { get; set; }
        [ForeignKey(nameof(PlanetId))]
        public int PlanetId { get; set; }
    }
    public enum Species { SpaceWizard, SpaceKnight, GreenAlien, SpaceBarbarian, SpaceArcher, SpaceMonk }
}

