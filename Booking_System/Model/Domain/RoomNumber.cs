using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Model.Domain
{

    /*

   This class is created to deal with room numbers in the hotel.

    */

    public class RoomNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Room Number")]
        public int Room_Number { get; set; }


        [ForeignKey(nameof(RoomType))]
        public int RoomId { get; set;}
        [ValidateNever]
        public RoomTypes RoomType { get; set; }

        public string? SpecialDetails { get; set; }
    }
}
