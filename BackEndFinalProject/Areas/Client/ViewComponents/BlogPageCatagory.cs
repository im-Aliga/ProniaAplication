using BackEndFinalProject.Areas.Client.ViewModels.BlogPage;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BackEndFinalProject.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "BlogPageCatagory")]
    public class BlogPageCatagory : ViewComponent
    {

        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;
        public BlogPageCatagory(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _dataContext.BlogCategories.Select(c => new CategoryListItemViewModel(c.Id, c.Title)).ToListAsync();

            return View(model);
        }
    }
}
