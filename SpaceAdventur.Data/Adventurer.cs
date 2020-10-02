using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Data
{
    public class Adventurer
    {
        
        [Key]
        public int AdventurerId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Level { get; set; }
        public int Health
        {
            get
            {
                return Level * 300;
            }
        }
        public int Damage
        {
            get
            {
                return Level * 30;
            }
        }
        public Species Class { get; set; }
        public string Weapon { get; set; }

        //public bool IsInCombat { get; set; }

        [ForeignKey(nameof(Planet))]
        public int PlanetId { get; set; }
        public virtual Planet Planet { get; set; }
    }

    public enum Species { SpaceWizard, SpaceKnight, GreenAlien, SpaceBarbarian, SpaceArcher, SpaceMonk }
}


