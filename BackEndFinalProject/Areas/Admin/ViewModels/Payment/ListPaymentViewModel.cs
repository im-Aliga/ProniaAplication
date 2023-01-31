namespace BackEndFinalProject.Areas.Admin.ViewModels.Payment
{
    public class ListPaymentViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Context { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ListPaymentViewModel(int id, string title, string context, DateTime createdAt, DateTime updatedAt, string imageUrl)
        {
            Id = id;
            Title = title;
            Context = context;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ImageUrl = imageUrl;
        }
    }
}
