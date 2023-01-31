using BackEndFinalProject.Database.Models.Common;

namespace BackEndFinalProject.Database.Models
{
    public class Reward : BaseEntity<int>, IAuditable
    {
        public string BgImageName { get; set; }
        public string BgImageNameInFileSystem { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
