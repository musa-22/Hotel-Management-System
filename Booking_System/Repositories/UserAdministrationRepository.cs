using Booking_System.Data;
using Booking_System.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Booking_System.Repositories
{
    public class UserAdministrationRepository : IUserAdministrationRepository
    {

        private readonly ApplicationDbContext _db;
        public UserAdministrationRepository(ApplicationDbContext db)
        {
            this._db = db;

        }

        public async Task<UserAdministration> GetAsync(string name)
        {

            var getTempData = await _db.UserAdministrationsDb.FindAsync(name);

            if (getTempData is not null)
            {
                return getTempData;
            }

            return null;


        }

    }
}
