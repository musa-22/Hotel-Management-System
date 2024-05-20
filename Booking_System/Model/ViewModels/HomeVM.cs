using Booking_System.Model.Domain;

namespace Booking_System.Model.ViewModels
{
    public class HomeVM
    {

        public IEnumerable<RoomTypes>? RoomList { get; set; }

        public DateOnly CheckInDate { get; set; }


        public DateOnly? CheckOutCheck { get; set; }


        public int Nights { get; set; }


     //  public Booking Booking { get; set; }

    }
}
