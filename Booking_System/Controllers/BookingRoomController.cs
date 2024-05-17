using Booking_System.Model.Domain;
using Booking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace Booking_System.Controllers
{
    public class BookingRoomController : Controller
    {
       // private readonly IRoomNumberpesRepositories _db;


        private readonly IRoomTypesRepositories _db;
        private readonly IUserAdministrationRepository _userAdministrationRepository;

        public BookingRoomController(IRoomTypesRepositories db, IUserAdministrationRepository userAdministrationRepository)
        {
            this._db = db;
            _userAdministrationRepository = userAdministrationRepository;

        }

        public async Task<IActionResult> FinalizeReservation(int roomId , string checkInDate , int nights)
        {
         
            var claimIdentity =  (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);


            // minor bug need to be fixed later
            if (userId == null || string.IsNullOrEmpty(userId.Value))
            {
                return RedirectToAction("Login", "Account");
            }

            UserAdministration user = await _userAdministrationRepository.GetAsync(userId.Value);

            DateOnly checkInDateOnly = DateOnly.ParseExact(checkInDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            var roomType = await _db.GetAsync(roomId);
            double totalPrice = getFullPrice(roomType.Price, nights);

            Booking booking = new()
            {
                RoomId = roomId,
                RoomType = await _db.GetAsync(roomId),
                CheckInDate = checkInDateOnly,
                Nights = nights,
                CheckOutDate = checkInDateOnly.AddDays(nights),
                TotalCost = totalPrice,
                UserId = userId.Value,
                phoneNumber= user.PhoneNumber,
                Email=user.Email,
                Name = user.Name,
        };

                            
            return View(booking);
        }


        public double getFullPrice(double total , int night)
        {
           
            return total * night;
        }


    }
}
