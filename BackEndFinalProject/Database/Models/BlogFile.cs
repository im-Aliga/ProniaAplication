using BackEndFinalProject.Database.Models.Common;

namespace BackEndFinalProject.Database.Models
{
    public class BlogFile : BaseEntity<int>, IAuditable
    {
        public string? FileName { get; set; }
        public string? FileNameInFileSystem { get; set; }
        public bool IsShowImage { get; set; }
        public bool IsShowVideo{ get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
