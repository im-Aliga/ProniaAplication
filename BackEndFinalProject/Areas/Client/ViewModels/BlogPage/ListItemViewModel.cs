namespace BackEndFinalProject.Areas.Client.ViewModels.BlogPage
{
    public class ListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FileUrl { get; set; }
        public bool IsShowVideo { get; set; }
        public bool IsShowImage { get; set; }

        public List<CategoryViewModeL> Categories { get; set; }
        public List<TagViewModel> Tags { get; set; }

        public ListItemViewModel(int id, string name, string description, 
            string fileUrl,bool isShowVideo,bool isShowImage, List<CategoryViewModeL> categories,
             List<TagViewModel> tags)
        {
            Id = id;
            Name = name;
            Description = description;
            FileUrl = fileUrl;
            IsShowImage=isShowImage;
            IsShowVideo=isShowVideo;
            Categories = categories;
            Tags = tags;
        }


        public ListItemViewModel() { }


        public class CategoryViewModeL
        {
            public CategoryViewModeL(string title, string parentTitle)
            {
                Title = title;
                ParentTitle = parentTitle;
            }

            public string Title { get; set; }
            public string ParentTitle { get; set; }


        }
        public class TagViewModel
        {
            public TagViewModel(string title)
            {
                Title = title;
            }

            public string Title { get; set; }
        }
    }
}
