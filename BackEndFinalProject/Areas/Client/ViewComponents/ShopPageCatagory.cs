using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndFinalProject.Areas.Client.ViewModels.ShopPage;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEndFinalProject.Areas.Client.ViewCompanents
{
    [ViewComponent(Name = "ShopPageCatagory")]
    public class ShopPageCatagory : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public ShopPageCatagory(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
           var  model = await _dataContext.Categories.Select(c => new CategoryListItemViewModel(c.Id, c.Title)).ToListAsync();
            
             return View(model);
        }
    }

}
