namespace BackEndFinalProject.Areas.Admin.ViewModels.SubNavbar
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
        public string Navbar { get; set; }

        public ListViewModel(int id, string title, int order, string url, string navbar)
        {
            Id = id;
            Title = title;
            Order = order;
            Url = url;
            Navbar = navbar;
        }
    }
}
