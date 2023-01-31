using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndFinalProject.Areas.Client.ViewModels.PlantDetails;
using BackEndFinalProject.Areas.Client.ViewModels.Home.About;
using BackEndFinalProject.Areas.Client.ViewModels.ShopPage;

namespace BackEndFinalProject.Areas.Client.Controllers
{
    [Area("client")]
    [Route("plantdetails")]
    public class PlantDetailsController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly IFileService _fileService;

        public PlantDetailsController(DataContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }
        [HttpGet("index/{id}", Name = "client-plantdetails-index")]
        public async Task<IActionResult> Index(int id)
        {
            var plant = await _dbContext.Plants.Include(p => p.PlantImages)
                .Include(p => p.PlantCatagories)
                .Include(p => p.PlantSizes)
                .Include(p => p.PlantColors)
                .Include(p => p.PlantTags).FirstOrDefaultAsync(p => p.Id == id);


            if (plant is null)
            {
                return NotFound();
            }

            var catProducts = await _dbContext
                .PlantCatagories.GroupBy(pc => pc.CategoryId).Select(pc => pc.Key).ToListAsync();


            var model = new ProductDetailsViewModel
            {
                Id = plant.Id,
                Title = plant.Title,
                Description = plant.Content,
                Price = plant.Price,
                Payments = await _dbContext.Payments.Select(p => new PaymmentLIstItemViewModel(
                  p.Id,
                  p.Title,
                  p.Context,
                  _fileService.GetFileUrl(p.ImageNameInFileSystem, UploadDirectory.Payment)
                      ))
                   .ToListAsync(),

                Colors = _dbContext.PlantColors.Include(pc => pc.Color).Where(pc => pc.PlantId == plant.Id)
                          .Select(pc => new ProductDetailsViewModel.ColorViewModeL(pc.Color.Name, pc.Color.Id)).ToList(),

                Sizes = _dbContext.PlantSizes.Include(ps => ps.Size).Where(ps => ps.PlantId == plant.Id)
                       .Select(ps => new ProductDetailsViewModel.SizeViewModeL(ps.Size.Name, ps.Size.Id)).ToList(),

                Catagories = _dbContext.PlantCatagories.Include(ps => ps.Category).Where(ps => ps.PLantId == plant.Id)
                         .Select(ps => new ProductDetailsViewModel.CatagoryViewModeL(ps.Category.Title, ps.Category.Id)).ToList(),

                Tags = _dbContext.PlantTags.Include(ps => ps.Tag).Where(ps => ps.PlantId == plant.Id)
                      .Select(ps => new ProductDetailsViewModel.TagViewModeL(ps.Tag.TagName, ps.Tag.Id)).ToList(),

                Images = _dbContext.PlantImages.Where(p => p.PlantId == plant.Id)
                .Select(p => new ProductDetailsViewModel.ImageViewModeL
                (_fileService.GetFileUrl(p.ImageNameInFileSystem, UploadDirectory.Plant))).ToList(),


                Products = await _dbContext.PlantCatagories.Include(p => p.Plant).Where(pc => pc.PLantId != plant.Id)
                .Select(pc => new ListItemViewModel(pc.PLantId, pc.Plant.Title, pc.Plant.Price, pc.Plant.CreatedAt,
                pc.Plant.PlantImages.Take(1).FirstOrDefault() != null
                ? _fileService.GetFileUrl(pc.Plant.PlantImages.Take(1).FirstOrDefault().ImageNameInFileSystem, UploadDirectory.Plant)
                : String.Empty
               )).ToListAsync(),

            };

            return View(model);
        }

    }
}
