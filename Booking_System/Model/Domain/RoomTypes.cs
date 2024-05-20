using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Model.Domain
{
    public class RoomTypes
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public required string Name { get; set; }

        public string? Description { get; set; }


        [Range(15,20000)]
        [Display (Name ="Price Per Night")]
        public double Price { get; set; }

        [Range(1,5)]
        public int Guests { get; set; }

     

        [Display(Name = "Upload Image")]
        public string? ImageUrl { get; set; }



        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        [NotMapped]
        public bool IsAvailable { get; set; } = true;   

    }
}
