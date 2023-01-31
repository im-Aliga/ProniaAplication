using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndFinalProject.Areas.Client.ViewModels.ShopPage;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;

namespace BackEndFinalProject.Areas.Client.ViewCompanents
{
    [ViewComponent(Name = "ShopPageColor")]
    public class ShopPageColor : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public ShopPageColor(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dataContext.Colors.Select(c => new ColorListItemViewModel(c.Id, c.Name)).ToListAsync();

            return View(model);
        }
    }
}
