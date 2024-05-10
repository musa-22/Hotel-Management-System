using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Booking_System.Model.ViewModels
{
    public class RegisterVM
    {


        [Required]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string? phoneNumber { get; set; }

        public string? Role { get; set; }

        public string? RedirectUrl { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RoleList {  get; set; }
    }
}
