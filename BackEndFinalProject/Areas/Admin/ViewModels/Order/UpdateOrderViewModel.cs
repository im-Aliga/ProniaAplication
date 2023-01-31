using BackEndFinalProject.Database.Models.Enums;

namespace BackEndFinalProject.Areas.Admin.ViewModels.Order
{
    public class UpdateOrderViewModel
    {

        public string Id { get; set; }
        public OrderStatus Status { get; set; }
       

    }
}
