using BackEndFinalProject.Areas.Client.ViewModels.Contact;
using BackEndFinalProject.Database;
using BackEndFinalProject.Database.Models;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndFinalProject.Areas.Client.Controllers
{
    [Area("client")]
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly DataContext _dataContext;
        

        public ContactController(DataContext dataContext)
        {
            _dataContext = dataContext;
            
        }
        [HttpGet("list", Name = "client-contact-list")]
        public async Task<IActionResult> Contact()
        {
            return View();
        }
        [HttpPost("list", Name = "client-contact-list")]
        public async Task< IActionResult> Contact([FromForm] ContactViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var model = new Contact
            {
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName,
                Phone = contactViewModel.Phone,
                Email = contactViewModel.Email,
                Message = contactViewModel.Message,
                CreatedAt = DateTime.Now,

            };
            
            await _dataContext.AddAsync(model);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("client-home-index");
        }


    }
}
