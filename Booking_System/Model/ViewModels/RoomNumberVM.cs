using Booking_System.Model.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Booking_System.Model.ViewModels
{
    public class RoomNumberVM
    {


        public RoomNumber RoomNumber { get; set; }

        public IEnumerable<SelectListItem>? RoomList { get; set; }

    }
}
