using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndFinalProject.Areas.Client.Controllers
{

    [Area("client")]
    [Route("account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;

        public AccountController(DataContext dataContext, IUserService userService)
        {
            _dataContext = dataContext;
            _userService = userService;
        }
        [HttpGet("dashboard", Name = "client-account-dashboard")]
        public async Task<IActionResult> DashboardAsync()
        {
          

            return View();
        }
        [HttpGet("order", Name = "client-order-dashboard")]
        public async Task<IActionResult> OrderAsync()
        {


            return View();
        }

        [HttpGet("adress", Name = "client-adress-dashboard")]
        public async Task<IActionResult> AdressAsync()
        {


            return View();
        }
        [HttpGet("accountdetails", Name = "client-accountdetails-dashboard")]
        public async Task<IActionResult> AccountDetailsAsync()
        {


            return View();
        }
       

        [HttpGet("logout", Name = "client-logout-dashboard")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _userService.SignOutAsync();

            return RedirectToRoute("client-home-index");
        }

    }
}
