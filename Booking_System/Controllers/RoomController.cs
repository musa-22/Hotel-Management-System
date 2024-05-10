using Booking_System.Data;
using Booking_System.Model.Domain;
using Booking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Booking_System.Controllers
{

    [Authorize(Roles = SD.SD.Admin_role)]
    public class RoomController : Controller
    {

        private readonly IRoomTypesRepositories _db;
        private readonly IWebHostEnvironment _webHost;
        public RoomController(IRoomTypesRepositories db, IWebHostEnvironment webHost)
        {
            this._db = db;
            _webHost = webHost;   

        }
        public async Task<IActionResult> Index()
        {

            var getRooms = await _db.GetAllAsync();

            return View(getRooms);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomTypes roomObj)
        {
            if (ModelState.IsValid)
            {
                if (roomObj.Image != null)
                {
                    //execute upload image

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(roomObj.Image.FileName);
                    string imagePath = Path.Combine(_webHost.WebRootPath, @"images\Room");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    await roomObj.Image.CopyToAsync(fileStream);
               
                    roomObj.ImageUrl = @"\images\Room\" + fileName;
                    roomObj.Created_Date = DateTime.Now;

                }
                else
                {
                    /// upload default image
                   roomObj.ImageUrl = "https://placehold.co/600x400/000000/FFF";
                    roomObj.Created_Date = DateTime.Now;
                }



                await _db.CreateAsync(roomObj);
             
                TempData["success"] = " The room has been successfully created ";
                return RedirectToAction("Index");
            }

            return View(roomObj);
        }




        [HttpGet]
        public async Task<IActionResult> Update(int roomId)
        {


            var getRoom = await _db.GetAsync(roomId);


            if (getRoom == null)
            {

                return RedirectToAction("Error", "Home"); // i will add page which will show not found page / data
            }

            return View(getRoom);
        }


        [HttpPost]
        public async Task<IActionResult> Update(RoomTypes roomObj)
        {


            //if data valid just pass the data 
            if (ModelState.IsValid)
            {

                if(roomObj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(roomObj.Image.FileName);
                    string imagePath = Path.Combine(_webHost.WebRootPath, @"images\Room");

                    if (!string.IsNullOrEmpty(roomObj.ImageUrl))
                    {
                        // DELETE IMAGE FROM FOLDER AND DATABASE

                        var oldImagePath = Path.Combine(_webHost.WebRootPath, roomObj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }


                  using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                  await  roomObj.Image.CopyToAsync(fileStream);

                    roomObj.ImageUrl = @"\images\Room\" + fileName;
                    roomObj.Updated_Date = DateTime.Now;

                }



                var updateRoomType = await _db.UpdateAsync(roomObj); 
                if (updateRoomType != null)
                {
                    TempData["success"] = " The room has been successfully updated ";
                    return RedirectToAction("Index");
                }

              
            }

            return View();


        }




        [HttpGet]
        public async Task<IActionResult> Delete(int roomId)
        {


            var getRoom = await _db.GetAsync(roomId);


            if (getRoom == null)
            {

                return RedirectToAction("Error","Home"); // I will add page which will show not found page / data
            }

            return View(getRoom);
        }




        [HttpPost]
        public async Task<IActionResult> Delete(RoomTypes roomObj)
        {

         //   var getDelete =await _db.DeleteAsync(roomObj);

            var getDelete = await _db.DeleteAsync(roomObj);

            if (getDelete is not null)
            {
                if (!string.IsNullOrEmpty(getDelete.ImageUrl))
                {
                    // DELETE IMAGE FROM FOLDER AND DATABASE

                    var oldImagePath = Path.Combine(_webHost.WebRootPath, getDelete.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }


                TempData["success"] = " The room has been successfully deleted ";
                return RedirectToAction("Index");
            }

            return View();


        }


    }
}
