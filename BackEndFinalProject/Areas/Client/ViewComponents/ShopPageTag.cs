using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndFinalProject.Areas.Client.ViewModels.ShopPage;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;

namespace BackEndFinalProject.Areas.Client.ViewCompanents
{


    [ViewComponent(Name = "ShopPageTag")]
    public class ShopPageTag : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public ShopPageTag(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dataContext.Tags.Select(c => new TagListItemViewModel(c.Id, c.TagName)).ToListAsync();

            return View(model);
        }
    }
}
