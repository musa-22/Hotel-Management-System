using Booking_System.Model.Domain;
using Booking_System.Model.ViewModels;
using System.Linq.Expressions;

namespace Booking_System.Repositories
{
    public interface IRoomNumberpesRepositories
    {

        Task<IEnumerable <RoomNumber>> GetAllAsync ();

        //Task<IEnumerable<RoomTypes>> GetAllAsync(Expression<Func<RoomTypes, bool>>? filter = null, string? includeProperties = "");

        Task<RoomNumber> CreateAsync(RoomNumber roomTypes);

        Task<List<RoomTypes>> GetRoomTypes ();

       RoomNumber GetAsync(int id);


       Task<RoomNumber> UpdateAsync(RoomNumber roomTypes);


       Task<RoomNumber> DeleteAsync(RoomNumber roomTypes);

        public bool CheckExistNo(RoomNumberVM roomNumberObj);




    }
}
