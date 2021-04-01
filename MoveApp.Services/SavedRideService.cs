using MoveApp.Data;
using MoveApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using(var ctx = new ApplicationDbContext())
            {
                var savedRide = ctx.SavedRides.Single(s => s.Id == id);
                return new SavedRideDetail
                {
                    SavedRideId = savedRide.Id,
                    Name = savedRide.Name,
                    Date = savedRide.Date
                };
            }
        }
        public bool CreateSavedRide(SavedRideCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newSavedRide = new SavedRide()
                {
                    Name = model.Name
                };

                ctx.SavedRides.Add(newSavedRide);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SavedRideListItem> GetSavedRideList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.SavedRides.Select(s => new SavedRideListItem
                {
                    SavedRideId = s.Id,
                    Name = s.Name,
                    Date = s.Date
                });

                return query.ToArray();
            }
        }

        public bool UpdateSavedRide(SavedRideEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var savedRide = ctx.SavedRides.Single(s => s.Id == model.SavedRideId);
                savedRide.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
