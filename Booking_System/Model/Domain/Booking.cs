using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Model.Domain
{
    public class Booking
    {
       
        public int Id { get; set; }


        [Required]
        public string UserId { get; set; }


        [ForeignKey(nameof(UserId))]
        public UserAdministration User { get; set; }

        [Required]
        public int RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public RoomTypes RoomType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string? phoneNumber { get; set; }



        [Required]
        public double TotalCost { get; set; }
        public int Nights { get; set; }
        public string? Status { get; set; }


        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateOnly CheckInDate { get; set; }

        [Required]
        public DateOnly CheckOutDate { get; set; }

        public int Room_NumberfromBookingModel { get; set; }


        [ValidateNever]
        public IEnumerable<Booking> BookingList { get; set; }

    }
}
