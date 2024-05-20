using Booking_System.Data;
using Booking_System.Model.Domain;


namespace Booking_System.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private readonly ApplicationDbContext _db;
        
        public BookingRepository(ApplicationDbContext db)
        {
            this._db = db;
        }


        public async Task<Booking> Create(Booking booking)
        {
       


               await _db.AddAsync(booking); 
               
             await _db.SaveChangesAsync();
            
            return booking;
        }

        public Task<Booking> Update(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
