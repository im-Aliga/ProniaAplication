﻿using BackEndFinalProject.Areas.Admin.ViewModels.Size;
using BackEndFinalProject.Database;
using BackEndFinalProject.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BackEndFinalProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/size")]
    [Authorize(Roles = "admin")]
    public class SizeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CategoryController> _logger;

        public SizeController(DataContext dataContext, ILogger<CategoryController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        #region List
        [HttpGet("list", Name = "admin-size-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Sizes
                .Select(c => new ListItemViewModel(c.Id, c.Name))
                .ToListAsync();

            return View(model);
        }
        #endregion

        #region Add
        [HttpGet("add", Name = "admin-size-add")]
        public async Task<IActionResult> AddAsync()
        {
            return View();
        }
        [HttpPost("add", Name = "admin-size-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid) return View(model);


            var size = new Size
            {

                Name = model.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,


            };
            await _dataContext.Sizes.AddAsync(size);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-size-list");
        }
        #endregion

        #region Update
        [HttpGet("update/{id}", Name = "admin-size-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var size = await _dataContext.Sizes.FirstOrDefaultAsync(n => n.Id == id);


            if (size is null) return NotFound();

            var model = new UpdateViewModel
            {
                Id = id,
                Name = size.Name,


            };

            return View(model);
        }
        [HttpPost("update/{id}", Name = "admin-size-update")]
        public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
        {
            var size = await _dataContext.Sizes.FirstOrDefaultAsync(n => n.Id == model.Id);
            if (size is null) return NotFound();





            if (!ModelState.IsValid) return View(model);




            if (!_dataContext.Sizes.Any(n => n.Id == model.Id)) return View(model);





            size.Name = model.Name;

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-size-list");

        }
        #endregion

        #region Delete
        [HttpPost("delete/{id}", Name = "admin-size-delete")]
        public async Task<IActionResult> DeleteAsync(UpdateViewModel model)
        {
            var size = await _dataContext.Sizes.FirstOrDefaultAsync(n => n.Id == model.Id);
            if (size is null) return NotFound();


            _dataContext.Sizes.Remove(size);
            await _dataContext.SaveChangesAsync();



            return RedirectToRoute("admin-size-list");

        } 
        #endregion


    }
}
