using BackEndFinalProject.Areas.Client.ViewModels.Basket;
using BackEndFinalProject.Areas.Client.ViewModels.Home.Index;
using BackEndFinalProject.Contracts.File;
using BackEndFinalProject.Database;
using BackEndFinalProject.Services.Abstracts;
using BackEndFinalProject.Services.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Xml.Linq;

namespace BackEndFinalProject.Areas.Client.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class Cart:ViewComponent
    {
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public Cart(DataContext dataContext, IUserService userService, IFileService fileService)
        {
            _dataContext = dataContext;
            _userService = userService;
            _fileService = fileService;
        }

        public async Task<IViewComponentResult> InvokeAsync( List<ProductCookieViewModel> viewModel=null)
        {
            if (_userService.IsAuthenticated)
            {
                var model = await _dataContext.BasketProducts
                    .Where(bp => bp.Basket.UserId == _userService.CurrentUser.Id)
                    .Select(bp =>
                        new ProductCookieViewModel(
                            bp.PlantId,
                            bp.Plant!.Title,
                            bp.Plant.PlantImages.Take(1).FirstOrDefault()! != null 
                            ? _fileService.GetFileUrl(bp.Plant.PlantImages!.Take(1)!.FirstOrDefault()!.ImageNameInFileSystem!, UploadDirectory.Plant) 
                            : String.Empty,
                            bp.Quantity, 
                            bp.Plant.Price,
                            bp.Plant.Price * bp.Quantity))
                    .ToListAsync();

                return View(model);
            }



            //Case 3: Argument gonderilmeyib bu zaman cookiden oxu
            var productsCookieValue = HttpContext.Request.Cookies["products"];
            var productsCookieViewModel = new List<ProductCookieViewModel>();
            if (productsCookieValue is not null)
            {
                productsCookieViewModel = JsonSerializer.Deserialize<List<ProductCookieViewModel>>(productsCookieValue);
            }

            if(viewModel != null)
            {
                return View(viewModel);
            }


            return View(productsCookieViewModel);

        }


    }
}
