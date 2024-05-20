using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_System.Model.Domain
{
    public class UserAdministration: IdentityUser
    {

   
        public string Name { get; set; }

        public string Email {  get; set; }  

        
        public DateTime CreatedDateAt { get; set; }

    }
}
