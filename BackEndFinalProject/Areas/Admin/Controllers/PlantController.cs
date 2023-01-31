using BackEndFinalProject.Areas.Admin.ViewModels.Plant;
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
    [Route("admin/plant")]
    [Authorize(Roles = "admin")]
    public class PlantController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<PlantController> _logger;
        

        public PlantController(DataContext dataContext,ILogger<PlantController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
           
        }

        #region List

        [HttpGet("list", Name = "admin-plant-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.Plants.Select(p => new PlantListViewModel(p.Id, p.Title, p.Content,
                p.Price,
                p.CreatedAt,
                p.PlantCatagories.Select(pc => pc.Category).Select(c => new PlantListViewModel.CategoryViewModeL(c.Title, c.Parent.Title)).ToList(),
                p.PlantColors.Select(pc => pc.Color).Select(c => new PlantListViewModel.ColorViewModeL(c.Name)).ToList(),
                p.PlantSizes.Select(ps => ps.Size).Select(s => new PlantListViewModel.SizeViewModeL(s.Name)).ToList(),
                p.PlantTags.Select(ps => ps.Tag).Select(s => new PlantListViewModel.TagViewModel(s.TagName)).ToList()
                )).ToListAsync();


            return View(model);
        }

        #endregion

        #region Add
        [HttpGet("add", Name = "admin-plant-add")]
        public async Task<IActionResult> AddAsync()
        {
            var model = new AddViewModel
            {
                Categories = await _dataContext.Categories
                    .Select(c => new CatagoryListItemViewModel(c.Id, c.Title))
                    .ToListAsync(),
                Sizes = await _dataContext.Sizes.Select(s => new SizeListItemViewModel(s.Id, s.Name)).ToListAsync(),
                Colors = await _dataContext.Colors.Select(c => new ColorListItemViewModel(c.Id, c.Name)).ToListAsync(),
                Tags = await _dataContext.Tags.Select(t => new TagListItemViewModel(t.Id, t.TagName)).ToListAsync()
            };

            return View(model);
        }

        [HttpPost("add", Name = "admin-plant-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return GetView(model);
            }

            foreach (var categoryId in model.CategoryIds)
            {
                if (!await _dataContext.Categories.AnyAsync(c => c.Id == categoryId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Category with id({categoryId}) not found in db ");
                    return GetView(model);
                }

            }

            foreach (var sizeId in model.SizeIds)
            {
                if (!await _dataContext.Sizes.AnyAsync(c => c.Id == sizeId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Size with id({sizeId}) not found in db ");
                    return GetView(model);
                }

            }

            foreach (var colorId in model.ColorIds)
            {
                if (!await _dataContext.Colors.AnyAsync(c => c.Id == colorId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Color with id({colorId}) not found in db ");
                    return GetView(model);
                }

            }

            foreach (var tagId in model.TagIds)
            {
                if (!await _dataContext.Tags.AnyAsync(c => c.Id == tagId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Tag with id({tagId}) not found in db ");
                    return GetView(model);
                }

            }



            AddProduct();

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-plant-list");



            IActionResult GetView(AddViewModel model)
            {

                model.Categories = _dataContext.Categories
                   .Select(c => new CatagoryListItemViewModel(c.Id, c.Title))
                   .ToList();

                model.Sizes = _dataContext.Sizes
                 .Select(c => new SizeListItemViewModel(c.Id, c.Name))
                 .ToList();

                model.Colors = _dataContext.Colors
                 .Select(c => new ColorListItemViewModel(c.Id, c.Name))
                 .ToList();

                model.Tags = _dataContext.Tags
                 .Select(c => new TagListItemViewModel(c.Id, c.TagName))
                 .ToList();


                return View(model);
            }


            async void AddProduct()
            {
                var plant = new Plant
                {
                    Title = model.Name,
                    Content = model.Description,
                    Price = model.Price,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                await _dataContext.Plants.AddAsync(plant);

                foreach (var catagoryId in model.CategoryIds)
                {
                    var plantCatagory = new PlantCatagory
                    {
                        CategoryId = catagoryId,
                        Plant = plant,
                    };

                    await _dataContext.PlantCatagories.AddAsync(plantCatagory);
                }

                foreach (var colorId in model.ColorIds)
                {
                    var plantColor = new PlantColor
                    {
                        ColorId = colorId,
                        Plant = plant,
                    };

                    await _dataContext.PlantColors.AddAsync(plantColor);
                }

                foreach (var sizeId in model.SizeIds)
                {
                    var plantSize = new PlantSize
                    {
                        SizeId = sizeId,
                        Plant = plant,
                    };

                    await _dataContext.PlantSizes.AddAsync(plantSize);
                }

                foreach (var tagId in model.TagIds)
                {
                    var plantTag = new PlantTag
                    {
                        TagId = tagId,
                        Plant = plant,
                    };

                    await _dataContext.PlantTags.AddAsync(plantTag);
                }


            }
        }

        #endregion

        #region Update
        [HttpGet("update/{id}", Name = "admin-plant-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var plant = await _dataContext.Plants
                .Include(c => c.PlantCatagories).Include(c => c.PlantColors).Include(s => s.PlantSizes).Include(t => t.PlantTags)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plant is null)
            {
                return NotFound();
            }

            var model = new UpdateViewModel
            {
                Id = plant.Id,
                Name = plant.Title,
                Description = plant.Content,
                Price = plant.Price,
                Categories = await _dataContext.Categories.Select(c => new CatagoryListItemViewModel(c.Id, c.Title)).ToListAsync(),
                CategoryIds = plant.PlantCatagories.Select(pc => pc.CategoryId).ToList(),

                Sizes = await _dataContext.Sizes.Select(c => new SizeListItemViewModel(c.Id, c.Name)).ToListAsync(),
                SizeIds = plant.PlantSizes.Select(pc => pc.SizeId).ToList(),

                Colors = await _dataContext.Colors.Select(c => new ColorListItemViewModel(c.Id, c.Name)).ToListAsync(),
                ColorIds = plant.PlantColors.Select(pc => pc.ColorId).ToList(),

                Tags = await _dataContext.Tags.Select(c => new TagListItemViewModel(c.Id, c.TagName)).ToListAsync(),
                TagIds = plant.PlantTags.Select(pc => pc.TagId).ToList(),

            };

            return View(model);

        }

        [HttpPost("update/{id}", Name = "admin-plant-update")]
        public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
        {
            var plant = await _dataContext.Plants
                    .Include(c => c.PlantCatagories).Include(c => c.PlantColors).Include(s => s.PlantSizes).Include(t => t.PlantTags)
                    .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (plant is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return GetView(model);
            }

            foreach (var categoryId in model.CategoryIds)
            {
                if (!await _dataContext.Categories.AnyAsync(c => c.Id == categoryId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Category with id({categoryId}) not found in db ");
                    return GetView(model);
                }

            }

            foreach (var sizeId in model.SizeIds)
            {
                if (!await _dataContext.Sizes.AnyAsync(c => c.Id == sizeId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Size with id({sizeId}) not found in db ");
                    return GetView(model);
                }

            }

            foreach (var colorId in model.ColorIds)
            {
                if (!await _dataContext.Colors.AnyAsync(c => c.Id == colorId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Color with id({colorId}) not found in db ");
                    return GetView(model);
                }

            }

            foreach (var tagId in model.TagIds)
            {
                if (!await _dataContext.Tags.AnyAsync(c => c.Id == tagId))
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong");
                    _logger.LogWarning($"Tag with id({tagId}) not found in db ");
                    return GetView(model);
                }

            }


            UpdateProductAsync();

            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-plant-list");



            IActionResult GetView(UpdateViewModel model)
            {
                model.Categories = _dataContext.Categories
                   .Select(c => new CatagoryListItemViewModel(c.Id, c.Title))
                   .ToList();
                model.CategoryIds = plant.PlantCatagories.Select(c => c.CategoryId).ToList();


                model.Sizes = _dataContext.Sizes
                 .Select(c => new SizeListItemViewModel(c.Id, c.Name))
                 .ToList();
                model.SizeIds = plant.PlantSizes.Select(c => c.SizeId).ToList();



                model.Colors = _dataContext.Colors
                 .Select(c => new ColorListItemViewModel(c.Id, c.Name))
                 .ToList();
                model.ColorIds = plant.PlantColors.Select(c => c.ColorId).ToList();




                model.Tags = _dataContext.Tags
                 .Select(c => new TagListItemViewModel(c.Id, c.TagName))
                 .ToList();

                model.TagIds = plant.PlantTags.Select(c => c.TagId).ToList();

                return View(model);
            }
            async Task UpdateProductAsync()
            {
                plant.Title = model.Name;
                plant.Content = model.Description;
                plant.Price = model.Price;
                plant.UpdatedAt = DateTime.Now;

                #region Catagory
                var categoriesInDb = plant.PlantCatagories.Select(bc => bc.CategoryId).ToList();
                var categoriesToRemove = categoriesInDb.Except(model.CategoryIds).ToList();
                var categoriesToAdd = model.CategoryIds.Except(categoriesInDb).ToList();

                plant.PlantCatagories.RemoveAll(bc => categoriesToRemove.Contains(bc.CategoryId));

                foreach (var categoryId in categoriesToAdd)
                {
                    var plantCatagory = new PlantCatagory
                    {
                        CategoryId = categoryId,
                        Plant = plant,
                    };

                    await _dataContext.PlantCatagories.AddAsync(plantCatagory);
                }
                #endregion

                #region Color
                var colorInDb = plant.PlantColors.Select(bc => bc.ColorId).ToList();
                var colorToRemove = colorInDb.Except(model.ColorIds).ToList();
                var colorToAdd = model.ColorIds.Except(colorInDb).ToList();

                plant.PlantColors.RemoveAll(bc => colorToRemove.Contains(bc.ColorId));


                foreach (var colorId in colorToAdd)
                {
                    var plantColor = new PlantColor
                    {
                        ColorId = colorId,
                        Plant = plant,
                    };

                    await _dataContext.PlantColors.AddAsync(plantColor);
                }
                #endregion

                #region Size
                var sizeInDb = plant.PlantSizes.Select(bc => bc.SizeId).ToList();
                var sizeToRemove = sizeInDb.Except(model.SizeIds).ToList();
                var sizeToAdd = model.SizeIds.Except(sizeInDb).ToList();

                plant.PlantSizes.RemoveAll(bc => sizeToRemove.Contains(bc.SizeId));


                foreach (var sizeId in sizeToAdd)
                {
                    var plantSize = new PlantSize
                    {
                        SizeId = sizeId,
                        Plant = plant,
                    };

                    await _dataContext.PlantSizes.AddAsync(plantSize);
                }

                #endregion

                #region Tag
                var tagInDb = plant.PlantTags.Select(bc => bc.TagId).ToList();
                var tagToRemove = tagInDb.Except(model.TagIds).ToList();
                var tagToAdd = model.TagIds.Except(tagInDb).ToList();

                plant.PlantTags.RemoveAll(bc => tagToRemove.Contains(bc.TagId));


                foreach (var tagId in tagToAdd)
                {
                    var plantTag = new PlantTag
                    {
                        TagId = tagId,
                        Plant = plant,
                    };

                    await _dataContext.PlantTags.AddAsync(plantTag);
                }
                #endregion
            }

        }
        #endregion

        #region Delete
        [HttpPost("delete/{id}", Name = "admin-plant-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var plants = await _dataContext.Plants.FirstOrDefaultAsync(p => p.Id == id);

            if (plants is null)
            {
                return NotFound();
            }

            _dataContext.Plants.Remove(plants);
            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-plant-list");
        } 
        #endregion

    }
}
