using BackEndFinalProject.Areas.Client.ViewModels.Home.Index;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BackEndFinalProject.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "PlantComponent")]
    public class PlantComponent : ViewComponent
    {
        private readonly DataContext _dbContext;
        private readonly IFileService _fileService;

        public PlantComponent(DataContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string querry)
        {
            var model = new IndexViewModel();


            if (querry == "BestSeller")
            {
                var bestSellerIds = await _dbContext.OrderProducts
                    .GroupBy(op => op.PlantId)
                    .OrderByDescending(p => p.Count())
                    .Take(6)
                    .Select(x => x.Key).ToListAsync();

                model.Plants = await _dbContext.Plants.OrderByDescending(p=>p.Id).Where(p => bestSellerIds.Contains(p.Id))
                    .Select(p => new PlantListItemViewModel(p.Id, p.Title, p.Price,
                        p.PlantImages.Take(1).FirstOrDefault()! != null
                        ? _fileService.GetFileUrl(p.PlantImages!.Take(1)!.FirstOrDefault()!.ImageNameInFileSystem!, UploadDirectory.Plant) : String.Empty

                            )).ToListAsync();
                return View(model);
            }


            model.Plants = await _dbContext.Plants
             .Select(b => new PlantListItemViewModel(
                 b.Id,
                 b.Title,
                 b.Price,
                 b.PlantImages!.Take(1)!.FirstOrDefault()! != null
                     ? _fileService.GetFileUrl(b.PlantImages!.Take(1)!.FirstOrDefault()!.ImageNameInFileSystem!, UploadDirectory.Plant)
                     : string.Empty

             ))
             .ToListAsync();


            return View(model);
        }


    }
}
