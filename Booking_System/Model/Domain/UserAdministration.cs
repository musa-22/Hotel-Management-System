using Microsoft.AspNetCore.Identity;

namespace Booking_System.Model.Domain
{
    public class UserAdministration: IdentityUser
    {

        public string Name { get; set; }

        public DateTime CreatedDateAt { get; set; }

    }
}
