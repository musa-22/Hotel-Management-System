
using Booking_System.Model.Domain;
using Booking_System.Model.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Booking_System.Controllers
{
    public class AccountController : Controller
    {
     
        private readonly UserManager<UserAdministration> _userManager;

        private readonly SignInManager<UserAdministration> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<UserAdministration> userManager,
            SignInManager<UserAdministration> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;

            this._roleManager = roleManager;

            this._signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            returnUrl??= Url.Content("~/");

            LoginVM loginVM = new ()
            {

              RedirectUrl = returnUrl,

            };

            return View(loginVM);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                var check = 
                    await
                    _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password,false, lockoutOnFailure:false);


                // check reg process 
                if (check.Succeeded)
                {
                    

                    // if the RedirectUrl is empty redirect to the home page else to the LocalRedirect
                    if (string.IsNullOrEmpty(loginVM.RedirectUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(loginVM.RedirectUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login attemp.");
                }
            }

            return View(loginVM);
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {

            // role manager used to create role for the app users 
            if (!_roleManager.RoleExistsAsync(SD.SD.Admin_role).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.SD.Admin_role));

                await _roleManager.CreateAsync(new IdentityRole(SD.SD.Customer_role));
            }

            // implement dropdown list for user role
            RegisterVM registerVM = new()
            {
                // using role manager to retrive all roles
                RoleList = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name

                })

            };
            return View(registerVM);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            UserAdministration RegUser = new ()
            {
                Name = registerVM.Name,
                Email = registerVM.Email, 
                PhoneNumber = registerVM.phoneNumber,
                NormalizedEmail = registerVM.Email.ToUpper(),
                EmailConfirmed = true,
                UserName = registerVM.Email,
                CreatedDateAt = DateTime.Now,

            };

            // register user details in database 

           var results = await _userManager.CreateAsync(RegUser , registerVM.Password);

            // check reg process 
            if(results.Succeeded)
            {
                //  check if the role was not empty just assign the role // else assign customer role by def
                if (!string.IsNullOrEmpty(registerVM.Email))
                {
                    await _userManager.AddToRoleAsync(RegUser , registerVM.Role);
                }
                else
                {
                    await _userManager.AddToRoleAsync (RegUser , SD.SD.Customer_role);
                }

                //  auto sign user after register
                
                await _signInManager.SignInAsync(RegUser, isPersistent: false);

                // if the RedirectUrl is empty redirect to the home page else to the LocalRedirect
                if (string.IsNullOrEmpty(registerVM.RedirectUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                 return   LocalRedirect(registerVM.RedirectUrl);
                }
            } 
            
            // show error if something went wrong 
            foreach (var error in results.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            // implement dropdown list for user role
            registerVM.RoleList = _roleManager.Roles.Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.Name

               });

           
            return View(registerVM);
        }


    }
}
