namespace BackEndFinalProject.Areas.Client.ViewModels.Home.About
{
    public class RewardLIstItemViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public RewardLIstItemViewModel(int id, string imageUrl)
        {
            Id = id;
            ImageUrl = imageUrl;
        }
    }
}
