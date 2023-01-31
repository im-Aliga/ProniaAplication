namespace BackEndFinalProject.Areas.Admin.ViewModels.SubNavbar
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }

        public int NavbarId { get; set; }
        public List<NavbarListItemViewModel>? Navbars { get; set; }

    }
}
