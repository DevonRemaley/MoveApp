using MoveApp.Data;
using MoveApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveApp.Services
{
    public class RideStatsService
    {
        private readonly Guid _userId;

        public RideStatsService(Guid userId)
        {
            _userId = userId;
        }

        public RideStatsDetail GetRideStatsDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var rideStats = ctx.RideStats.Single(r => r.RideStatsId == id);
                return new RideStatsDetail
                {
                    RideStatsId = rideStats.RideStatsId,
                    Distance = rideStats.Distance,
                    Time = rideStats.Time,
                    BikeType = rideStats.BikeType,
                };
            }
        }
        public bool CreateRideStats(RideStatsCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new RideStats()
                {
                    RideStatsId = model.RideStatsId,
                    Distance = model.Distance,
                    Time = model.Time,
                    BikeType = model.BikeType,
                };

                ctx.RideStats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RideStatsListItem> GetRideStatsList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.RideStats.Select(e => new RideStatsListItem
                {
                    RideStatsId = e.RideStatsId,
                    Distance = e.Distance,
                    Time = e.Time,
                    BikeType = e.BikeType,
                });
                return query.ToArray();
            }
        }

        public bool UpdateRideStats(RideStatsEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var rideStats = ctx.RideStats.Single(r => r.RideStatsId == model.RideStatsId);
                rideStats.RideStatsId = model.RideStatsId;
                rideStats.Distance = model.Distance;
                rideStats.Time = model.Time;
                rideStats.BikeType = model.BikeType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRideStats(int rsId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.RideStats.Single(e => e.RideStatsId == rsId);

                ctx.RideStats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
