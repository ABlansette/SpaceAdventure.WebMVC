using SpaceAdventure.Data;
using SpaceAdventure.Models.Adventurer;
using SpaceAdventure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Data
{
    public class AdventurerService
    {
        private readonly Guid _userId;
        public AdventurerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAdventurer(AdventurerCreate model)
        {
            var entity =
                new Adventurer()
                {
                    //AdventurerId = _adventurerId,
                    Name = model.Name,
                    Level = 1,
                    PlanetId = 1,
                    Weapon = model.WeaponChoice()
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Adventurers.Add(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }

        public List<AdventurerListItems> GetAdventurers()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var adventurerEntity = ctx.Adventurers;

                var adventurerListItems = new List<AdventurerListItems>();

                foreach (var item in adventurerEntity)
                {
                    var projectListItem = new AdventurerListItems()
                    {
                        AdventurerId = item.AdventurerId,
                        Name = item.Name,
                        Class = (Models.Adventurer.Species)item.Class,
                        Level = item.Level
                    };

                    adventurerListItems.Add(projectListItem);
                }

                return adventurerListItems;

            }
        }

        public AdventurerDetails GetAdventurerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adventurers
                        .Single(e => e.AdventurerId == id && e.OwnerId == _userId);
                return
                    new AdventurerDetails
                    {
                        AdventurerId = entity.AdventurerId,
                        Name = entity.Name,
                        Health = entity.Health,
                        Damage = entity.Damage,
                        Level = entity.Level,
                        PlanetId = entity.PlanetId,
                        Weapon = entity.WeaponChoice()
                    };
            }
        }

        public bool UpdateAdventurer(AdventurerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adventurers
                        .Single(e => e.AdventurerId == model.AdventurerId && e.OwnerId == _userId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdventurer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Adventurers
                        .Single(e => e.AdventurerId == id && e.OwnerId == _userId);
                ctx.Adventurers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

