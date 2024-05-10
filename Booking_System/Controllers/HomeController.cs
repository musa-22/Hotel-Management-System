using Booking_System.Model.ViewModels;
using Booking_System.Models;
using Booking_System.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Booking_System.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;


        private readonly IRoomTypesRepositories _roomDbRepositories;



        public HomeController(ILogger<HomeController> logger  , IRoomTypesRepositories roomDbRepositories)
        {
            _logger = logger;
            _roomDbRepositories = roomDbRepositories;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new ()
            {

                RoomList = await _roomDbRepositories.GetAllAsync(),
                Nights = 1,
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
            };



            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
