using Booking_System.Data;
using Booking_System.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Booking_System.Repositories
{
    public class RoomTypesRepositories : IRoomTypesRepositories
    {

        private readonly ApplicationDbContext _db;


        public RoomTypesRepositories(ApplicationDbContext db)
        {
            this._db = db;
        }



        public async Task <IEnumerable<RoomTypes>> GetAllAsync()
        {
            var roomList = await _db.RoomTypesDb.ToListAsync();

            if(roomList is not  null)
            {

                return roomList;
            }

            return null;
        }



        //public async Task<IEnumerable<RoomTypes>> GetAllAsync(Expression<Func<RoomTypes, bool>>? filter = null, string? includeProperties = "")
        //{
        //    //var roomList = await _db.RoomTypesDb.ToListAsync();

        //    //if(roomList is not  null)
        //    //{

        //    //    return roomList;
        //    //}

        //    IQueryable<RoomTypes> query = _db.Set<RoomTypes>();
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(item);
        //        }
        //    }

        //    return query.ToList();
        //    //return RoomTypes;
        //}


        public async Task<RoomTypes> CreateAsync(RoomTypes roomTypes)
        {
            var createRoomType = await _db.RoomTypesDb.AddAsync(roomTypes); 


            if(createRoomType is not  null) 
            {
            

                

             
            
                await _db.SaveChangesAsync();   
            }

            return roomTypes;

        }


        public async  Task<RoomTypes> GetAsync(int id)
        {

            var getTempData = await _db.RoomTypesDb.FirstOrDefaultAsync(r => r.Id == id); 
            
            if(getTempData is not null)
            {
                return getTempData;
            }

            return null;

           
        }




        public async Task< RoomTypes> UpdateAsync(RoomTypes roomTypes)
        {
         //  _db.RoomTypesDb.Update(roomTypes);

            var updateRoomType = await _db.RoomTypesDb.FirstOrDefaultAsync(x=> x.Id == roomTypes.Id);
            if(updateRoomType is not null)
            {
               
                updateRoomType.Name = roomTypes.Name;
                updateRoomType.Guests = roomTypes.Guests;
                updateRoomType.Description = roomTypes.Description;
                updateRoomType.Updated_Date = DateTime.Now;
                updateRoomType.ImageUrl = roomTypes.ImageUrl;

            }else
            {
        
                updateRoomType.Name = roomTypes.Name;
                updateRoomType.Guests = roomTypes.Guests;
                updateRoomType.Description = roomTypes.Description;
                updateRoomType.Updated_Date = DateTime.Now;

            }

           await _db.SaveChangesAsync();

          return updateRoomType;
        }


        public async Task<RoomTypes> DeleteAsync(RoomTypes roomTypes)
        {
            var deleteRoomType = await _db.RoomTypesDb.FirstOrDefaultAsync(x => x.Id == roomTypes.Id);


            if(deleteRoomType is not null)
            {
                deleteRoomType.Id = roomTypes.Id;
                deleteRoomType.Name= roomTypes.Name;

               _db.RoomTypesDb.Remove(deleteRoomType);
                await _db.SaveChangesAsync();
            }

            return deleteRoomType;
        }


        public void DetachEntity(RoomTypes entity)
        {
            var entry = _db.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
    
}


