using BackEndFinalProject.Areas.Client.ViewModels.BlogPage;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndFinalProject.Areas.Client.Controllers
{
    [Area("client")]
    [Route("blogpage")]
    public class BlogPageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;


        public BlogPageController(DataContext dataContext, IBasketService basketService, IUserService userService, IFileService fileService)
        {
            _dataContext = dataContext;
            _basketService = basketService;
            _userService = userService;
            _fileService = fileService;
        }
        [HttpGet("index", Name = "client-blogpage-index")]
        public async Task<IActionResult> Index(string searchBy, string search, [FromQuery] int? categoryId, [FromQuery] int? colorId, [FromQuery] int? tagId)
        {
            var blogsQuery = _dataContext.Blogs.AsQueryable();

            if (searchBy == "Name")
            {
                blogsQuery = blogsQuery.Where(p => p.Title.StartsWith(search) || search == null);
            }
            else if (categoryId is not null || tagId is not null)
            {
                blogsQuery = blogsQuery
                    .Include(p => p.BlogCategory)
                    .Include(p => p.BlogTags)
                    .Where(p => categoryId == null || p.BlogCategory!.Any(pc => pc.BlogCategoryId == categoryId))
                    .Where(p => tagId == null || p.BlogTags!.Any(pt => pt.BlogTagId == tagId));

            }
           

            var newBlog = await blogsQuery.Select(p => new ListItemViewModel(p.Id, p.Title, p.Description,
                               p.BlogFile.Take(1).FirstOrDefault() != null
                               ? _fileService.GetFileUrl(p.BlogFile.Take(1).FirstOrDefault()!.FileNameInFileSystem, UploadDirectory.Blog)
                               : String.Empty,
                                p.BlogFile.FirstOrDefault().IsShowVideo,
                                p.BlogFile.FirstOrDefault().IsShowImage,
                                p.BlogCategory.Select(p => p.Category).Select(p => new ListItemViewModel.CategoryViewModeL(p.Title, p.Parent.Title)).ToList(),
                                p.BlogTags.Select(p => p.Tag).Select(p => new ListItemViewModel.TagViewModel(p.TagName)).ToList()
                                )).ToListAsync();

            return View(newBlog);

        }
    }
}
