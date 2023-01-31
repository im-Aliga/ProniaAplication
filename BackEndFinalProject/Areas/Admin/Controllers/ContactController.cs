using BackEndFinalProject.Areas.Admin.ViewModels.Contact;
using BackEndFinalProject.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndFinalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/contact")]
    [Authorize(Roles = "admin")]
    public class ContactController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CategoryController> _logger;

        public ContactController(DataContext dataContext, ILogger<CategoryController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        [HttpGet("list", Name = "admin-contact-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Contacts
                .Select(c => new ListContactViewModel(c.FirstName, c.LastName,c.Phone,c.Email,c.Message))
                .ToListAsync();

            return View(model);
        }
    }
}
