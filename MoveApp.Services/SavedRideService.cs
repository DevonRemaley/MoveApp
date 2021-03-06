using MoveApp.Data;
using MoveApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MoveApp.Services
{
    public class SavedRideService
    {
        private readonly Guid _userId;

        public SavedRideService(Guid userId)
        {
            _userId = userId;
        }

        public SavedRideDetail GetSavedRideDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var savedRide = ctx.SavedRides.Single(s => s.Id == id);
                return new SavedRideDetail
                {
                    Id = savedRide.Id,
                    Name = savedRide.Name,
                    Description = savedRide.Description,
                    CreatedUtc = savedRide.CreatedUtc,
                    LocationId = savedRide.LocationId,
                    Location = new LocationListItem
                    {
                        LocationId = savedRide.Location.LocationId,
                        City = savedRide.Location.City,
                        State = savedRide.Location.State,
                        Park = savedRide.Location.Park
                    },
                    RideStatsId = savedRide.RideStatsId,
                    RideStats = new RideStatsListItem
                    {
                        RideStatsId = savedRide.RideStats.RideStatsId,
                        Distance = savedRide.RideStats.Distance,
                        Time = savedRide.RideStats.Time,
                        BikeType = savedRide.RideStats.BikeType
                    }

                };
            }
        }

        public bool CreateSavedRide(SavedRideCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new SavedRide()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now,
                    LocationId = model.LocationId,
                    RideStatsId = model.RideStatsId
                };

                ctx.SavedRides.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SavedRideListItem> GetSavedRides()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.SavedRides.Select(e => new SavedRideListItem
                {
                    Id = e.Id,
                    Name = e.Name,
                    CreatedUtc = e.CreatedUtc,
                    LocationId = e.LocationId,
                    Location = new LocationListItem
                    {
                        LocationId = e.Location.LocationId,
                        City = e.Location.City,
                        State = e.Location.State,
                        Park = e.Location.Park
                    },
                    RideStatsId = e.RideStatsId,
                    RideStats = new RideStatsListItem
                    {
                        RideStatsId = e.RideStats.RideStatsId,
                        Distance = e.RideStats.Distance,
                        Time = e.RideStats.Time,
                        BikeType = e.RideStats.BikeType
                    }
                });

                return query.ToArray();
            }
        }

        public bool UpdateSavedRide(SavedRideEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var savedRide = ctx.SavedRides.Single(s => s.Id == model.Id);
                savedRide.Name = model.Name;
                savedRide.Description = model.Description;
                savedRide.LocationId = model.LocationId;
                savedRide.RideStatsId = model.RideStatsId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSavedRide(int srId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.SavedRides.Single(e => e.Id == srId);

                ctx.SavedRides.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
