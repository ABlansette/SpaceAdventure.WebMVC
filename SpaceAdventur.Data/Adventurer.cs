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

        public string Weapon { get; set; }
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
        public string WeaponChoice()
        {
            if (Class == Species.GreenAlien)
            {
                return "Blaster";
            }
            if (Class == Species.SpaceArcher)
            {
                return "Space Bow";
            }
            if (Class == Species.SpaceBarbarian)
            {
                return "Space Axe";
            }
            if (Class == Species.SpaceKnight)
            {
                return "Space Sword";
            }
            if (Class == Species.SpaceMonk)
            {
                return "Space Fists";
            }
            if (Class == Species.SpaceWizard)
            {
                return "Space Wand";
            }
            return "Space Weapon";

        }

        //public bool IsInCombat { get; set; }

        [ForeignKey(nameof(PlanetId))]
        public int PlanetId { get; set; }
        public virtual Planet Planet { get; set; }
    }

    public enum Species { SpaceWizard, SpaceKnight, GreenAlien, SpaceBarbarian, SpaceArcher, SpaceMonk }
}


