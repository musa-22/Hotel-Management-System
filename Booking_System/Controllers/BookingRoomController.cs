using Booking_System.Model.Domain;
using Booking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        private readonly IBookingRepository _bookingRepository;
        public BookingRoomController(IRoomTypesRepositories db, 
        IUserAdministrationRepository userAdministrationRepository,
        IBookingRepository bookingRepository)
        {
          this._db = db;
          this._userAdministrationRepository = userAdministrationRepository;
          this._bookingRepository = bookingRepository;

        }



        [Authorize]
        public IActionResult Index()
        {

            return View();
        }


     
        [Authorize]
       
        public async Task<IActionResult> FinalizeReservation(int roomId , string checkInDate , int nights )
        {

            if (ModelState.IsValid)
            {


                var claimIdentity =  (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
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
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> FinalizeReservationCheck(Booking booking)
        {


            booking.Status = SD.SD.StatusApproved;

            booking.BookingDate = DateTime.Now;


            await _bookingRepository.Create(booking);



            return RedirectToAction(nameof(BookingConfirmation), new { bookingId = booking.Id });
        }

        [Authorize]
        public IActionResult BookingConfirmation(int bookingId)
        {
            return View(bookingId);
        }


        public double getFullPrice(double total, int night)
        {

            return total * night;
        }



    }
}
