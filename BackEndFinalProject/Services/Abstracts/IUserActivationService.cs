using BackEndFinalProject.Areas.Client.ViewModels.Authentication;
using BackEndFinalProject.Database.Models;

namespace BackEndFinalProject.Services.Abstracts
{
    public interface IUserActivationService
    {
        Task SendActivationUrlAsync(User user); 

    }
}
