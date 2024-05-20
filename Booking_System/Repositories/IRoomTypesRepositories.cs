using Booking_System.Model.Domain;
using System.Linq.Expressions;

namespace Booking_System.Repositories
{
    public interface IRoomTypesRepositories
    {

        Task<IEnumerable <RoomTypes>> GetAllAsync ();

        //Task<IEnumerable<RoomTypes>> GetAllAsync(Expression<Func<RoomTypes, bool>>? filter = null, string? includeProperties = "");

        Task< RoomTypes> CreateAsync(RoomTypes roomTypes);


       Task<RoomTypes> GetAsync(int id);


       Task< RoomTypes> UpdateAsync(RoomTypes roomTypes);


       Task<RoomTypes> DeleteAsync(RoomTypes roomTypes);
        void DetachEntity(RoomTypes roomType);
    }
}
