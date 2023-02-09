
using BackEndFinalProject.Areas.Admin.ViewModels.Reward;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Database.Models;
using BackEndFinalProject.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEndFinalProject.Areas.Admin.Controllers
{
    [Area("admin")]
     [Route("admin/reward")]
    [Authorize(Roles = "admin")]
    public class RewardController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IFileService _fileService;

        public RewardController(DataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        #region List
        [HttpGet("list", Name = "admin-reward-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Rewards
                .Select(u => new ListRewardViewModel(
                  u.Id, _fileService.GetFileUrl(u.BgImageNameInFileSystem, UploadDirectory.Reward), u.CreatedAt, u.UpdatedAt))
                .ToListAsync();

            return View(model);
        }
        #endregion

        #region Add
        [HttpGet("add", Name = "admin-reward-add")]
        public async Task<IActionResult> AddAsync()
        {

            return View();
        }



        [HttpPost("add", Name = "admin-reward-add")]
        public async Task<IActionResult> AddAsync(AddRewardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var imageNameInSystem = await _fileService.UploadAsync(model!.Image, UploadDirectory.Reward);

            await AddReward(model.Image!.FileName, imageNameInSystem);


            return RedirectToRoute("admin-reward-list");


            async Task AddReward(string imageName, string imageNameInSystem)
            {
                var reward = new Reward
                {

                    BgImageName = imageName,
                    BgImageNameInFileSystem = imageNameInSystem,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                await _dataContext.Rewards.AddAsync(reward);
                await _dataContext.SaveChangesAsync();
            }
        }
        #endregion

        #region Update
        [HttpGet("update/{id}", Name = "admin-reward-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var reward = await _dataContext.Rewards.FirstOrDefaultAsync(b => b.Id == id);
            if (reward is null)
            {
                return NotFound();
            }

            var model = new AddRewardViewModel
            {
                Id = reward.Id,
                ImageUrl = _fileService.GetFileUrl(reward.BgImageNameInFileSystem, UploadDirectory.Reward)

            };

            return View(model);
        }

        [HttpPost("update/{id}", Name = "admin-reward-update")]
        public async Task<IActionResult> UpdateAsync(AddRewardViewModel model)
        {
            var reward = await _dataContext.Rewards.FirstOrDefaultAsync(b => b.Id == model.Id);
            if (reward is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Image != null)
            {
                await _fileService.DeleteAsync(reward.BgImageNameInFileSystem, UploadDirectory.Reward);
                var imageFileNameInSystem = await _fileService.UploadAsync(model.Image, UploadDirectory.Reward);
                await UpdateRewardAsync(model.Image.FileName, imageFileNameInSystem);

            }
            else
            {
                await UpdateRewardAsync(reward.BgImageName, reward.BgImageNameInFileSystem);
            }


            return RedirectToRoute("admin-reward-list");


            async Task UpdateRewardAsync(string imageName, string imageNameInFileSystem)
            {

                reward.BgImageName = imageName;
                reward.BgImageNameInFileSystem = imageNameInFileSystem;
                await _dataContext.SaveChangesAsync();
            }
        } 
        #endregion


    }
}
