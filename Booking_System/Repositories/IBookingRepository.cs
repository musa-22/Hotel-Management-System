using Booking_System.Model.Domain;

namespace Booking_System.Repositories
{
    public interface IBookingRepository
    {

        Task<Booking> Create(Booking booking);

        Task<Booking> Update(Booking booking);



    }
}
