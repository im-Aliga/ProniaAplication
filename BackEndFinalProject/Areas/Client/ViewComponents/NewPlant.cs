using BackEndFinalProject.Areas.Client.ViewModels.Home.Index;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BackEndFinalProject.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "NewPlant")]
    public class NewPlant:ViewComponent
    {
        private readonly DataContext _dbContext;
        private readonly IFileService _fileService;

        public NewPlant(DataContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new IndexViewModel
            {
                Plants = await _dbContext.Plants.OrderByDescending(p=>p.CreatedAt).Take(4)
                 .Select(b => new PlantListItemViewModel(
                     b.Id,
                     b.Title,
                     b.Price,
                     b.PlantImages!.Take(1)!.FirstOrDefault()! != null
                         ? _fileService.GetFileUrl(b.PlantImages!.Take(1)!.FirstOrDefault()!.ImageNameInFileSystem!, UploadDirectory.Plant)
                         : string.Empty

                 ))
                 .ToListAsync()


            };

            return View(model);
        }


    }
}
