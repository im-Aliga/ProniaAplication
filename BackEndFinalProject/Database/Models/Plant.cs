using BackEndFinalProject.Database.Models.Common;


namespace BackEndFinalProject.Database.Models
{
    public class Plant:BaseEntity<int>, IAuditable
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<PlantTag>? PlantTags { get; set; }
        public List<PlantImage>? PlantImages { get; set; }
        public List<PlantCatagory>? PlantCatagories { get; set; }
        public List<BasketProduct>? BasketProducts { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; }
        public List<PlantColor>? PlantColors { get; set; }
        public List<PlantSize>? PlantSizes { get; set; }    





    }
}
