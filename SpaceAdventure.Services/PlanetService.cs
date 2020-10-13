using SpaceAdventure.Data;
using SpaceAdventure.Models.Planet;
using SpaceAdventure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Services
{
    public class PlanetService
    {
        private Guid _ownerId;
        public PlanetService(Guid userId)
        {
            _ownerId = userId;
        }

        public bool PlanetCreate(PlanetCreate model)
        {
            var newPlanet = new Planet()
            {
                PlanetaryName = model.PlanetaryName,
                UserId = _ownerId
            };

            using (var poo = new ApplicationDbContext())
            {
                poo.Planets.Add(newPlanet);
                return poo.SaveChanges() == 1;
            }
        }


        public List<PlanetListItems> GetPlanets()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var planetentity = ctx.Planets;

                var planetListItems = new List<PlanetListItems>();

                foreach (var item in planetentity)
                {
                    var projectListItem = new PlanetListItems()
                    {
                        PlanetId = item.PlanetId,
                        PlanetaryName = item.PlanetaryName,
                        NumOfBadGuys = item.NumOfBadGuys
                    };

                    planetListItems.Add(projectListItem);
                }

                return planetListItems;

            }
        }

        public PlanetDetails GetPlanetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Planets
                        .Single(e => e.PlanetId == id && e.UserId == _ownerId);
                return
                    new PlanetDetails
                    {
                        NumOfBadGuys = entity.NumOfBadGuys,
                        PlanetaryName = entity.PlanetaryName,
                        PlanetId = entity.PlanetId,
                    };
            }
        }

        public bool UpdatePlanet(PlanetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Planets
                        .Single(e => e.PlanetId == model.PlanetId && _ownerId == e.UserId);
                entity.PlanetaryName = model.PlanetaryName;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlanet(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Planets
                        .Single(e => e.PlanetId == id && _ownerId == e.UserId);
                ctx.Planets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
