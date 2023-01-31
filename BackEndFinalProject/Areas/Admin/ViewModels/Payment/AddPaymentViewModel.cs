namespace BackEndFinalProject.Areas.Admin.ViewModels.Payment
{
    public class AddPaymentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string Context { get; set; }
    }
}
