using Booking_System.Data;
using Booking_System.Model.Domain;
using Booking_System.Model.ViewModels;
using Booking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Controllers
{

    [Authorize(Roles = SD.SD.Admin_role)]
    public class RoomNumberController : Controller
    {
        
        private readonly IRoomNumberpesRepositories _db;


        public RoomNumberController(IRoomNumberpesRepositories db )
        {
            this._db = db;
            

        }



        public async Task<IActionResult> Index()
        {

            var getRoomNumber = await _db.GetAllAsync();


            return View(getRoomNumber);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var getRoomType = await _db.GetRoomTypes();


            RoomNumberVM roomNumberVM = new()
            {
                RoomList = getRoomType.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString()

                })
            };

            return View(roomNumberVM);
        }




        [HttpPost]
        public async Task<IActionResult> Create(RoomNumberVM roomNumberObj)
        {
            var getRoomType = await _db.GetRoomTypes();

            // check if the numbers are exist in the table  ..

            var checkExitRoomNo = _db.CheckExistNo(roomNumberObj); //return true || false if No exsit in the record 

            // if data are valid and && Number not exist just create that record 
            if (ModelState.IsValid && !checkExitRoomNo)
            {


                await _db.CreateAsync(roomNumberObj.RoomNumber);

                TempData["success"] = " The room Number has been successfully created ";
                return RedirectToAction("Index", "RoomNumber");
            }

            if (checkExitRoomNo)
            {
                TempData["error"] = " The room Number already exist in the record  ";
            }

            // set up dropdwon list again to keep list populate 

            roomNumberObj.RoomList = getRoomType.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()

            });

            return View(roomNumberObj);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int roomId)
        {
            var getRoomNumber =await _db.GetRoomTypes();

            RoomNumberVM roomNumberVM = new()
            {
                RoomList = getRoomNumber.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString()

                }),

                RoomNumber = _db.GetAsync(roomId)
            };

            if (roomNumberVM.RoomNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(roomNumberVM);
        }


        [HttpPost]
        public async Task< ActionResult> Update(RoomNumberVM roomNumberObj)
        {
            var getRoomNumber = await _db.GetRoomTypes();
            if (ModelState.IsValid)
            {


               _db.UpdateAsync(roomNumberObj.RoomNumber);
                // _db.SaveChanges();
                TempData["success"] = " The room Number has been successfully updated ";
                return RedirectToAction("Index", "RoomNumber");
            }


            // set up dropdwon list again to keep list populate 

            roomNumberObj.RoomList = getRoomNumber.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()

            });

            return View(roomNumberObj);



        }


        [HttpGet]
        public async Task <ActionResult> Delete(int roomId)
        {
            var getRoomType = await _db.GetRoomTypes();
            RoomNumberVM roomNumberVM = new()
            {
                RoomList = getRoomType.ToList().Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString()

                }),

                RoomNumber = _db.GetAsync(roomId)
            };

            if (roomNumberVM.RoomNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(roomNumberVM);
        }


        [HttpPost]
        public async Task<ActionResult> Delete(RoomNumberVM roomNumberVM)
        {
            
            var getDeleteRoomNumber = await _db.DeleteAsync(roomNumberVM.RoomNumber);

            if (getDeleteRoomNumber is not null)
            {
             
                TempData["success"] = " The room Number has been successfully deleted ";
      
                return RedirectToAction("Index", "RoomNumber");
            }

            return View(roomNumberVM);

        }

    }
}
