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
                var location = ctx.Locations.Single(l => l.LocationId == id);
                return new LocationDetail
                {
                    LocationId = location.LocationId,
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
                    LocationId = model.LocationId,
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
                    LocationId = e.LocationId,
                    City = e.City,
                    State = e.State,
                    Park = e.Park
                });

                return query.ToArray();
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var location = ctx.Locations.Single(l => l.LocationId == model.LocationId);
                location.LocationId = model.LocationId;
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
                var entity = ctx.Locations.Single(e => e.LocationId == lId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
