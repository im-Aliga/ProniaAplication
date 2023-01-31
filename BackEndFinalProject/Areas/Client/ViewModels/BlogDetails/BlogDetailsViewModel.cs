



using BackEndFinalProject.Areas.Client.ViewModels.BlogPage;

namespace BackEndFinalProject.Areas.Client.ViewModels.BlogDetails
{
    public class BlogDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CatagoryViewModeL> Catagories { get; set; }
        public List<TagViewModeL> Tags { get; set; }
        public List<FileViewModeL> Files { get; set; }






        public class FileViewModeL
        {
            public FileViewModeL(string fileUrl, bool isShowVideo, bool isShowImage)
            {
                FileUrl = fileUrl;
                IsShowVideo = isShowVideo;
                IsShowImage = isShowImage;
            }

            public string FileUrl { get; set; }
            public bool IsShowVideo { get; set; }
            public bool IsShowImage { get; set; }
        }



        public class CatagoryViewModeL
        {
            public CatagoryViewModeL(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }
        public class TagViewModeL
        {
            public TagViewModeL(string title, int id)
            {
                Title = title;
                Id = id;
            }

            public int Id { get; set; }
            public string Title { get; set; }
        }



        

    }
}
