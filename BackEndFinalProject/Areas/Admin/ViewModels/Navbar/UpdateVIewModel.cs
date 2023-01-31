namespace BackEndFinalProject.Areas.Admin.ViewModels.Navbar
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }
        public bool IsShowHeader { get; set; }
        public bool IsShowFooter { get; set; }
    }
}
