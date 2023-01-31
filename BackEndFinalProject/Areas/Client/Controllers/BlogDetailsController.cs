using BackEndFinalProject.Areas.Client.ViewModels.BlogDetails;
using BackEndFinalProject.Areas.Client.ViewModels.PlantDetails;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndFinalProject.Areas.Client.ViewModels.BlogPage;

namespace BackEndFinalProject.Areas.Client.Controllers
{
    [Area("client")]
    [Route("blogdetails")]
    public class BlogDetailsController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly IFileService _fileService;

        public BlogDetailsController(DataContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }
        [HttpGet("index/{id}", Name = "client-blogdetails-index")]
        public async Task<IActionResult> Index(int id)
        {
            var blog = await _dbContext.Blogs.Include(p => p.BlogFile)
                .Include(p => p.BlogCategory)
                .Include(p => p.BlogTags).FirstOrDefaultAsync(p => p.Id == id);


            if (blog is null)
            {
                return NotFound();
            }

            var model = new BlogDetailsViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Catagories = _dbContext.BlogAndBlogCategories.Include(ps => ps.Category).Where(ps => ps.BlogId == blog.Id)
                         .Select(ps => new BlogDetailsViewModel.CatagoryViewModeL(ps.Category.Title, ps.Category.Id)).ToList(),
                Tags = _dbContext.BlogAndBlogTags.Include(ps => ps.Tag).Where(ps => ps.BlogId == blog.Id)
                      .Select(ps => new BlogDetailsViewModel.TagViewModeL(ps.Tag.TagName, ps.Tag.Id)).ToList(),

                Files = _dbContext.BlogFiles.Where(p => p.BlogId == blog.Id)
                .Select(p => new BlogDetailsViewModel.FileViewModeL
                (_fileService.GetFileUrl(p.FileNameInFileSystem, UploadDirectory.Blog),p.IsShowVideo,p.IsShowImage)).ToList()

            };
            return View(model);
        }
    }
}
