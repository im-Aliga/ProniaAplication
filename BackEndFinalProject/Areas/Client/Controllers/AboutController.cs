using BackEndFinalProject.Areas.Admin.ViewModels.FeedBack;
using BackEndFinalProject.Areas.Client.ViewModels.About;
using BackEndFinalProject.Areas.Client.ViewModels.Home.Index;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndFinalProject.Areas.Client.Controllers
{
    [Area("client")]
    [Route("about")]
    public class AboutController : Controller
    {
        private readonly DataContext _dbContext;
        private readonly IFileService _fileService;

        public AboutController(DataContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }
        [HttpGet("page", Name = "client-about")]
        public async Task<IActionResult> About()
        {
            var model = new AboutViewModel
            {

                Abouts = await _dbContext.Abouts.Select(b => new ListAboutViewModel(
                    b.Context
                    ))
                .ToListAsync(),
                Payments = await _dbContext.Payments.Select(p => new PaymmentLIstItemViewModel(
                  p.Id,
                  p.Title,
                  p.Context,
                  _fileService.GetFileUrl(p.ImageNameInFileSystem, UploadDirectory.Payment)
                      ))
                   .ToListAsync(),
                Rewards = await _dbContext.Rewards.Select(r => new RewardLIstItemViewModel(
                    r.Id,
                    _fileService.GetFileUrl(r.BgImageNameInFileSystem, UploadDirectory.Reward)
                    ))
                .ToListAsync()




            };
            return View(model);
        }
    }
}
