using BackEndFinalProject.Database.Models.Common;

namespace BackEndFinalProject.Database.Models
{
    public class Navbar : BaseNavbarAndSubNavbar, IAuditable
    {
        public bool IsShowHeader { get; set; }
        public bool IsShowFooter { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<SubNavbar> SubNavbars { get; set; }

    }
}
