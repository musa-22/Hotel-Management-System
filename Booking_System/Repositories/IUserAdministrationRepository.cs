using Booking_System.Model.Domain;
using System.Linq.Expressions;

namespace Booking_System.Repositories
{
    public interface IUserAdministrationRepository
    {

        Task<UserAdministration> GetAsync(string name);

   
    }
}
