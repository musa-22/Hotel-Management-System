using Booking_System.Data;
using Booking_System.Model.Domain;
using Booking_System.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Booking_System.Controllers
{
    public class RoomNumberController : Controller
    {

        private readonly ApplicationDbContext _db;


        public RoomNumberController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {

            var getRoomNumber = _db.RoomNumbersDb.Include(u=>u.RoomType).ToList();


            return View(getRoomNumber);

        }

        [HttpGet]
        public IActionResult Create()
        {



            RoomNumberVM roomNumberVM = new()
            {
                RoomList = _db.RoomTypesDb.ToList().Select(r => new SelectListItem 
                { 
                Text = r.Name,  
                Value = r.Id.ToString()
                
                })
           };
         
            return View(roomNumberVM);
        }


        [HttpPost]
        public IActionResult Create(RoomNumberVM roomNumberObj)
        {

            // check if the numbers are exist in the table  ..

         bool checkExistNo = _db.RoomNumbersDb.Any(u => u.Room_Number == roomNumberObj.RoomNumber.Room_Number); //return true || false if No exsit in the record 

            // if data are valid and && Number not exist just create that record 
            if (ModelState.IsValid && !checkExistNo)
            {

           
            _db.RoomNumbersDb.Add(roomNumberObj.RoomNumber);
            _db.SaveChanges();
                TempData["success"] = " The room Number has been successfully created ";
                return  RedirectToAction("Index", "RoomNumber");
            }

            if(checkExistNo)
            {
                TempData["error"] = " The room Number already exist in the record  ";
            }

            // set up dropdwon list again to keep list populate 

            roomNumberObj.RoomList = _db.RoomTypesDb.ToList().Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()

            });

            return View(roomNumberObj);
        }


        [HttpGet]
        public IActionResult Update(int roomId)
        {

            RoomNumberVM roomNumberVM = new()
            {
                RoomList = _db.RoomTypesDb.ToList().Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString()

                }),

                 RoomNumber = _db.RoomNumbersDb.FirstOrDefault(x=> x.Room_Number == roomId)
        };

            if(roomNumberVM.RoomNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(roomNumberVM);
        }


        [HttpPost]
        public ActionResult Update(RoomNumberVM roomNumberObj)
        {

            if (ModelState.IsValid )
            {


                _db.RoomNumbersDb.Update(roomNumberObj.RoomNumber);
                _db.SaveChanges();
                TempData["success"] = " The room Number has been successfully updated ";
                return RedirectToAction("Index", "RoomNumber");
            }


            // set up dropdwon list again to keep list populate 

            roomNumberObj.RoomList = _db.RoomTypesDb.ToList().Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()

            });

            return View(roomNumberObj);


          
        }

        [HttpGet]
        public ActionResult Delete(int roomId)
        {

            RoomNumberVM roomNumberVM = new()
            {
                RoomList = _db.RoomTypesDb.ToList().Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id.ToString()

                }),

                RoomNumber = _db.RoomNumbersDb.FirstOrDefault(x => x.Room_Number == roomId)
            };

            if (roomNumberVM.RoomNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(roomNumberVM);
        }

        [HttpPost]
        public ActionResult Delete(RoomNumberVM roomNumberVM)
        {
            var roomToDele = _db.RoomNumbersDb.FirstOrDefault(x =>x.Room_Number == roomNumberVM.RoomNumber.Room_Number);
            
            if(roomToDele is not null)
            {
                _db.RoomNumbersDb.Remove(roomToDele);
                TempData["success"] = " The room Number has been successfully deleted ";
                _db.SaveChanges();
                return RedirectToAction("Index", "RoomNumber");
            }

            return View(roomNumberVM);

        }

    }
}
