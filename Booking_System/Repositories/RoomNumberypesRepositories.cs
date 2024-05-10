using Booking_System.Data;
using Booking_System.Model.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Repositories
{

    public class RoomNumberypesRepositories : IRoomNumberpesRepositories
    {

        private readonly ApplicationDbContext _db;

        public RoomNumberypesRepositories(ApplicationDbContext db)
        {
            this._db = db;
        }



        public async Task<IEnumerable<RoomNumber>> GetAllAsync()
        {
          return   await _db.RoomNumbersDb.ToListAsync();
            
        }

        public Task<RoomNumber> CreateAsync(RoomNumber roomTypes)
        {
            throw new NotImplementedException();
        }


        public Task<RoomNumber> GetAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<RoomNumber> DeleteAsync(RoomNumber roomTypes)
        {
            throw new NotImplementedException();
        }


        public Task<RoomNumber> UpdateAsync(RoomNumber roomTypes)
        {
            throw new NotImplementedException();
        }
    }
}
