namespace BackEndFinalProject.Areas.Client.ViewModels.BlogPage
{
  

    public class CategoryListItemViewModel
    {
        public CategoryListItemViewModel(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class TagListItemViewModel
    {
        public TagListItemViewModel(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}

