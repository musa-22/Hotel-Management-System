using Booking_System.Data;
using Booking_System.Model.Domain;
using Booking_System.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Repositories
{

    public class RoomNumberypesRepositories : IRoomNumberpesRepositories
    {

        private readonly ApplicationDbContext _db;

        public RoomNumberypesRepositories(ApplicationDbContext db)
        {
            this._db = db;
        }



        public async Task<IEnumerable<RoomNumber>> GetAllAsync()
        {
         var  RoomNumbersList=  await _db.RoomNumbersDb.Include(x=>x.RoomType).ToListAsync();

          if(RoomNumbersList is not null )
            {
                return RoomNumbersList;
            }
            return null;
            
        }

        public async Task<RoomNumber> CreateAsync(RoomNumber roomNumber)
        {
           
                await _db.AddAsync(roomNumber);
                await _db.SaveChangesAsync();
            

            return roomNumber;
        }


        public bool CheckExistNo(RoomNumberVM roomNumberObj)
        {
            bool checkAndValidate = _db.RoomNumbersDb.Any(u => u.Room_Number == roomNumberObj.RoomNumber.Room_Number);
            return checkAndValidate;
        }


        public RoomNumber GetAsync(int id)
        {
          var getTempData=  _db.RoomNumbersDb.FirstOrDefault(x=>x.Room_Number == id);

            if (getTempData is not null)
            {
                return getTempData;
            }

            return null;
        }

    

        public async Task<RoomNumber> UpdateAsync(RoomNumber roomNumber)
        {
            
             _db.RoomNumbersDb.Update(roomNumber);
            await  _db.SaveChangesAsync();

            return roomNumber;


        }

        public async Task<RoomNumber> DeleteAsync(RoomNumber roomTypes)
        {
            var deleteRoomNumber = await _db.RoomNumbersDb.FindAsync(roomTypes.Room_Number);

            if (deleteRoomNumber is not null)
            {
               
                _db.RoomNumbersDb.Remove(deleteRoomNumber);

               await _db.SaveChangesAsync();
                
                return deleteRoomNumber;
            }

           return null;
        }


        public async Task<List<RoomTypes>> GetRoomTypes()
        {
            var roomTypes = await _db.RoomTypesDb.ToListAsync();
            return roomTypes;
        }

     
    }
}
