using SpaceAdventure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventur.Data
{
    class Fight
    {
        [Key]
        public int FightId { get; set; }

        [ForeignKey(nameof(AdventurerId))]
        public int AdventurerId { get; set; }
        public virtual Adventurer TheAdventurer { get; set; }

        [ForeignKey(nameof(BadGuyId))]
        public int BadGuyId { get; set; }
        public virtual BadGuy TheBadGuy { get; set; }

        [ForeignKey(nameof(PlanetId))]
        public int PlanetId { get; set; }
        public virtual Planet Planet { get; set; }

        public bool AdventurerWins()
        {
            int adventurerDps = 0;
            int badGuyDps = 0;
            for (int a = TheAdventurer.Damage; a < TheBadGuy.Health; a += TheAdventurer.Damage)
            {
                adventurerDps++;
            }
            for (int b = TheBadGuy.Damage; b < TheAdventurer.Health; b += TheBadGuy.Damage)
            {
                badGuyDps++;
            }
            if (adventurerDps <= badGuyDps)
            {
                GiveXP(TheBadGuy.XpDropped);
                return true;
            }
            return false;
        }

        public void GiveXP(int xp)
        {
            TheAdventurer.Xp += xp;
        }

        public int? FightNext(int nextGuy)
        {
            var ctx = new ApplicationDbContext();
            List<BadGuy> badGuys = new List<BadGuy>(ctx.BadGuys);
            List<Planet> planets = new List<Planet>(ctx.Planets);
            /*foreach (var currentPlanet in planets)
            {
                for (int i = 1; i < badGuys.Count; i++)
                {

                }
            }*/
            nextGuy += 1;
            while (nextGuy < badGuys.Count + 1)
            {
                if (Planet.PlanetId == TheBadGuy.PlanetId)
                {
                    TheBadGuy.BadGuyId = nextGuy;
                    return TheBadGuy.BadGuyId;
                }
                else
                {
                    Planet.PlanetId += 1;
                }
            }
            return null;
        }
    }
}
