using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndFinalProject.Areas.Client.ViewModels.ShopPage;
using static BackEndFinalProject.Areas.Client.ViewModels.ShopPage.ListItemViewModel;

namespace BackEndFinalProject.Areas.Client.Controllers
{
    [Area("client")]
    [Route("shoppage")]
    public class ShopPageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;


        public ShopPageController(DataContext dataContext, IBasketService basketService, IUserService userService, IFileService fileService)
        {
            _dataContext = dataContext;
            _basketService = basketService;
            _userService = userService;
            _fileService = fileService;
        }
        [HttpGet("index", Name = "client-shoppage-index")]
        public async Task<IActionResult> Index(string searchBy, string search, [FromQuery] int? categoryId, [FromQuery] int? colorId, [FromQuery] int? tagId)
        {
            var productsQuery = _dataContext.Plants.AsQueryable();

            if (searchBy == "Name")
            {
                productsQuery = productsQuery.Where(p => p.Title.StartsWith(search) || Convert.ToString(p.Price).StartsWith(search) || search == null);
            }
            else if (categoryId is not null || colorId is not null || tagId is not null)
            {
                productsQuery = productsQuery.Include(p => p.PlantCatagories)
                    .Include(p => p.PlantColors)
                    .Include(p => p.PlantTags)
                    .Where(p => categoryId == null || p.PlantCatagories!.Any(pc => pc.CategoryId == categoryId))
                    .Where(p => colorId == null || p.PlantColors!.Any(pc => pc.ColorId == colorId))
                    .Where(p => tagId == null || p.PlantTags!.Any(pt => pt.TagId == tagId));

            }
            else
            {
                productsQuery = productsQuery.OrderBy(p => p.Price);
            }

            var newProduct = await productsQuery.Select(p => new ListItemViewModel(p.Id, p.Title, p.Content, p.Price,
                               p.PlantImages.Take(1).FirstOrDefault() != null
                               ? _fileService.GetFileUrl(p.PlantImages.Take(1).FirstOrDefault()!.ImageNameInFileSystem, UploadDirectory.Plant)
                               : String.Empty,
                                p.PlantCatagories.Select(p => p.Category).Select(p => new CategoryViewModeL(p.Title, p.Parent.Title)).ToList(),
                                p.PlantColors.Select(p => p.Color).Select(p => new ColorViewModeL(p.Name)).ToList(),
                                p.PlantSizes.Select(p => p.Size).Select(p => new SizeViewModeL(p.Name)).ToList(),
                                p.PlantTags.Select(p => p.Tag).Select(p => new TagViewModel(p.TagName)).ToList()
                                )).ToListAsync();

            return View(newProduct);

        }
    }
}
