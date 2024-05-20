using Booking_System.Model.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Data
{
    public class ApplicationDbContext :IdentityDbContext<UserAdministration>
    {

      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base (options)
        {

        }

        public DbSet<RoomTypes> RoomTypesDb { get; set; }

        public DbSet<RoomNumber> RoomNumbersDb { get; set; }

        public DbSet<Booking> bookingsDb { get; set; }

        public DbSet<UserAdministration> UserAdministrationsDb { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
              base.OnModelCreating(builder);


          builder.Entity<RoomTypes>().HasData(
            new RoomTypes 
          { 
              Id = 1,
              Name = "Single Rooms ",
              Description = "One of the most common types of room at any hotel is the single. Typically, this means that the room has one bed meant for one person or a couple, but it doesn't necessarily mean that the room is small. In fact, some hotels may offer larger rooms than others, depending on the size of the hotel itself. Guests traveling alone or for business commonly occupy single rooms if they need short-term accommodations and not a lot of extra space. They're usually alone in the room and are using the space primarily for the purposes of sleeping and getting ready to go out.",
              Guests= 1,
              Created_Date = DateTime.Now,
              Price = 133,
              ImageUrl= "https://placehold.co/600x401",



          },
            new RoomTypes 
            {
                Id = 2,
                Name = " Double Rooms ",
                Description = ". A twin room contains two single-size beds, so it's meant for a maximum of two guests. A double room, though, can sleep up to four people because it contains two double-size beds." +
                " Both contain all the basic accommodations you would expect to find in a hotel room. ",
                Guests = 1,
                Created_Date = DateTime.Now,
                Price = 250,
                ImageUrl = "https://placehold.co/600x401",


            },
            new RoomTypes
            {
                Id = 3,
                Name = "Queen Rooms",
                Description = "room. By placing the bed in the center of the wall, the room allows for standard amenities such as a nightstand, a desk or work area, a television, and a closet. Depending on the hotel, this room type may also include a couch or sitting area",
                Guests = 1,
                Created_Date = DateTime.Now,
                Price = 450,
                ImageUrl = "https://placehold.co/600x401",


            },
            new RoomTypes
            {
                Id = 4,
                Name = "Junior Suites",
                Description = "Typically, this means that the room has one bed meant for one person or a couple, but it doesn't necessarily mean that the room is small. In fact, some hotels may offer larger rooms than others, depending on the size of the hotel itself. Guests traveling alone or for business commonly occupy single rooms if they need short-term accommodations and not a lot of extra space. They're usually alone in the room and are using the space primarily for the purposes of sleeping and getting ready to go out.",
                Guests = 1,
                Created_Date = DateTime.Now,
                Price = 1099,
                ImageUrl = "https://placehold.co/600x401",


            } );

            builder.Entity<RoomNumber>().HasData(

                new RoomNumber
                {
                    Room_Number=11,

                    RoomId=1,
                    


                }, new RoomNumber
                {
                    Room_Number = 12,

                    RoomId = 1,



                }, new RoomNumber
                {
                    Room_Number = 13,

                    RoomId = 1,



                }, new RoomNumber
                {
                    Room_Number = 14,

                    RoomId = 1,



                }, new RoomNumber
                {
                    Room_Number = 15,

                    RoomId = 2,



                }, new RoomNumber
                {
                    Room_Number = 16,

                    RoomId = 2,



                }, new RoomNumber
                {
                    Room_Number = 17,

                    RoomId = 3,



                });
            
        }

    }

   
}
