namespace BackEndFinalProject.Areas.Admin.ViewModels.Navbar
{
    public class ListViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public bool IsShowHeader { get; set; }
        public bool IsShowFooter { get; set; }

        public ListViewModel(int id, string title, int order, bool isShowHeader, bool isShowFooter)
        {
            Id = id;
            Title = title;
            Order = order;
            IsShowHeader = isShowHeader;
            IsShowFooter = isShowFooter;
        }


    }
}
