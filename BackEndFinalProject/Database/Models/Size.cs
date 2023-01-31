using BackEndFinalProject.Database.Models.Common;

namespace BackEndFinalProject.Database.Models
{
    public class Size : BaseEntity<int>, IAuditable
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        List<PlantSize> PlantSizes { get; set; }


    }
}
