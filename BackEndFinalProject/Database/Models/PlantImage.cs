﻿
using BackEndFinalProject.Database.Models;
using BackEndFinalProject.Database.Models.Common;

namespace BackEndFinalProject.Database.Models
{
    public class PlantImage : BaseEntity<int>, IAuditable
    {
        public string? ImageName { get; set; }
        public string? ImageNameInFileSystem { get; set; } 



        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int PlantId { get; set; }
        public Plant? Plant { get; set; }
    }
}
