namespace BackEndFinalProject.Areas.Client.ViewModels.ShopPage
{
    public class ListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImgUrl { get; set; }
        public List<CategoryViewModeL> Categories { get; set; }
        public List<ColorViewModeL> Colors { get; set; }
        public List<SizeViewModeL> Sizes { get; set; }
        public List<TagViewModel> Tags { get; set; }

        public ListItemViewModel(int id, string name, string description, decimal price,
            string imgUrl, List<CategoryViewModeL> categories,
            List<ColorViewModeL> colors, List<SizeViewModeL> sizes, List<TagViewModel> tags)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImgUrl = imgUrl;
            Categories = categories;
            Colors = colors;
            Sizes = sizes;
            Tags = tags;
        }


        public ListItemViewModel() { }

        public ListItemViewModel(int id, string name, decimal price, DateTime createdAt, string imgUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            CreatedAt = createdAt;
            ImgUrl = imgUrl;
            
        }

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
        public class SizeViewModeL
        {
            public SizeViewModeL(string title)
            {
                Title = title;
            }

            public string Title { get; set; }
        }
        public class ColorViewModeL
        {
            public ColorViewModeL(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
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
