using MoveApp.Data;
using MoveApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public LocationDetail GetLocationDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var location = ctx.Locations.Single(l => l.Id == id);
                return new LocationDetail
                {
                    Id = location.Id,
                    City = location.City,
                    State = location.State,
                    Park = location.Park,
                };
            }
        }

        public bool CreateLocation(LocationCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Location()
                {
                    Id = model.Id,
                    City = model.City,
                    State = model.State,
                    Park = model.Park
                };

                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocationList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Locations.Select(e => new LocationListItem
                {
                    Id = e.Id,
                    City = e.City,
                });

                return query.ToArray();
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var location = ctx.Locations.Single(l => l.Id == model.Id);
                location.Id = model.Id;
                location.City = model.City;
                location.State = model.State;
                location.Park = model.Park;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int lId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Locations.Single(e => e.Id == lId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
