namespace BackEndFinalProject.Areas.Admin.ViewModels.Reward
{
    public class ListRewardViewModel
    {

        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ListRewardViewModel(int id, string imageUrl, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            ImageUrl = imageUrl;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        


    }
}
