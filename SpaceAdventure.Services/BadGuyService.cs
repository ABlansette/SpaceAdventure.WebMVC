﻿using SpaceAdventure.Data;
using SpaceAdventure.Models.BadGuy;
using SpaceAdventure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceAdventure.Models.Adventurer;

namespace SpaceAdventure.Services
{
    public class BadGuyService
    {
        private Guid _ownerId;
        public BadGuyService(Guid userId)
        {
            _ownerId = userId;
        }
        public bool BadGuyCreate(BadGuyCreate model)
        {
            var newBadGuy = new BadGuy()
            {
                Name = model.Name,
                Level = model.Level,
                XpDropped = model.XpDropped,
                PlanetId = model.PlanetId,
                UserId = _ownerId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.BadGuys.Add(newBadGuy);
                return ctx.SaveChanges() == 1;
            }
        }
        public List<BadGuyListItems> GetBadGuys()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var badGuyEntity = ctx.BadGuys;

                var badGuyListItems = new List<BadGuyListItems>();

                foreach (var item in badGuyEntity)
                {
                    var projectListItem = new BadGuyListItems()
                    {
                        BadGuyId = item.BadGuyId,
                        Name = item.Name,
                        Level = item.Level,
                        PlanetId = item.PlanetId,
                        XpDropped = item.XpDropped
                    };

                    badGuyListItems.Add(projectListItem);
                }

                return badGuyListItems;

            }
        }

        public BadGuyDetails GetBadGuyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BadGuys
                        .Single(e => e.BadGuyId == id && e.UserId == _ownerId);
                return
                    new BadGuyDetails
                    {
                        BadGuyId = entity.BadGuyId,
                        Name = entity.Name,
                        Level = entity.Level,
                        Health = entity.Health,
                        Damage = entity.Damage,
                        XpDropped = entity.XpDropped,
                        PlanetId = entity.PlanetId
                    };
            }
        }

        public bool UpdateBadGuy(BadGuyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BadGuys
                        .Single(e => e.BadGuyId == model.BadGuyId && e.UserId == _ownerId);

                entity.Name = model.Name;
                entity.Level = model.Level;
                entity.PlanetId = model.PlanetId;
                entity.XpDropped = model.XpDropped;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBadGuy(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .BadGuys
                        .Single(e => e.BadGuyId == id && _ownerId == e.UserId);
                ctx.BadGuys.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
