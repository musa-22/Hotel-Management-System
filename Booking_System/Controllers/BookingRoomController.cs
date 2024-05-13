using Booking_System.Model.Domain;
using Booking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Booking_System.Controllers
{
    public class BookingRoomController : Controller
    {
       // private readonly IRoomNumberpesRepositories _db;


        private readonly IRoomTypesRepositories _db;


        public BookingRoomController(IRoomTypesRepositories db)
        {
            this._db = db;
        }

        public async Task<IActionResult> FinalizeReservation(int roomId , string checkInDate , int nights)
        {
            DateOnly checkInDateOnly = DateOnly.ParseExact(checkInDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Booking booking = new()
            {
                RoomId = roomId,
                RoomType = await _db.GetAsync(roomId),
                CheckInDate = checkInDateOnly,
                Nights = nights,
                CheckOutDate = checkInDateOnly.AddDays(nights),
                
            };



            return View(booking);
        }
    }
}
