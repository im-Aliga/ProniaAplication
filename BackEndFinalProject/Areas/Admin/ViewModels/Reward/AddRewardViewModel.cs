namespace BackEndFinalProject.Areas.Admin.ViewModels.Reward
{
    public class AddRewardViewModel
    {
        public int? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
