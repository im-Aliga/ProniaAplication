using BackEndFinalProject.Areas.Client.ViewModels.Authentication;
using BackEndFinalProject.Areas.Client.ViewModels.Basket;
using BackEndFinalProject.Database.Models;

namespace BackEndFinalProject.Services.Abstracts
{
    public interface IBasketService
    {
        Task<List<ProductCookieViewModel>> AddBasketProductAsync(Plant plant);
    }
}
